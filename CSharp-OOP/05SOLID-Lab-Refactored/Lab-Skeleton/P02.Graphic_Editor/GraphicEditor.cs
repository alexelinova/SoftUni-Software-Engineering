using P02.Graphic_Editor.Contracts;
using P02.Graphic_Editor.GraphicEditors;
using System.Collections.Generic;
using System.Linq;

namespace P02.Graphic_Editor
{
    public abstract class GraphicEditor
    {
        private List<IGraphicEditor> graphEditors = new List<IGraphicEditor>()
        {
            new CircleGraphicEditor(),
            new RectangleGraphicEditor(),
            new SquareGraphicEditor()
        };
        public void DrawShape(IShape shape)
        {
            IGraphicEditor graphicEditor = graphEditors.First(d => d.isMatch(shape));
            graphicEditor.DrawShape(shape);
        }
    }
}
