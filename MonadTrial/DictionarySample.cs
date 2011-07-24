using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class DictionarySample
    {
        public static Maybe<T> tryFind<T>(string p, Dictionary<string, T> dict)
        {
            T value = default(T);
            if (dict.TryGetValue(p, out value))
                return new Just<T>(value);
            else
                return new Nothing<T>();
        }
    }
}
