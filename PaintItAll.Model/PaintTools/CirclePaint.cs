using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintItAll.Model.PaintTools {
    public class CirclePaint : PaintTool {

        public const int StrokeTickness = 12;
        public const int Size = 24;

        public Ellipse EllipseItem {
            get { return (Ellipse) ShapeItem; }
        }

        protected override PaintToolType ToolType {
            get { return PaintToolType.CircleTool; }
        }

        public override void UpdatePosition(object sender, System.Windows.Input.MouseEventArgs e) {
            var childContainer = (Panel) sender;
            var position = e.GetPosition((UIElement) sender);

            ShapeItem = new Ellipse();

            EllipseItem.Height = Size;
            EllipseItem.Width = Size;

            var endColor = new Color();
            var random = new Random();
            endColor.R = (byte) random.Next(0, 255);
            endColor.G = (byte) random.Next(0, 255);
            endColor.B = (byte) random.Next(0, 255);
            endColor.A = (byte) random.Next(100, 255);

            EllipseItem.Stroke = new RadialGradientBrush(LastColor, endColor);
            //lastLine.Stroke = new SolidColorBrush(lastColor);
            EllipseItem.StrokeThickness = StrokeTickness;
            Canvas.SetLeft(EllipseItem, position.X);
            Canvas.SetTop(EllipseItem, position.Y);

            childContainer.Children.Add(EllipseItem);

            LastColor = endColor;
        }

        public override void StartEvent(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            // do nothing
        }

        public override void EndEvent(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            // do nothing
        }

    }
}
