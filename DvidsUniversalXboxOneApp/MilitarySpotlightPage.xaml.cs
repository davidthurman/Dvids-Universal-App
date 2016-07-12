using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public sealed partial class MilitarySpotlightPage : Page
    {
        public ObservableCollection<PodcastShowsXamlData> PodcastShowsXamlDataCollections { get { return _PodcastShowsXamlDataCollections; } }
        ObservableCollection<PodcastShowsXamlData> _PodcastShowsXamlDataCollections = new ObservableCollection<PodcastShowsXamlData>();
        public ObservableCollection<PodcastEpisodeXamlData> PodcastEpisodeXamlDataCollections { get { return _PodcastEpisodeXamlDataCollections; } }
        ObservableCollection<PodcastEpisodeXamlData> _PodcastEpisodeXamlDataCollections = new ObservableCollection<PodcastEpisodeXamlData>();

        public MilitarySpotlightPage()
        {
            this.InitializeComponent();
            initiliazer();
        }

        public async void initiliazer()
        {
            RootObjectPodcast podcastsList = await Podcast.getPodcasts();

            for (int x = 0; x < podcastsList.results.Count; x++)
            {
                PodcastShowsXamlDataCollections.Add(new PodcastShowsXamlData()
                {
                    podcastThumbnails = podcastsList.results[x].thumbnail,
                    ButtonTag = podcastsList.results[x].id
                });
            }

            podcastsGrid.ItemsSource = PodcastShowsXamlDataCollections;
        }

        public async void getPodcasts(object sender, RoutedEventArgs e)
        {
            PodcastEpisodeXamlDataCollections.Clear();
            episodesGrid.ItemsSource = PodcastEpisodeXamlDataCollections;
            Button button = (Button)sender;
            Debug.WriteLine(((String)button.Tag));
            PodcastEpisodeRootObject podcasts = await PodcastEpisode.getEpisodes(((String)button.Tag));

            for (int x = 0; x < podcasts.results.Count; x++)
            {
                PodcastEpisodeXamlDataCollections.Add(new PodcastEpisodeXamlData()
                {
                    thumbnail = podcasts.results[x].thumbnail,
                    id = podcasts.results[x].id,
                    title = podcasts.results[x].title,
                    description = podcasts.results[x].description
                });
            }
            episodesGrid.ItemsSource = PodcastEpisodeXamlDataCollections;

        }
        public void mediaPlayer(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            myDictionary.Add("type", "podcast");
            myDictionary.Add("id", ((String)button.Tag));
            militarySpotlightFrame.Navigate(typeof(MediaPlayer), myDictionary);
        }
        public class PodcastShowsXamlData
        {
            public string podcastThumbnails { get; set; }
            public string ButtonTag { get; set; }
        }
        public class PodcastEpisodeXamlData
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string thumbnail { get; set; }
        }
    }
    

}
