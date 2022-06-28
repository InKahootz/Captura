using System.Collections.Generic;
using System.Windows.Forms;

namespace Captura.MouseKeyHook
{
    public class MappingGroup
    {
        public List<ModifierStates> On { get; set; } = new List<ModifierStates>();

        public Dictionary<Keys, string> Keys { get; } = new Dictionary<Keys, string>();
    }
}
