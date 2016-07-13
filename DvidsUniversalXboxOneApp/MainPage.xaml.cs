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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DvidsUniversalXboxOneApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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
    }
}
