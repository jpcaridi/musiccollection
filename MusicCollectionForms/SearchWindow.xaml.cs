using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MusicCollectionController;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionForms
{
    public class SelectableAlbum : INotifyPropertyChanged
    {
        private bool _isSelected;
        public IAlbum Album { get; }

        public SelectableAlbum(IAlbum album)
        {
            Album = album;
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public string Name => Album.Name;
        public string Artist => Album.Artist;
        public uint Year => Album.Year;
        public int PlayCount => Album.PlayCount;
        public string Url => Album.Url;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class SearchWindow : Window
    {
        private readonly IConsumerService _mConsumerService;
        private readonly ObservableCollection<SelectableAlbum> _searchResults = new();

        public SearchWindow(IConsumerService consumerService)
        {
            InitializeComponent();
            _mConsumerService = consumerService;
            SearchDataGrid.ItemsSource = _searchResults;
        }

        public IList<IAlbum>? SelectedAlbums
        {
            get
            {
                List<IAlbum> selectedList = new();
                foreach (var item in _searchResults)
                {
                    if (item.IsSelected)
                    {
                        selectedList.Add(item.Album);
                    }
                }
                return selectedList.Count > 0 ? selectedList : null;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchString = SearchTextBox.Text;
            _searchResults.Clear();

            var results = Controller.Search(_mConsumerService, searchString);
            foreach (var album in results)
            {
                _searchResults.Add(new SelectableAlbum(album));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
