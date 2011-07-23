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
            return new Just<int>((int.Parse(a)));
        }
    }
}
