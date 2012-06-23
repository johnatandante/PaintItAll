
namespace PaintItAll.Model.PaintTools
{
    public class PencilPaint : CirclePaint
    {

        protected override PaintToolType ToolType
        {
            get { return PaintToolType.PencilTool; }
        }
    }
}
