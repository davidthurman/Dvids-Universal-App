using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DvidsUniversalXboxOneApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public ObservableCollection<SearchXamlData> SearchXamlDataCollections { get { return _SearchXamlDataCollections; } }
        ObservableCollection<SearchXamlData> _SearchXamlDataCollections = new ObservableCollection<SearchXamlData>();

        public SearchPage()
        {
            this.InitializeComponent();
        }

        public async void searchButton(object sender, RoutedEventArgs e)
        {
            SearchXamlDataCollections.Clear();
            episodesGrid.ItemsSource = SearchXamlDataCollections;
            Button button = (Button)sender;
            SearchRootObject episodes = await SearchEpisode.getSearchResults(searchBox.Text);
            for (int x = 0; x < episodes.results.Count; x++)
            {
                if(episodes.results[x].type == "video")
                {
                    SearchXamlDataCollections.Add(new SearchXamlData()
                    {
                        SearchThumbnails = episodes.results[x].thumbnail,
                        SearchButtonTag = episodes.results[x].id
                    });
                }
            }
            episodesGrid.ItemsSource = SearchXamlDataCollections;

        }
        public class SearchXamlData
        {
            public string SearchThumbnails { get; set; }
            public string SearchButtonTag { get; set; }
        }

        public void mediaPlayer(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            myDictionary.Add("type", "show");
            myDictionary.Add("id", ((String)button.Tag));
            showsFrame.Navigate(typeof(MediaPlayer), myDictionary);
        }
    }
}