using P02.Graphic_Editor.Contracts;
using System;

namespace P02.Graphic_Editor.GraphicEditors
{
    class RectangleGraphicEditor : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public bool isMatch(IShape shape)
        {
            return shape is Rectangle;
        }
    }
}
