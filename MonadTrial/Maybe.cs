using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class Maybe<T>
    {
        public object Value { get; set; }
    }

    public class Just<T> : Maybe<T>
    {
        public Just(int a)
        {
            this.Value = a;
        }
    }

    public class Nothing<T> : Maybe<T>
    {
    }
}
