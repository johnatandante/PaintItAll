using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using PaintItAll.Model;

namespace PaintItAll.ViewComponents.ImageLibrary {
    public partial class ImageLibraryFlowView : UserControl {
        
        public event SelectionChangedEventHandler SelectionChanged;

        private List<object> _itemsSource;
        public List<object> ItemsSource {
            get {
                return _itemsSource;
            }
            set {
                _itemsSource = value;
                //ViewListStackPanel.Children.Clear();

                //foreach (var item in _itemsSource) {
                //    var itemView = new ImageLibraryFlowItemView();
                //    itemView.DataContext = item;
                    
                //    ViewListStackPanel.Children.Add(itemView);
                //}

                ViewListPanel.ItemsSource = ItemsSource;                
                ViewListPanel.UpdateLayout();
            }
        }

        public ImageLibraryFlowView() {
            InitializeComponent();
            DataContext = this;
            
            // ViewListPanel.ItemsSource = ItemsSource;
        }

        private void ImageListBoxTap(object sender, GestureEventArgs e) {            
            if (e.OriginalSource is Image) {
                var imageItem = (ImageItem)((Image) e.OriginalSource).DataContext;
                SelectionChanged(this, new SelectionChangedEventArgs(new List<ImageItem>(), new List<ImageItem>() { imageItem }));
            }
            
        }

    }
}
