using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class MaybeNatSample
    {
        public static Maybe<int> tryAdd(int a, int b)
        {
            if (a < 0)
                return new Nothing<int>();
            else if (b < 0)
                return new Nothing<int>();
            else
                return new Just<int>(a + b);
        }

        public static Maybe<int> doMaybeNest(int a, int b)
        {
            return new Just<int>(a + b);
        }
    }
}
