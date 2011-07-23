using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class MaybeIntSample
    {
        public static Maybe<int> tryParse(string a)
        {
            var number = 0;
            if (int.TryParse(a, out number))
                return new Just<int>(number);
            else
                return new Nothing<int>();
        }

        public static Maybe<int> doMaybe(string a, string b)
        {
            return Maybe<int>.Bind(tryParse(a), (x) =>
                    Maybe<int>.Bind(tryParse(b), (y) =>
                        Maybe<int>.Return(x + y)));
        }

        public static Maybe<int> doMaybeThis(string a, string b)
        {
            return tryParse(a).Bind((x) =>
                    tryParse(b).Bind((y) =>
                        Maybe<int>.Return(x + y)));
        }
    }
}
