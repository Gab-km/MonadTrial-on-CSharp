using NUnit.Framework;
using MonadTrial;

namespace MonadTrialTest
{
    public class MonadLawsOnMaybeInt
    {
        private Maybe<int> f(int x)
        {
            if (x < 0)
                return new Nothing<int>();
            else
                return new Just<int>(x * 2);
        }

        private Maybe<int> g(int x)
        {
            if (x < 0)
                return new Nothing<int>();
            else
                return new Just<int>(x * 3);
        }

        private Maybe<int> h(int x)
        {
            if (x < 0)
                return new Nothing<int>();
            else
                return new Just<int>(x);
        }
            
        [Test]
        public void MaybeIntがMonad則その1を満たすこと()
        {
            // return x >>= f === f x
            var lefthand = Maybe<int>.Bind(Maybe<int>.Return(1), f);
            var righthand = f(1);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(Maybe<int>.FromJust(lefthand), Is.EqualTo(Maybe<int>.FromJust(righthand)));
        }

        [Test]
        public void MaybeIntがMonad則その2を満たすこと()
        {
            // m >>= return === m
            var m = f(1);
            var lefthand = Maybe<int>.Bind(m, Maybe<int>.Return);
            var righthand = m;
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(Maybe<int>.FromJust(lefthand), Is.EqualTo(Maybe<int>.FromJust(righthand)));
        }

        [Test]
        public void MaybeIntがMonad則その3を満たすこと()
        {
            // m >>= (\x -> f x >>= g) === (m >>= f) >>= g
            var m = h(1);
            var lefthand = Maybe<int>.Bind(m, (x) => Maybe<int>.Bind(f(x), g));
            var righthand = Maybe<int>.Bind(Maybe<int>.Bind(m, f), g);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(Maybe<int>.FromJust(lefthand), Is.EqualTo(Maybe<int>.FromJust(righthand)));
        }

        [Test]
        public void MaybeInt_NothingがMonad則その1を満たすこと()
        {
            // return x >>= f === f x
            var value = -1;
            var lefthand = Maybe<int>.Bind(Maybe<int>.Return(value), f);
            var righthand = f(value);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
        }

        [Test]
        public void MaybeInt_NothingがMonad則その2を満たすこと()
        {
            // m >>= return === m
            var m = f(-1);
            var lefthand = Maybe<int>.Bind(m, Maybe<int>.Return);
            var righthand = m;
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
        }

        [Test]
        public void MaybeInt_NothingがMonad則その3を満たすこと()
        {
            // m >>= (\x -> f x >>= g) === (m >>= f) >>= g
            var m = h(-1);
            var lefthand = Maybe<int>.Bind(m, (x) => Maybe<int>.Bind(f(x), g));
            var righthand = Maybe<int>.Bind(Maybe<int>.Bind(m, f), g);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
        }
    }
}
