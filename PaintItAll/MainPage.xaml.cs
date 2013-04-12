using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using PaintItAll.Model;
using System.Windows;
using Microsoft.Phone.Tasks;
using System.Windows.Navigation;
using System.Collections.ObjectModel;

namespace PaintItAll {
    public partial class MainPage : PhoneApplicationPage {

        public static MainPage Instance;

        protected ObservableCollection<object> ImageItems = new ObservableCollection<object>();

        public MainPage() {
            InitializeComponent();

            DataContext = this;
            Instance = this;

            ImageLibraryView.ItemsSource = ImageItems;

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached) {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Display the metro grid helper.
                MetroGridHelper.IsVisible = true;

            }

        }

        private void PhoneApplicationPageLoaded(object sender, RoutedEventArgs e) {
            // Carico la lista delle immagini salvate in ImageItems
            RefreshMediaList();
        }

        private void RefreshMediaList() {
            var library = new MediaLibrary();
            ImageItems.Clear();

            var index = 0;
            foreach (var image in library.SavedPictures) {
                ImageItems.Insert(0, new ImageItem(image, index++));

            }

            // ImageListBox.ItemsSource = ImageItems;
            // ImageLibraryRowView.ItemsSource = ImageItems;
            ImageLibraryView.UpdateLayout();
        }

        private void AboutMenuItemClick(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/YourLastAboutDialog;component/AboutPage.xaml", UriKind.Relative));
        }

        private void NewPaintClick(object sender, EventArgs e) {
            NavigationService.Navigated += new NavigatedEventHandler(NavigationServiceNavigated);
            NavigationService.Navigate(new Uri("/PaintPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ShotFromCameraPaintClick(object sender, EventArgs e) {
            NavigationService.Navigated += new NavigatedEventHandler(NavigationServiceNavigated);
            NavigationService.Navigate(new Uri(string.Format("/PaintPage.xaml?shot"), UriKind.RelativeOrAbsolute));
        }

        private void NavigationServiceNavigated(object sender, NavigationEventArgs e) {
            if (e.NavigationMode == NavigationMode.Back || e.NavigationMode == NavigationMode.Refresh) {
                NavigationService.Navigated -= new NavigatedEventHandler(NavigationServiceNavigated);
                //RefreshMediaList();
            }
        }

        private void ImageLibraryTap(object sender, SelectionChangedEventArgs e) {
            var items = e.AddedItems;
            foreach (var item in e.AddedItems) {
                // prendo il primo
                var imageItem = (ImageItem) item;
                if (imageItem != null) {
                    NavigationService.Navigated += new NavigatedEventHandler(NavigationServiceNavigated);
                    NavigationService.Navigate(new Uri(string.Format("/PaintPage.xaml?id={0}", imageItem.ListIndex), UriKind.RelativeOrAbsolute));
                    break;
                }

            }

        }
    }
}
