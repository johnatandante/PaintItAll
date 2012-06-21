using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using PaintItAll.Model;
using System.Windows;
using Microsoft.Phone.Tasks;

namespace PaintItAll {
    public partial class MainPage : PhoneApplicationPage {

        private CameraCaptureTask cameraTask = new CameraCaptureTask();
        protected List<ImageItem> ImageItems = new List<ImageItem>();

        public MainPage() {
            InitializeComponent();

            DataContext = this;

            cameraTask.Completed += new EventHandler<PhotoResult>(CameraTaskCompleted);

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
            var library = new MediaLibrary();
            ImageItems.Clear();

            foreach (var image in library.SavedPictures) {
                ImageItems.Add(new ImageItem(image));

            }

            ImageListBox.ItemsSource = ImageItems;
        }

        private void AboutMenuItemClick(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/YourLastAboutDialog;component/AboutPage.xaml", UriKind.Relative));
        }

        private void NewPaintClick(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/PaintPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ShotFromCameraPaintClick(object sender, EventArgs e) {            
            cameraTask.Show();

        }

        void cameraTask_Completed(object sender, PhotoResult e) {
            throw new NotImplementedException();
        }

        private void ImageListBoxTap(object sender, System.Windows.Input.GestureEventArgs e) {
            var item = (ImageItem) ((ListBox) sender).SelectedItem;

            // apro la canvas del disegno per disegnarci sopra
            NavigationService.Navigate(new Uri(string.Format("/PaintPage.xaml?id={0}", item.UniqueId), UriKind.RelativeOrAbsolute));
        }


        private void CameraTaskCompleted (object sender, PhotoResult e) {
            // apro la canvas del disegno per disegnarci sopra

            if (e.TaskResult == TaskResult.OK) {
                MediaLibrary medialibrary = new MediaLibrary();
                var pic = medialibrary.SavePicture(string.Format("PIA{0}", (new Guid()).ToString()), e.ChosenPhoto);

                var uniqueId = ImageItem.GetUniqueId(pic);                
                NavigationService.Navigate(new Uri(string.Format("/PaintPage.xaml?shot={0}", uniqueId), UriKind.RelativeOrAbsolute));
            }
        }
    }
}
