namespace Captura.Audio
{
    public class WaveItem : IAudioWriterItem
    {
        public string Name { get; } = "Wave";
        public string Extension { get; } = ".wav";

        public IAudioFileWriter GetAudioFileWriter(string FileName, WaveFormat Wf, int AudioQuality)
        {
            return new AudioFileWriter(FileName, Wf);
        }
    }
}
