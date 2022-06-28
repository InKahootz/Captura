using SharpDX;

namespace Captura.Windows.DesktopDuplication
{
    class DeskDuplOutputEntry
    {
        public DeskDuplOutputEntry(DuplCapture duplCapture)
        {
            DuplCapture = duplCapture ?? throw new System.ArgumentNullException(nameof(duplCapture));
        }

        public Point Location { get; set; }

        public DuplCapture DuplCapture { get; }

        public DxMousePointer? MousePointer { get; set; }
    }
}
