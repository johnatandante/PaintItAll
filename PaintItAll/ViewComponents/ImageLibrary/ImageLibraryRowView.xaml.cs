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
using PaintItAll.Model;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Collections;

namespace PaintItAll.ViewComponents.ImageLibrary {
    public partial class ImageLibraryRowView : UserControl {

        public event SelectionChangedEventHandler SelectionChanged;

        private List<object> _itemsSource;
        public List<object> ItemsSource {
            get {
                return _itemsSource;
            }
            set {
                _itemsSource = value;
                ViewListbox.ItemsSource = value;
               // OnPropertyChanged("ItemsSource");
            }
        }

        public ImageLibraryRowView() {
            InitializeComponent();
            DataContext = this;
            
            ViewListbox.ItemsSource = ItemsSource;
        }

        private void ImageListBoxTap(object sender, System.Windows.Input.GestureEventArgs e) {
            var item = ((ListBox) sender).SelectedItem;
            if (item == null)
                return;
            var imageItem = (ImageItem) item;
            SelectionChanged(this, new SelectionChangedEventArgs(new List<ImageItem>(), new List<ImageItem>() { imageItem }));

        }
       
    }
}
