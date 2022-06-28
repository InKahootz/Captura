using CommandLine;

namespace Captura
{
    [Verb("list", HelpText = "Display available video sources, encoders, audio sources, etc.")]
    class ListCmdOptions : ICmdlineVerb
    {
        public void Run()
        {
            var lister = ServiceProvider.Get<ConsoleLister>();

            lister.List();
        }
    }
}
