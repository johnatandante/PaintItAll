using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaintItAll.PaintTools
{
    public class CirclePaint : PaintTool
    {

        protected override PaintToolType ToolType
        {
            get { return PaintToolType.CircleTool; }
        }

        public override void UpdatePosition(object sender, System.Windows.Input.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void StartEvent(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void EndEvent(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
