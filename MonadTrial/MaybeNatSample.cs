using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class MaybeNatSample
    {
        public static Just<int> tryAdd(int p, int p_2)
        {
            return new Just<int>(3);
        }
    }
}
