using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class Just<T>
    {
        private int p;

        public Just(int a)
        {
            this.Value = a;
        }

        public object Value { get; set; }
    }
}
