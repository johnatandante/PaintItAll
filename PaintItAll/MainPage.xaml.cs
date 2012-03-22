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
        private PaintTool currentPaintTool = null;

        List<PaintTool> paintToolCollection = new List<PaintTool>();

        public MainPage()
        {
            InitializeComponent();

        }

        private void MainCanvasMouseMove(object sender, MouseEventArgs e)
        {
            currentPaintTool = (PaintTool)Toolbar.SelectedItem;
            if (currentPaintTool == null) return;
            currentPaintTool.UpdatePosition(MainCanvas, e);

        }

        private void PhoneApplicationPageLoaded(object sender, RoutedEventArgs e)
        {
            // todo
            Toolbar.ItemsSource = paintToolCollection;

            paintToolCollection.AddRange(PaintTool.GetTools());
            Toolbar.SelectedIndex = 0;
        }


        private void MainCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            currentPaintTool = (PaintTool)Toolbar.SelectedItem;
            if (currentPaintTool == null) return;
            currentPaintTool.StartEvent(MainCanvas, e);

        }

        private void MainCanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // _lastLine = null;
        }

        private void ImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try {
                var icon = (Image) sender;
                //currentPaintTool =
                //    PaintTool.GetNewPaintTool((PaintToolType) Enum.Parse(typeof (PaintToolType), icon.Name, true));
            } catch(Exception exc) {
                MessageBox.Show(exc.Message, "Attenzione", MessageBoxButton.OK);
                
            }
        }

        private void Toolbar_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Image_Tap(object sender, GestureEventArgs e)
        {
            try
            {
                var icon = (Image)sender;
                //currentPaintTool =
                //    PaintTool.GetNewPaintTool((PaintToolType) Enum.Parse(typeof (PaintToolType), icon.Name, true));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Attenzione", MessageBoxButton.OK);

            }
        }
    }
}
