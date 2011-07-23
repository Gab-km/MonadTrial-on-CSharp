using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class MaybeStringSample
    {
        public static Maybe<string> tryCat(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
                return new Nothing<string>();
            else if (string.IsNullOrEmpty(b))
                return new Nothing<string>();
            else
                return new Just<string>(a + b);
        }

        public static Maybe<string> maybe(string a)
        {
            if (string.IsNullOrEmpty(a))
                return new Nothing<string>();
            else
                return new Just<string>(a);
        }

        public static Maybe<string> doMaybe(string a, string b)
        {
            return Maybe<string>.Bind(maybe(a), (x) =>
                    Maybe<string>.Bind(maybe(b), (y) =>
                        Maybe<string>.Return(x + y)));
        }

        public static Maybe<string> doMaybeThis(string a, string b)
        {
            return maybe(a).Bind((x) =>
                    maybe(b).Bind((y) =>
                        Maybe<string>.Return(x + y)));
        }
    }
}
