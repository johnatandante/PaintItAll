using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;

namespace PaintItAll.Model.PaintTools {
    public class RectanglePaint : PaintTool {
        private Point firstPosition;
        
        public int StrokeTickness { get; set; }

        public RectanglePaint() {
            StrokeTickness = 12;
        }

        protected override PaintToolType ToolType {
            get { return PaintToolType.ShapeTool; }
        }

        public Rectangle RectangleItem {
            get { return (Rectangle) ShapeItem; }
        }

        public override void StartEvent(object sender, System.Windows.Input.MouseButtonEventArgs e) {

            var childContainer = (Panel) sender;
            var position = e.GetPosition(childContainer);
            firstPosition = position;

            ShapeItem = new Rectangle();

            //rectangle.Fill = null;

            Canvas.SetLeft(RectangleItem, position.X);
            Canvas.SetTop(RectangleItem, position.Y);

            RectangleItem.Height = 0;
            RectangleItem.Width = 0;

            AddNewDebugEllipse(childContainer, position);

        }

        private void AddNewDebugEllipse(Panel childContainer, Point position) {

            var circle = new Ellipse();
            var color = new Color() { A = 1, R = 0, B = 0, G = 0 };
            var brush = new SolidColorBrush(color);
            circle.Stroke = brush;
            circle.StrokeThickness = StrokeTickness;
            circle.Width = StrokeTickness;
            circle.Height = StrokeTickness;
            Canvas.SetLeft(circle, position.X);
            Canvas.SetTop(circle, position.Y);
            childContainer.Children.Add(circle);
        }

        public override void EndEvent(object sender, MouseButtonEventArgs e) {

        }

        public override void UpdatePosition(object sender, MouseEventArgs e) {
            var position = e.GetPosition((Panel) sender);
            var rectangle = ShapeItem as Rectangle;

            var changed = false;
            var w = position.X - firstPosition.X;
            if (w < 0) {
                // sposto il top-left corner 
                Canvas.SetLeft(rectangle, position.X);
                changed = true;
            }

            // sposto il rettangolo
            rectangle.Width = Math.Abs(w);

            var h = position.Y - firstPosition.Y;
            if (h < 0) {
                // sposto il top-left corner 
                Canvas.SetTop(rectangle, position.Y);
                changed = true;
            }
            // sposto il rettangolo
            rectangle.Height = Math.Abs(h);

            if (changed)
                AddNewDebugEllipse((Panel) sender, position);
            // MainPage.Output.Text = string.Format("position: ({0},{1}).({2},{3}) - Color {4}", firstPosition.X, firstPosition.Y, rectangle.Width, rectangle.Height, LastColor.ToString());

        }
    }
}
