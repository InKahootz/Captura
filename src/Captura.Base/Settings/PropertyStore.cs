using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Captura
{
    public abstract class PropertyStore : NotifyPropertyChanged
    {
        readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        [return: NotNullIfNotNull("Default")]
        protected T? Get<T>(T? Default = default, [CallerMemberName] string PropertyName = "")
        {
            lock (_dictionary)
            {
                if (_dictionary.TryGetValue(PropertyName, out var obj) && obj is T val)
                {
                    return val;
                }
            }

            return Default;
        }

        protected void Set<T>(T Value, [CallerMemberName] string PropertyName = "")
            where T : notnull
        {
            lock (_dictionary)
            {
                if (_dictionary.ContainsKey(PropertyName))
                {
                    _dictionary[PropertyName] = Value;
                }
                else _dictionary.Add(PropertyName, Value);
            }

            OnPropertyChanged(PropertyName);
        }
    }
}
