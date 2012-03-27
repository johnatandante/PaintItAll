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
    public partial class PaintPage : PhoneApplicationPage
    {

        List<PaintTool> paintToolCollection = new List<PaintTool>();
        private PaintTool currentPaintTool = new PaintTools.LineaPaint();

        public PaintPage()
        {
            InitializeComponent();
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}