using KodeFoxx.SimpleBroadcast.Core.Application.Artists;
using KodeFoxx.SimpleBroadcast.Core.Domain.Artists;
using MediatR;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp;

public partial class Main : BaseForm
{

#region Artists
    private Artist? SelectedArtist { get; set; }
    private int SelectedArtistListItemIndex => artistsOverview.SelectedItems[0].Index;

    public Main(IMediator mediator) : base(mediator)
    {
        InitializeComponent();        
        SetWindowTitle();
        SetHeader();

        LoadArtists();
    }

    private List<Artist> _artists = new List<Artist>();
    private Func<Artist, ListViewItem> _artistListViewItemSelector;        
    private void LoadArtists()
    {
        _artists.Clear();

        artistsOverview.Alignment = ListViewAlignment.Left;
        artistsOverview.View = View.List;
        artistsOverview.LabelEdit = true;
        artistsOverview.Invalidate();

        _artistListViewItemSelector ??= a =>
        {
            var listViewItem = new ListViewItem(a.Principal);
            listViewItem.Tag = a.Id;
            listViewItem.Group = new ListViewGroup(a.Principal.First().ToString());
            return listViewItem;
        };

        FillListView(artistsOverview, _artists, _artistListViewItemSelector);        

        var query = artistsOverviewQuickSearchInput?.Text;
        var response = _mediator.Send(new GetArtists.Request(query)).Result;
        _artists = response.Artists.ToList();

        FillListView(artistsOverview, _artists, _artistListViewItemSelector);
        RemoveListViewItemIfTagIs(artistsOverview, 0L);

        artistsOverview.Invalidate();
    }    

    private void artistsOverview_DoubleClick(object sender, EventArgs e)
    {
        if (artistsOverview.SelectedItems.Count == 0)
            return;

        BeginEditArtist();
    }
    private void artistsOverview_KeyUp(object sender, KeyEventArgs e)
    {        
        if (e.KeyCode == Keys.Enter)
        {
            BeginEditArtist();
            return;
        }
    }
    private void BeginEditArtist()
    {
        if (artistsOverview.SelectedItems.Count == 0)
            return;

        var selectedIndex = SelectedArtistListItemIndex;
        artistsOverview.Items[selectedIndex].BeginEdit();
    }

    private void artistsOverview_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
        if (e.Label == null)
        {
            e.CancelEdit = true;
            RemoveListViewItemIfTagIs(artistsOverview, 0L);
            return;
        }                    

        var newValue = e.Label;
        var listViewItem = artistsOverview.Items[e.Item];
        var artistId = (long)listViewItem.Tag;

        var response = _mediator.Send(new EditOrCreateArtistPrincipal.Request(artistId, newValue)).Result;

        e.CancelEdit = true;

        LoadArtists();
    }

    private void artistsOverviewQuickSearchInput_TextChanged(object sender, EventArgs e)
    {
        LoadArtists();
    }

    private void artistsOverview_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var newItem = artistsOverview.Items.Add("");
            newItem.Tag = 0L;
            newItem.BeginEdit();
        }
    }
#endregion

#region ListView Helper Methods
    private void FillListView<TObject>(
        ListView listView, IEnumerable<TObject> objects, 
        Func<TObject, ListViewItem> listViewItemLabelSelectorFunc)
    {        
        listView.Items.Clear();
        listView.Clear();
        var listViewItems = objects.Select(o => listViewItemLabelSelectorFunc(o));
        FillListView(listView, listViewItems);
    }

    private void FillListView(ListView listView, IEnumerable<ListViewItem> listViewItems)
    {
        listView.Items.Clear();
        listView.Clear();
        foreach (var listViewItem in listViewItems)
            listView.Items.Add(listViewItem);
    }

    private void RemoveListViewItemIfTagIs<TValue>(ListView listView, TValue value)
    {
        var itemsToRemove = new List<ListViewItem>();

        foreach(ListViewItem listViewItem in listView.Items)
            if(listViewItem.Tag != null && listViewItem.Tag.Equals(value))
                itemsToRemove.Add(listViewItem);

        foreach(ListViewItem item in itemsToRemove)
            listView.Items.Remove(item);
    }
    #endregion

    #region Form
    private void SetHeader()
    {
        headerPanel.BackgroundImageLayout = ImageLayout.Stretch;
        headerPanel.BackgroundImage = Image.FromFile(
            Path.Combine("Resources", "Images", "Header.png")
        );        
    }
    #endregion

}
