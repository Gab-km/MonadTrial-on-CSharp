﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class MaybeStringSample
    {
        public static Maybe<string> tryCat(string a, string b)
        {
            if (a == "")
                return new Nothing<string>();
            else
                return new Just<string>(a + b);
        }
    }
}
