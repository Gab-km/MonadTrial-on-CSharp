using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class MaybeNatSample
    {
        public static Just<int> tryAdd(int a, int b)
        {
            return new Just<int>(a + b);
        }
    }
}
