using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public class Maybe<T>
    {
        public T Value { get; set; }

        public static Maybe<A> Return<A>(A a)
        {
            return new Just<A>(a);
        }

        public static Maybe<B> Bind<A, B>(Maybe<A> ma, Func<A, Maybe<B>> amb)
        {
            return amb(ma.Value);
        }
    }

    public class Just<T> : Maybe<T>
    {
        public Just(T a)
        {
            this.Value = a;
        }
    }

    public class Nothing<T> : Maybe<T>
    {
    }
}
