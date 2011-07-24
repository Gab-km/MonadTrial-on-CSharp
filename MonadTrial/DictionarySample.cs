using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class DictionarySample
    {
        public static Maybe<T> tryFind<S, T>(S p, Dictionary<S, T> dict)
        {
            T value = default(T);
            if (dict.TryGetValue(p, out value))
                return new Just<T>(value);
            else
                return new Nothing<T>();
        }

        public static Maybe<int> doMaybe(Dictionary<string, int> dict, string p, string p_2)
        {
            return new Just<int>(3);
        }
    }
}
