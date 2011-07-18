using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonadTrial
{
    public abstract class Maybe<T>
    {
        internal T value;
        public abstract T Value { get; }

        public static Maybe<A> Return<A>(A a)
        {
            return new Just<A>(a);
        }

        public static Maybe<B> Bind<A, B>(Maybe<A> ma, Func<A, Maybe<B>> amb)
        {
            return ma.Bind(amb);
        }

        public static T FromJust(Maybe<T> ma)
        {
            return ma.Value;
        }

        public abstract Maybe<B> Bind<B>(Func<T, Maybe<B>> amb);
    }

    public class Just<T> : Maybe<T>
    {
        public override T Value
        {
            get
            {
                return this.value;
            }
        }

        public Just(T a)
        {
            this.value = a;
        }

        public override Maybe<B> Bind<B>(Func<T, Maybe<B>> amb)
        {
            return amb(this.value);
        }
    }

    public class Nothing<T> : Maybe<T>
    {
        public override T Value
        {
            get
            {
                throw new NullReferenceException("Nothing has no value.");
            }
        }

        public override Maybe<B> Bind<B>(Func<T, Maybe<B>> amb)
        {
            return new Nothing<B>();
        }
    }
}
