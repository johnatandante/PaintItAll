﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaintItAll.PaintTools
{
    public class LineaPaint : ShapePaint
    {
        protected override PaintToolType ToolType
        {
            get { return PaintToolType.PencilTool; }
        }

        public LineaPaint() : base(12)
        {
            
        }
    }
}
