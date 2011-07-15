using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MonadTrial;

namespace MonadTrialTest
{
    public class MonadLawsOnMaybe
    {
        [Test]
        public void MaybeIntがMonad即その1を満たすこと()
        {
            // return x >>= f === f x
            Func<int, Maybe<int>> f = (x) =>
                {
                    if (x < 0)
                    {
                        return new Nothing<int>();
                    }
                    else
                    {
                        return new Just<int>(x * 2);
                    }
                };
            var lefthand = Maybe<int>.Bind(Maybe<int>.Return(1), f);
            var righthand = f(1);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(lefthand.Value, Is.EqualTo(righthand.Value));
        }
    }
}
