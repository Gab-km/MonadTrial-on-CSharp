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

        public static Maybe<string> doMaybe(string a, string b)
        {
            return new Just<string>(a + b);
        }
    }
}
