﻿using System;
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
    public sealed partial class LivePage : Page
    {
        public ObservableCollection<LiveXamlData> LiveXamlDataCollections { get { return _LiveXamlDataCollections; } }
        ObservableCollection<LiveXamlData> _LiveXamlDataCollections = new ObservableCollection<LiveXamlData>();

        public LivePage()
        {
            this.InitializeComponent();
            getLiveCasts();
        }
        public async void getLiveCasts()
        {
            LiveRootObject podcastsList = await LiveEpisodes.getPodcasts();

            for (int x = 0; x < podcastsList.results.Count; x++)
            {
                LiveXamlDataCollections.Add(new LiveXamlData()
                {
                    LiveThumbnails = podcastsList.results[x].thumbnail.url,
                    ButtonTag = podcastsList.results[x].id,
                    LiveDateStart = podcastsList.results[x].begin.Substring(0, 10),
                    LiveDescription = podcastsList.results[x].description
                });
            }

            liveGrid.ItemsSource = LiveXamlDataCollections;
        }
        public class LiveXamlData
        {
            public string LiveThumbnails { get; set; }
            public string ButtonTag { get; set; }
            public string LiveDateStart { get; set; }
            public string LiveDescription { get; set; }
        }

        public void mediaPlayer(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Debug.WriteLine(((String)button.Tag));
        }
    }
}
