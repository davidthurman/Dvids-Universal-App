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
    public sealed partial class showsPage : Page
    {
        public ObservableCollection<XamlData> XamlDataCollections { get { return _XamlDataCollections; } }
        ObservableCollection<XamlData> _XamlDataCollections = new ObservableCollection<XamlData>();
        public ObservableCollection<EpisodeXamlData> EpisodeXamlDataCollections { get { return _EpisodeXamlDataCollections; } }
        ObservableCollection<EpisodeXamlData> _EpisodeXamlDataCollections = new ObservableCollection<EpisodeXamlData>();

        public showsPage()
        {
            this.InitializeComponent();
            initiliazer();
        }

        public async void initiliazer()
        {
            List<Show> shows = new List<Show>();
            RootObject showsTest = await Show.getShows();

            for (int x = 0; x < showsTest.results.Count; x++)
            {
                XamlDataCollections.Add(new XamlData()
                {
                    ShowThumbnails = showsTest.results[x].thumbnail,
                    ButtonTag = showsTest.results[x].id
                });
                Debug.WriteLine(showsTest.results[x].id);
                Debug.WriteLine(XamlDataCollections[0].ShowThumbnails);
            }

            showsGrid.ItemsSource = XamlDataCollections;
        }

        public async void getEpisodes(object sender, RoutedEventArgs e)
        {
            EpisodeXamlDataCollections.Clear();
            episodesGrid.ItemsSource = EpisodeXamlDataCollections;
            Button button = (Button)sender;
            RootObjectEpisodes episodes = await Episode.getEpisodes((String)button.Tag);
            for (int x = 0; x < episodes.results.Count; x++)
            {
                Debug.WriteLine(episodes.results[x].thumbnail);
                EpisodeXamlDataCollections.Add(new EpisodeXamlData()
                {
                    EpisodeThumbnails = episodes.results[x].thumbnail,
                    EpisodeButtonTag = episodes.results[x].id
                });
            }
            episodesGrid.ItemsSource = EpisodeXamlDataCollections;

        }

        public class XamlData
        {
            public string ShowThumbnails { get; set; }
            public string ButtonTag { get; set; }
        }
        public class EpisodeXamlData
        {
            public string EpisodeThumbnails { get; set; }
            public string EpisodeButtonTag { get; set; }
        }

        public void mediaPlayer(object sender, RoutedEventArgs e)
        {
            

            //  var applicationView =  Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            //applicationView.TryEnterFullScreenMode();
        }
    }
}
