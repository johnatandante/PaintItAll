using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace PaintItAll.PaintTools
{
    public abstract class PaintTool
    {
        protected Shape ShapeItem;
        protected Color LastColor;

        protected abstract PaintToolType ToolType { get; }

        
        public virtual Uri IconUri
        {
            get { return new Uri(string.Format("./Resources/{0}.png", ToolType), UriKind.RelativeOrAbsolute); }
        }

        public abstract void UpdatePosition(object sender, MouseEventArgs e);
        public abstract void StartEvent(object sender, MouseButtonEventArgs e);
        public abstract void EndEvent(object sender, MouseButtonEventArgs e);

        public static PaintTool GetNewPaintTool(PaintToolType paintToolType)
        {
            switch (paintToolType)
            {
                case PaintToolType.BrushTool:   return new BrushPaint();
                case PaintToolType.LineaTool:   return new LineaPaint();
                case PaintToolType.PencilTool:  return new PencilPaint();
                case PaintToolType.ShapeTool:   return new ShapePaint();
                case PaintToolType.CircleTool:  return new CirclePaint();
                default:
                    throw new Exception("Non supportato");
            }
        }

        public static IEnumerable<PaintTool> GetTools() {
            return new PaintTool[] {
                    GetNewPaintTool(PaintToolType.LineaTool),
                    GetNewPaintTool(PaintToolType.PencilTool),
                    GetNewPaintTool(PaintToolType.BrushTool),
                    GetNewPaintTool(PaintToolType.CircleTool),
                    GetNewPaintTool(PaintToolType.ShapeTool)
                    };
        }

    }


}
