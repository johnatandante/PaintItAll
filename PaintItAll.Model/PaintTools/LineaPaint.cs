
namespace PaintItAll.Model.PaintTools {
    public class LineaPaint : ShapePaint {
        protected override PaintToolType ToolType {
            get { return PaintToolType.PencilTool; }
        }

        public LineaPaint()
            : base(12) {

        }
    }
}
