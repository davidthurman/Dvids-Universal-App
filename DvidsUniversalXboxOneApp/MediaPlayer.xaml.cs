using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
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
    public sealed partial class MediaPlayer : Page
    {
        string videoId;
        public ObservableCollection<XamlData> XamlDataCollections { get { return _XamlDataCollections; } }
        ObservableCollection<XamlData> _XamlDataCollections = new ObservableCollection<XamlData>();
        public ObservableCollection<UrlXamlData> EpisodeXamlDataCollections { get { return _UrlXamlData; } }
        ObservableCollection<UrlXamlData> _UrlXamlData = new ObservableCollection<UrlXamlData>();

        public MediaPlayer()
        {
            this.InitializeComponent();
           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            myDictionary = e.Parameter as Dictionary<string, string>;
            videoId = myDictionary["id"].ToString();
            string type = myDictionary["type"].ToString();
            Debug.WriteLine(type);
            Debug.WriteLine(videoId);
            getUrl(type);
        }

        public async void getUrl(string type)
        {
            switch (type)
            {
                case "podcast":
                    RootObjectUrl urlDataPod = await MediaUrl.getUrl(videoId);
                    System.Uri myPod = new System.Uri(urlDataPod.results.hls_url);
                    Debug.WriteLine(urlDataPod);
                    Debug.WriteLine(myPod);
                    mediaPlayer.Source = myPod;
                    break;
                case "show":
                    RootObjectUrl urlDataShow = await MediaUrl.getUrl(videoId);
                    System.Uri myVid = new System.Uri(urlDataShow.results.files[(urlDataShow.results.files.Count - 1)].src);
                    mediaPlayer.Source = myVid;
                    break;
                case "newstream":
                    break;
                case "live":
                    break;
                case "dod":
                    break;
            }
            


            return;
        }
        public class XamlData
        {
            public string ShowThumbnails { get; set; }
            public string ButtonTag { get; set; }
        }
        public class UrlXamlData
        {
            public string url { get; set; }
        }
    }
}
