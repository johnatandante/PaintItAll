using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using PaintItAll.Model;

namespace PaintItAll.ViewComponents.ImageLibrary {
    public partial class ImageLibraryFlowView : UserControl {
        
        public event SelectionChangedEventHandler SelectionChanged;

        public ViewImageDataContext ImageDataContext = new ViewImageDataContext();

        public ObservableCollection<object> ItemsSource {
            get {
                return ImageDataContext.ImageSource;
            }
            set {
                ImageDataContext.ImageSource = value;                
                // ViewListPanel.ItemsSource = ItemsSource;
                ViewListPanel.UpdateLayout();
            }
        }

        public ImageLibraryFlowView() {
            InitializeComponent();
            DataContext = ImageDataContext;
            ViewListPanel.ItemsSource = ImageDataContext.ImageSource;
        }

        private void ImageListBoxTap(object sender, GestureEventArgs e) {            
            if (e.OriginalSource is Image) {
                var imageItem = (ImageItem)((Image) e.OriginalSource).DataContext;
                SelectionChanged(this, new SelectionChangedEventArgs(new List<ImageItem>(), new List<ImageItem>() { imageItem }));
            }
            
        }

    }
}
