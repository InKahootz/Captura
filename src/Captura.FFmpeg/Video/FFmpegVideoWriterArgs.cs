using Captura.Video;

namespace Captura.FFmpeg
{
    class FFmpegVideoWriterArgs : VideoWriterArgs
    {
        public static FFmpegVideoWriterArgs FromVideoWriterArgs(VideoWriterArgs Args, FFmpegVideoCodec VideoCodec)
        {
            return new FFmpegVideoWriterArgs(Args.ImageProvider, Args.AudioProvider, Args.FileName)
            {
                FrameRate = Args.FrameRate,
                VideoQuality = Args.VideoQuality,
                VideoCodec = VideoCodec,
                AudioQuality = Args.AudioQuality,
            };
        }

        public FFmpegVideoWriterArgs(IImageProvider imageProvider, Audio.IAudioProvider? audioProvider, string fileName)
            : base(imageProvider, audioProvider, fileName)
        { }

        public FFmpegVideoCodec? VideoCodec { get; set; }
        public int Frequency { get; set; } = 44100;
        public int Channels { get; set; } = 2;
    }
}
