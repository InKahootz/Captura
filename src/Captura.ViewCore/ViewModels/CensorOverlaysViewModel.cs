using Captura.Video;

namespace Captura.ViewModels
{
    public class CensorOverlaysViewModel : OverlayListViewModel<CensorOverlaySettings>
    {
        public CensorOverlaysViewModel(Settings Settings) : base(Settings.Censored)
        {
        }
    }
}
