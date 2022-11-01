using KodeFoxx.SimpleBroadcast.Core.Application.Artists;
using KodeFoxx.SimpleBroadcast.Core.Domain.Artists;
using MediatR;
using System;
using System.Windows.Forms;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp;

public partial class Main : BaseForm
{
    public Main(IMediator mediator) : base(mediator)
    {
        InitializeComponent();
        SetWindowTitle();
        SetHeader();

        LoadArtists();
        LoadSongs();
    }


    #region Songs
    private int SelectedSongListViewItemIndex => songsOverview.SelectedItems[0].Index;
    private ListViewItem SelectedSongListViewItem => songsOverview.Items[SelectedSongListViewItemIndex];
    private List<Song> _songs = new List<Song>();
    private Func<Song, ListViewItem> _songListViewItemSelector;

    private void LoadSongs()
    {
        _songs.Clear();
        PrepareOverviewListView(songsOverview);

        _songListViewItemSelector ??= s =>
        {
            var listViewItem = new ListViewItem($"{s.Artist.Principal} - {s.Title}");            
            listViewItem.Tag = s;
            listViewItem.Group = new ListViewGroup(s.Artist.Principal);
            return listViewItem;
        };

        FillListView(
            songsOverview,
            _songs,
            _songListViewItemSelector
        );

        var query = songsOverviewQuickSearchInput?.Text;
        var response = _mediator.Send(new GetSongs.Request(query)).Result;
        _songs = response.Songs.ToList();

        FillListView(
            songsOverview,
            _songs,
            _songListViewItemSelector
        );
        RemoveListViewItemIfTagIs(songsOverview, 0L);

        songsOverview.Invalidate();
    }

    private void songsOverviewQuickSearchInput_TextChanged(object sender, EventArgs e)
    {
        LoadSongs();
    }

    private void BeginEditSong()
    {
        if (songsOverview.SelectedItems.Count == 0)
            return;

        var songTitle = ((Song)SelectedSongListViewItem.Tag).Title;
        SelectedSongListViewItem.Text = songTitle;

        SelectedSongListViewItem.BeginEdit();
    }
    private void songsOverview_DoubleClick(object sender, EventArgs e)
    {
        if (songsOverview.SelectedItems.Count == 0)
            return;

        BeginEditSong();
    }

    private void songsOverview_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            BeginEditSong();
            return;
        }

        if (e.KeyCode == Keys.Delete)
        {
            // BeginDeleteSong();
            return;
        }
    }    
    private void songsOverview_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
        var listViewItem = songsOverview.Items[e.Item];
        var song = ((Song)listViewItem.Tag);

        if (e.CancelEdit == true)
        {
            LoadSongs();
            listViewItem.Text = $"{song.Artist.Principal} - {song.Title}";            
        } 
        else 
        { 
            var newValue = e.Label ?? listViewItem.Text;

            var response = _mediator.Send(
                new EditSongTitle.Request(song.Id, newValue))
                .Result;

            if (response.HasError)
            {
                MessageBox.Show(
                    text: $"Error occured while editing title. {response.ErrorMessage}",
                    caption: $"Could not edit title.",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
            }

            e.CancelEdit = true;

            LoadSongs();
        }        
    }
    #endregion

    #region Artists    
    private int SelectedArtistListViewItemIndex => artistsOverview.SelectedItems[0].Index;
    private ListViewItem SelectedArtistListViewItem => artistsOverview.Items[SelectedArtistListViewItemIndex];
    private List<Artist> _artists = new List<Artist>();
    private Func<Artist, ListViewItem> _artistListViewItemSelector;

    private void LoadArtists()
    {
        _artists.Clear();
        PrepareOverviewListView(artistsOverview);

        _artistListViewItemSelector ??= a =>
        {
            var listViewItem = new ListViewItem(a.Principal);
            listViewItem.Tag = a.Id;
            listViewItem.Group = new ListViewGroup(a.Principal.First().ToString());
            return listViewItem;
        };

        FillListView(
            artistsOverview,
            _artists,
            _artistListViewItemSelector
        );

        var query = artistsOverviewQuickSearchInput?.Text;
        var response = _mediator.Send(new GetArtists.Request(query)).Result;
        _artists = response.Artists.ToList();

        FillListView(
            artistsOverview,
            _artists,
            _artistListViewItemSelector
        );
        RemoveListViewItemIfTagIs(artistsOverview, 0L);

        artistsOverview.Invalidate();
    }

    private void artistsOverviewQuickSearchInput_TextChanged(object sender, EventArgs e)
    {
        LoadArtists();
    }

    private void addNewArtist_Click(object sender, EventArgs e)
    {
        BeginAddNewArtist();
    }

    private void artistsOverview_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
            BeginAddNewArtist();
    }

    private void BeginAddNewArtist()
    {
        var newItem = artistsOverview.Items.Add("");
        newItem.Tag = 0L;
        newItem.BeginEdit();
    }

    private void importArtistsFromFreeFormText_Click(object sender, EventArgs e)
    {
        using (var dialog = new FreeFormTextDialog())
        {
            dialog.Owner = this;
            dialog.StartPosition = FormStartPosition.CenterParent;
            this.Hide();
            dialog.ShowDialog(this);
        }
    }

    internal void HandleArtistsFromFreeFormText(string[] content, bool hasParseErrors, Form? sender)
    {
        this.Show();

        if (sender != null)
            sender.Close();

        if (hasParseErrors)
        {
            MessageBox.Show(
                text: $"Error occured while importing from free-form text.",
                caption: $"Could not import from free-form text.",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Information
            );
            return;
        }

        try
        {
            var response = _mediator.Send(
                new ImportArtists.Request(content))
                .Result;

            LoadArtists();
        }
        catch (Exception exception)
        {
            MessageBox.Show(
                text: $"Error occured while importing from free-form text. {exception.Message}",
                caption: $"Could not import from free-form text.",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Information
            );
        }
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

        if(e.KeyCode == Keys.Delete)
        {
            BeginDeleteArtist();
            return;
        }
    }

    private void BeginEditArtist()
    {
        if (artistsOverview.SelectedItems.Count == 0)
            return;

        SelectedArtistListViewItem.BeginEdit();        
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

        var response = _mediator.Send(
            new EditOrCreateArtistPrincipal.Request(artistId, newValue))
            .Result;

        e.CancelEdit = true;

        LoadArtists();
    }

    private void BeginDeleteArtist()
    {
        if (artistsOverview.SelectedItems.Count == 0)
            return;

        var selectedItem = SelectedArtistListViewItem;
        var dialogResult = MessageBox.Show(
            text: $"Are you sure you want to delete artist '{selectedItem.Text}' from your library?",
            caption: $"Delete '{selectedItem.Text}'?",
            buttons: MessageBoxButtons.YesNo,
            icon: MessageBoxIcon.Question
        );
        if (dialogResult == DialogResult.Yes)
        {
            var listViewItem = SelectedArtistListViewItem;
            var artistId = (long)listViewItem.Tag;

            var response = _mediator.Send(
                new DeleteArtist.Request(artistId))
                .Result;

            if (!response.IsDeleted)
                MessageBox.Show(
                    text: $"Error occured while deleting '{selectedItem.Text}' from your library. {response.Error}",
                    caption: $"Could not delete '{selectedItem.Text}'.",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );

            LoadArtists();
        }
    }
    #endregion

    #region ListView Helper Methods
    private void FillListView<TObject>(
        ListView listView, IEnumerable<TObject> objects, 
        Func<TObject, ListViewItem> listViewItemLabelSelectorFunc        
    )
    {        
        listView.Items.Clear();
        listView.Clear();
        var listViewItems = objects.Select(o => listViewItemLabelSelectorFunc(o));
        var listViewGroups = listViewItems.Select(i => i.Group).Distinct();
        FillListView(listView, listViewItems, listViewGroups);
    }

    private void FillListView(
        ListView listView, 
        IEnumerable<ListViewItem>? listViewItems,
        IEnumerable<ListViewGroup>? listViewGroups
    )
    {
        listView?.Items?.Clear();
        listView?.Groups?.Clear();
        listView?.Clear();

        foreach(var listViewGroup in listViewGroups)
            listView.Groups.Add(listViewGroup);

        foreach (var listViewItem in listViewItems)
            listView.Items.Add(listViewItem);

        listView.ShowGroups = true;        
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

    private void PrepareOverviewListView(ListView listView)
    {
        listView.Alignment = ListViewAlignment.Left;
        listView.View = View.List;
        listView.LabelEdit = true;
        listView.Invalidate();
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
