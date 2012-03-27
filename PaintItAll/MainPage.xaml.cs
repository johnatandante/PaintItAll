using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PaintItAll.PaintTools;

namespace PaintItAll
{
    public partial class MainPage : PhoneApplicationPage
    {
        private List<object> ImageItems = new List<object>();

        public MainPage()
        {
            InitializeComponent();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Display the metro grid helper.
                MetroGridHelper.IsVisible = true;

            }

        }        

        private void PhoneApplicationPageLoaded(object sender, RoutedEventArgs e)
        {
            // todo
        }

        private void AboutMenuItemClick(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/YourLastAboutDialog;component/AboutPage.xaml", UriKind.Relative));
        }
        
    }
}
