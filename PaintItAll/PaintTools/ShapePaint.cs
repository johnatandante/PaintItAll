using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintItAll.PaintTools
{
    public class ShapePaint : PaintTool
    {

        protected override PaintToolType ToolType
        {
            get { return PaintToolType.ShapeTool; }
        }

        public int StrokeTickness { get; set; }

        public Line LineItem
        {
            get { return (Line) ShapeItem; }
        }

        public ShapePaint(int strokeTickness = 24)
        {
            StrokeTickness = strokeTickness;

        }

        public override void UpdatePosition(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition((UIElement) sender);
            LineItem.X2 = position.X;
            LineItem.Y2 = position.Y;

            // Console.WriteLine("position: ", _lastLine.X1, _lastLine.X2, _lastLine.Y1, _lastLine.Y2 , " - Color ", _lastColor.ToString());
            // output.Text = string.Format("position: ({0},{2}).({1},{3}) - Color {4}", _lastLine.X1, _lastLine.X2, _lastLine.Y1, _lastLine.Y2, _lastColor.ToString());
        }

        public override void StartEvent(object sender, MouseButtonEventArgs e)
        {
            var childContainer = (Panel) sender;
            var position = e.GetPosition((UIElement)sender);
            ShapeItem = new Line();
            LineItem.X1 = position.X;
            LineItem.Y1 = position.Y;
            LineItem.X2 = position.X;
            LineItem.Y2 = position.Y;

            var endColor = new Color();
            var random = new Random();
            endColor.R = (byte)random.Next(0, 255);
            endColor.G = (byte)random.Next(0, 255);
            endColor.B = (byte)random.Next(0, 255);
            endColor.A = (byte)random.Next(100, 255);

            LineItem.Stroke = new RadialGradientBrush(LastColor, endColor);
            //lastLine.Stroke = new SolidColorBrush(lastColor);
            LineItem.StrokeThickness = StrokeTickness;
            childContainer.Children.Add(LineItem);

            LastColor = endColor;
        }

        public override void EndEvent(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

    }
}
