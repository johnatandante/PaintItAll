using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;
using Microsoft.Phone;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;
using System.Threading;
using Proattiva.Utils.Phone;

namespace PaintItAll.Model {
    public class ImageItem : PropertyChangedBaseClass {

        public int ListIndex { get; set; }

        public string UniqueId {
            get {
                return GetUniqueId(_image);
            }
        }

        private Picture _image;
        public Picture Image {
            get {
                return _image;
            }
            set {
                _image = value;
                OnPropertyChanged("Nome");
                OnPropertyChanged("Descrizione");
                OnPropertyChanged("UniqueId");
                // OnPropertyChanged("ImgStream");
            }

        }

        public WriteableBitmap ImgStream {
            get {
                return PictureDecoder.DecodeJpeg(Image.GetThumbnail());
            }
        }

        public string Nome {
            get {
                return Image.Name;
            }
        }

        public string Descrizione {
            get {
                return string.Format("({0}x{1} Created on {2} - {3})", Image.Width, Image.Height, Image.Date.ToShortDateString(), Image.Date.ToShortTimeString());
            }
        }

        public ImageItem(Picture picture, int listIndex = -1) {
            Image = picture;
            ListIndex = listIndex;
        }

        public static string GetUniqueId(Picture pic) {
            return string.Format("{0}.{1}", pic.GetHashCode(), pic.Date.ToFileTimeUtc());
        }
    }
}
