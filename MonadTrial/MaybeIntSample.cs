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
    }
}
