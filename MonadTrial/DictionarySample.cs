﻿using System.Collections.Generic;

namespace MonadTrial
{
    public class DictionarySample
    {
        public static Maybe<T> tryFind<S, T>(S a, Dictionary<S, T> dict)
        {
            T value = default(T);
            if (dict.TryGetValue(a, out value))
                return new Just<T>(value);
            else
                return new Nothing<T>();
        }

        public static Maybe<int> doMaybe(Dictionary<string, int> dict, string a, string b)
        {
            return Maybe<int>.Bind(tryFind(a, dict), (x) =>
                    Maybe<int>.Bind(tryFind(b, dict), (y) =>
                        Maybe<int>.Return(x + y)));
        }

        public static Maybe<int> doMaybeThis(Dictionary<string, int> dict, string a, string b)
        {
            return tryFind(a, dict).Bind((x) =>
                    tryFind(b, dict).Bind((y) =>
                        Maybe<int>.Return(x + y)));
        }
    }
}
