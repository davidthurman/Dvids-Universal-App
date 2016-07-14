using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
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
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DvidsUniversalXboxOneApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Random rnd = new Random();
            int home = rnd.Next(1, 4);
            Debug.WriteLine(rnd.Next(1, 4));
            switch(home){
                case 1:
                    BitmapImage bitmapImage = new BitmapImage(new Uri(this.BaseUri, "/Assets/bg1.jpg"));
                    homeImage.Source = bitmapImage;
                    break;
                case 2:
                    BitmapImage bitmapImage2 = new BitmapImage(new Uri(this.BaseUri, "/Assets/bg2.jpg"));
                    homeImage.Source = bitmapImage2;
                    break;
                case 3:
                    BitmapImage bitmapImage3 = new BitmapImage(new Uri(this.BaseUri, "/Assets/bg3.jpg"));
                    homeImage.Source = bitmapImage3;
                    break;
            }
        }

        private void showsButton(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(showsPage));          
        }
        private void militarySpotlightButton(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(MilitarySpotlightPage));
        }
        private void liveButton(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(LivePage));
        }
        private void newsButton(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(NewsPage));
        }
        private void searchButton(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(SearchPage));
        }
        private void aboutButton(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(AboutPage));
        }
    }
}
