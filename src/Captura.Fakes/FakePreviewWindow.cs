using Captura.Video;

namespace Captura.Fakes
{
    public class FakePreviewWindow : IPreviewWindow
    {
        public void Dispose() { }

        public void Display(IBitmapFrame Frame)
        {
            Frame.Dispose();
        }

        public void Show() { }

        public bool IsVisible => false;
    }
}
