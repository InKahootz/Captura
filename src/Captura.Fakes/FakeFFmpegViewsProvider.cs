using System;
using Captura.FFmpeg;

namespace Captura.Fakes
{
    class FakeFFmpegViewsProvider : IFFmpegViewsProvider
    {
        public void ShowLogs()
        {
        }

        public void ShowUnavailable()
        {
            Console.Error.WriteLine("FFmpeg is not available.\nYou can install ffmpeg by calling: captura ffmpeg --install [path]");
        }

        public void ShowDownloader()
        {
        }

        public void PickFolder()
        {
        }
    }
}
