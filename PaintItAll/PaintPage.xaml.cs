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
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone;
using Microsoft.Phone.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace PaintItAll {
    public partial class PaintPage : PhoneApplicationPage {

        private List<PaintTool> paintToolCollection = new List<PaintTool>();
        private PaintTool currentPaintTool = new PaintTools.LineaPaint();

        protected Picture BackgroudPicture = null;

        protected bool mementoMoriat = false;


        public PaintPage() {
            InitializeComponent();
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e) {
            MainCanvas.Children.Clear();

        }

        private void MainCanvasMouseMove(object sender, MouseEventArgs e) {
            if (currentPaintTool == null)
                return;
            currentPaintTool.UpdatePosition(MainCanvas, e);

        }

        private void MainCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (currentPaintTool == null)
                return;
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
                var id = this.NavigationContext.QueryString["shot"];
                LoadBackgroundImage(id);
                mementoMoriat = true;
            }

            base.OnNavigatedTo(e);
        }

        private void LoadBackgroundImage(string id) {
            if (string.IsNullOrEmpty(id))
                return;

            var library = new MediaLibrary();
            foreach (var picture in library.SavedPictures) {
                if (picture.GetHashCode().ToString().CompareTo(id) == 0) {
                    // abbiamo la nostra immagine
                    var image = new Image();
                    image.Source = PictureDecoder.DecodeJpeg(picture.GetImage());
                    MainCanvas.Children.Add(image);

                }
            }
        }

        private void PhoneApplicationPageBackKeyPress(object sender, System.ComponentModel.CancelEventArgs e) {
            if (MessageBox.Show("Save current image?", "Attenction needed", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                SaveImage();
            }
        }

        private void SaveImage() {
            using (MemoryStream stream = new MemoryStream()) {
                WriteableBitmap bitmap = new WriteableBitmap(MainCanvas, null);
                bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, 100);
                stream.Seek(0, SeekOrigin.Begin);

                using (MediaLibrary mediaLibrary = new MediaLibrary())
                    mediaLibrary.SavePicture(string.Format("PIA{0}", (new Guid()).ToString()), stream);
            }
            MessageBox.Show("Picture Saved...");
               
            // Create a render bitmap and push the surface to it
            // var pic = mediaLibrary.SavePicture(string.Format("PIA{0}", (new Guid()).ToString()), image);

        }

        private void SaveImageClick(object sender, EventArgs e) {
            if (MessageBox.Show("Save current image?", "Attenction needed", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                SaveImage();
            }

        }

    }
}