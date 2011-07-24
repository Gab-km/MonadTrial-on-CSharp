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
            var value = dict[p];
            return new Just<T>(value);
        }
    }
}
