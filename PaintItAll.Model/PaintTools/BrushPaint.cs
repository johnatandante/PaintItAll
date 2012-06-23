using System;

namespace PaintItAll.Model.PaintTools {
    public class BrushPaint : CirclePaint {

        protected override PaintToolType ToolType {
            get { return PaintToolType.BrushTool; }
        }
    }
}
