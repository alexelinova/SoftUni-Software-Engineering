using P02.Graphic_Editor.Contracts;
using System;

namespace P02.Graphic_Editor.GraphicEditors
{
    class SquareGraphicEditor : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine("Draw rectangle");
        }

        public bool isMatch(IShape shape)
        {
            return shape is Square;
        }
    }
}
