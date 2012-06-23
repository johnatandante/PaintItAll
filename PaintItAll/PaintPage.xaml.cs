using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using PaintItAll.Model.PaintTools;

namespace PaintItAll {
    public partial class PaintPage : PhoneApplicationPage {
        
        private CameraCaptureTask cameraTask = new CameraCaptureTask();
        private List<PaintTool> paintToolCollection = new List<PaintTool>();
        private PaintTool currentPaintTool = new CirclePaint();

        protected bool mementoMoriat = false;
        protected bool mementoSave = false;
        protected Image BackgroundImage;

        public PaintPage() {
            InitializeComponent();
            DataContext = this;

            cameraTask.Completed += new EventHandler<PhotoResult>(CameraTaskCompleted);

        }
        
        private void MainCanvasMouseMove(object sender, MouseEventArgs e) {
            if (currentPaintTool == null)
                return;
            currentPaintTool.UpdatePosition(MainCanvas, e);

        }

        private void MainCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (currentPaintTool == null)
                return;
            mementoSave = true;
            currentPaintTool.StartEvent(MainCanvas, e);

        }

        private void MainCanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            // _lastLine = null;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            if (this.NavigationContext.QueryString.ContainsKey("id")) {
                var id = this.NavigationContext.QueryString["id"];
                LoadBackgroundImage(id);

            } else if (this.NavigationContext.QueryString.ContainsKey("shot")) {
                this.NavigationContext.QueryString.Remove("shot");
                cameraTask.Show();
                
            }

            base.OnNavigatedTo(e);
        }


        private void CameraTaskCompleted(object sender, PhotoResult e) {
            // apro la canvas del disegno per disegnarci sopra
            if (e.TaskResult == TaskResult.OK) {
                LoadBackgroundImage(e.ChosenPhoto);
                mementoMoriat = true;
            } 

        }

        private void LoadBackgroundImage(Stream photoStream) {
            BackgroundImage = new Image();
            BackgroundImage.Source = PictureDecoder.DecodeJpeg(photoStream);
            MainCanvas.Children.Add(BackgroundImage);
            BackgroundImage.Stretch = Stretch.UniformToFill;

            BackgroundImage.MaxWidth = LayoutRoot.MaxWidth - (2 * (MetroGridHelper.MAGIC_NUMBER / 2));
            // BackgroundImage.MaxHeight = MainCanvas.MaxHeight;

        }

        private void LoadBackgroundImage(string id) {
            if (string.IsNullOrEmpty(id))
                return;

            var library = new MediaLibrary();
            var index= 0;
            foreach (var picture in library.SavedPictures) {                
                if (id.CompareTo(index.ToString()) == 0) {
                    // abbiamo la nostra immagine
                    LoadBackgroundImage(picture.GetImage());
                    break;
                }
                index++;
            }
        }

        private void PhoneApplicationPageBackKeyPress(object sender, System.ComponentModel.CancelEventArgs e) {
            if ( mementoSave &&
                  MessageBox.Show("Save current image?", "Paint It All", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                SaveImage();
            }
        }

        private void SaveImage() {
            Picture pictureSaved;
            using (MemoryStream stream = new MemoryStream()) {
                WriteableBitmap bitmap = new WriteableBitmap(MainCanvas, null);
                bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, 100);
                stream.Seek(0, SeekOrigin.Begin);

                using (MediaLibrary mediaLibrary = new MediaLibrary()) {
                    pictureSaved = mediaLibrary.SavePicture(string.Format("PIA{0}", (Guid.NewGuid()).ToString()), stream);
                }
            }

            MessageBox.Show("Picture Saved...");

            // pulisci tutto e carica l'immagine finale
            MainCanvas.Children.Clear();

            BackgroundImage = new Image();
            if (pictureSaved != null)
                BackgroundImage.Source = PictureDecoder.DecodeJpeg(pictureSaved.GetImage());
            MainCanvas.Children.Add(BackgroundImage);
            mementoSave = false;
        }

        private void SaveImageClick(object sender, EventArgs e) {
            if (MessageBox.Show("Save current image?", "Paint It All", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                SaveImage();
            }

        }

        private void ClearScreenmenuClick(object sender, EventArgs e) {            
            MainCanvas.Children.Clear();

            if (BackgroundImage != null)
                MainCanvas.Children.Add(BackgroundImage);

        }

    }
}