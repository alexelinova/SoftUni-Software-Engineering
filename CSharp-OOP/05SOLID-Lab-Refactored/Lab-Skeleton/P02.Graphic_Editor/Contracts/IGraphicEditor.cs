namespace P02.Graphic_Editor.Contracts
{
    interface IGraphicEditor
    {
        void DrawShape(IShape shape);

        bool isMatch(IShape shape);
    }
    
}
