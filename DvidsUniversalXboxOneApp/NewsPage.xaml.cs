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
    public sealed partial class NewsPage : Page
    {
        public ObservableCollection<NewsSubjectsXamlData> NewsSubjectsXamlDataCollections { get { return _NewsSubjectsXamlDataCollections; } }
        ObservableCollection<NewsSubjectsXamlData> _NewsSubjectsXamlDataCollections = new ObservableCollection<NewsSubjectsXamlData>();
        public ObservableCollection<NewsEpisodesXamlData> NewsEpisodeXamlDataCollections { get { return _NewsEpisodeXamlDataCollections; } }
        ObservableCollection<NewsEpisodesXamlData> _NewsEpisodeXamlDataCollections = new ObservableCollection<NewsEpisodesXamlData>();

        public NewsPage()
        {
            this.InitializeComponent();
            initiliazer();
        }

        public async void initiliazer()
        {
            List<Show> shows = new List<Show>();
            RootObject subjectsList = await Show.getShows();

            NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            {
                SubjectTitle = "FEATURED",
                ButtonTag = "featured"
            });
            NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            {
                SubjectTitle = "MISSIONS",
                ButtonTag = "missions"
            });
            NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            {
                SubjectTitle = "IN FOCUS",
                ButtonTag = "inFocus"
            });
            NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            {
                SubjectTitle = "DOD NEWS",
                ButtonTag = "dodNews"
            });
            NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            {
                SubjectTitle = "SCIENCE & TECHNOLOGY",
                ButtonTag = "scienceTechnology"
            });
            NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            {
                SubjectTitle = "SPORTS",
                ButtonTag = "sports"
            });
            NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            {
                SubjectTitle = "ENTERTAINMENT",
                ButtonTag = "entertainment"
            });
            NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            {
                SubjectTitle = "HEALTH",
                ButtonTag = "health"
            });
            NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            {
                SubjectTitle = "FAMILY",
                ButtonTag = "family"
            });

            //for (int x = 0; x < subjectsList.results.Count; x++)
            //{
            //    NewsSubjectsXamlDataCollections.Add(new NewsSubjectsXamlData()
            //    {
            //        ShowThumbnails = subjectsList.results[x].thumbnail,
            //        ButtonTag = subjectsList.results[x].id
            //    });
            //}

            showsGrid.ItemsSource = NewsSubjectsXamlDataCollections;
        }

        public async void getEpisodes(object sender, RoutedEventArgs e)
        {
            NewsEpisodeXamlDataCollections.Clear();
            episodesGrid.ItemsSource = NewsEpisodeXamlDataCollections;
            Button button = (Button)sender;
            Debug.WriteLine((String)button.Tag);
            string hash = "";
            switch ((String)button.Tag)
            {
                case "featured":
                    hash = "53a30744fadc79cf93e0bdd4ffb63521";
                    break;
                case "missions":
                    hash = "cf0f1e62ada20ea5d93616b85b6d745a";
                    break;
                case "inFocus":
                    hash = "e5a91e12f99715ba805f04f5592b1eb3";
                    break;
                case "dodNews":
                    hash = "ff4df4386b203d46c9867c3e7345df88";
                    break;
                case "scienceTechnology":
                    hash = "444984fa3b2ea0b66a9a5acf223630ae";
                    break;
                case "sports":
                    hash = "336aa382f0fbaf109619b7afc5bf6506";
                    break;
                case "entertainment":
                    hash = "5c89d484c5f943e2c1c779f8eece6132";
                    break;
                case "health":
                    hash = "83f4ffa642e4582ec78cd8b7d333c9c8";
                    break;
                case "family":
                    hash = "9ac80461fad25359005e8c1691231d01";
                    break;
            }

            NewsStreamRootObject episodes = await newsStreamEpisodes.getNewsStreams(hash);
            for (int x = 0; x < episodes.results.Count; x++)
            {
                NewsEpisodeXamlDataCollections.Add(new NewsEpisodesXamlData()
                {
                    EpisodeThumbnails = episodes.results[x].thumbnail,
                    EpisodeButtonTag = episodes.results[x].id,
                    EpisodeTitle = episodes.results[x].title,
                    EpisodeDescription = episodes.results[x].short_description
                });
            }
            episodesGrid.ItemsSource = NewsEpisodeXamlDataCollections;

        }

        public class NewsSubjectsXamlData
        {
            //public string ShowThumbnails { get; set; }
            public string SubjectTitle { get; set; }
            public string ButtonTag { get; set; }
        }
        public class NewsEpisodesXamlData
        {
            public string EpisodeThumbnails { get; set; }
            public string EpisodeButtonTag { get; set; }
            public string EpisodeTitle { get; set; }
            public string EpisodeDescription { get; set; }
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
