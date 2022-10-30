using KodeFoxx.SimpleBroadcast.Core.Application.Artists;
using KodeFoxx.SimpleBroadcast.Core.Domain.Artists;
using MediatR;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp;

public partial class Main : BaseForm
{
    private Artist? SelectedArtist { get; set; }

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

        if(_artistListViewItemSelector == null)
        {
            _artistListViewItemSelector = a =>
            {
                var listViewItem = new ListViewItem(a.Principal);
                listViewItem.Tag = a.Id;
                listViewItem.Group = new ListViewGroup(a.Principal.First().ToString());
                return listViewItem;
            };
        }

        FillListView(artistsOverview, _artists, _artistListViewItemSelector);

        artistsOverview.Alignment = ListViewAlignment.Left;
        artistsOverview.View = View.List;
        artistsOverview.LabelEdit = true;

        var query = artistsOverviewQuickSearchInput?.Text;
        var response = _mediator.Send(new GetArtists.Request(query)).Result;
        _artists = response.Artists.ToList();

        FillListView(artistsOverview, _artists, _artistListViewItemSelector);
    }
    private void artistsOverview_DoubleClick(object sender, EventArgs e)
    {
        if (artistsOverview.SelectedItems.Count == 0)
            return;

        BeginEditArtist();
    }
    private void artistsOverview_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
            return;

        BeginEditArtist();
    }
    private void BeginEditArtist()
    {
        if (artistsOverview.SelectedItems.Count == 0)
            return;

        var selectedIndex = artistsOverview.SelectedItems[0].Index;
        artistsOverview.Items[selectedIndex].BeginEdit();
    }

    private void artistsOverview_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
        if (e.Label == null)
            return;

        var newValue = e.Label;
        var listViewItem = artistsOverview.Items[e.Item];
        var artistId = (long)listViewItem.Tag;

        var response = _mediator.Send(new EditArtistPrincipal.Request(artistId, newValue)).Result;

        LoadArtists();
    }

    private void artistsOverviewQuickSearchInput_TextChanged(object sender, EventArgs e)
    {
        LoadArtists();
    }

    private void FillListView<TObject>(
        ListView listView, IEnumerable<TObject> objects, 
        Func<TObject, ListViewItem> listViewItemLabelSelectorFunc)
    {
        listView.Items.Clear();
        var listViewItems = objects.Select(o => listViewItemLabelSelectorFunc(o));
        FillListView(listView, listViewItems);
    }
    private void FillListView(ListView listView, IEnumerable<ListViewItem> listViewItems)
    {
        listView.Items.Clear();
        foreach (var listViewItem in listViewItems)
            artistsOverview.Items.Add(listViewItem);
    }

    private void SetHeader()
    {
        headerPanel.BackgroundImageLayout = ImageLayout.Stretch;
        headerPanel.BackgroundImage = Image.FromFile(
            Path.Combine("Resources", "Images", "Header.png")
        );        
    }    
}
