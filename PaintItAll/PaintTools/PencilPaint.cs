using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaintItAll.PaintTools
{
    public class PencilPaint : CirclePaint
    {

        protected override PaintToolType ToolType
        {
            get { return PaintToolType.PencilTool; }
        }
    }
}
