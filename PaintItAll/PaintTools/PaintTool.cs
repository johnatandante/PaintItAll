using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintItAll.PaintTools
{
    public abstract class PaintTool
    {
        protected Shape ShapeItem;
        protected Color LastColor;

        public abstract void UpdatePosition(object sender, MouseEventArgs e);
        public abstract void StartEvent(object sender, MouseButtonEventArgs e);
        public abstract void EndEvent(object sender, MouseButtonEventArgs e);

        public static PaintTool GetPaintTool(PaintToolType paintToolType)
        {
            switch (paintToolType)
            {
                case PaintToolType.GradientTool:
                    return new GradientPaint();
                case PaintToolType.LineaTool:
                    return new LineaPaint();
                case PaintToolType.PencilTool:
                    return new PencilTool();
                case PaintToolType.SolidTool:
                    return new SolidPaint();
                default:
                    throw new Exception("Non supportato");
            }
        }


    }


}
