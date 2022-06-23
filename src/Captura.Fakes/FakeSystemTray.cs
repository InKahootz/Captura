using System;
using Captura.Loc;
using Captura.Models;

namespace Captura.Fakes
{
    class FakeSystemTray : ISystemTray
    {
        readonly ILocalizationProvider _loc;

        public FakeSystemTray(ILocalizationProvider Loc)
        {
            _loc = Loc;
        }

        public void HideNotification() { }

        public void ShowScreenShotNotification(string FilePath)
        {
                    Console.WriteLine($"{_loc.ScreenShotSaved}: {FilePath}");
        }

        public void ShowNotification(INotification Notification) { }
    }
}
