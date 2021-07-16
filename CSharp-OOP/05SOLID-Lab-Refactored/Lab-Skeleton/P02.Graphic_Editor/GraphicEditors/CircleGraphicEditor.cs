using P02.Graphic_Editor.Contracts;
using System;

namespace P02.Graphic_Editor.GraphicEditors
{
    class CircleGraphicEditor : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine("Drawing circle");
        }

        public bool isMatch(IShape shape)
        {
            return shape is Circle;
        }
    }
}
