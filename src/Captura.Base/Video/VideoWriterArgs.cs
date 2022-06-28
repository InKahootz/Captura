using System;

using Captura.Audio;

namespace Captura.Video
{
    public class VideoWriterArgs
    {
        public VideoWriterArgs(IImageProvider imageProvider, IAudioProvider? audioProvider, string fileName)
        {
            if (imageProvider is null)
            {
                throw new ArgumentNullException(nameof(imageProvider));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"'{nameof(fileName)}' cannot be null or empty.", nameof(fileName));
            }

            ImageProvider = imageProvider;
            AudioProvider = audioProvider;
            FileName = fileName;
        }
        public string FileName { get; }
        public IImageProvider ImageProvider { get; }
        public int FrameRate { get; set;  } = 15;
        public int VideoQuality { get; set; } = 70;
        public int AudioQuality { get; set; } = 50;
        public IAudioProvider? AudioProvider { get; }
    }
}
