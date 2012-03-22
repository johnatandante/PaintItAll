using System;

namespace PaintItAll.PaintTools
{
    public class BrushPaint : CirclePaint
    {

        protected override PaintToolType ToolType
        {
            get { return PaintToolType.BrushTool; }
        }
    }
}
