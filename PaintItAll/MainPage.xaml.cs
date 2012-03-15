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
        private Color _lastColor = new Color();
        private PaintTool currentPaintTool = null;

        public MainPage()
        {
            InitializeComponent();
        }

        private void MainCanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (currentPaintTool == null) return;
            currentPaintTool.UpdatePosition(sender, e);

        }

        private void PhoneApplicationPageLoaded(object sender, RoutedEventArgs e)
        {
            // todo
        }


        private void MainCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currentPaintTool == null) return;
            currentPaintTool.StartEvent(sender, e);

        }

        private void MainCanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _lastLine = null;
        }

        private void ImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try {
                var icon = (Image) sender;
                currentPaintTool =
                    PaintTool.GetPaintTool((PaintToolType) Enum.Parse(typeof (PaintToolType), icon.Name, true));
            } catch(Exception exc) {
                MessageBox.Show(exc.Message, "Attenzione", MessageBoxButton.OK);
                
            }
        }
    }
}
