using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MonadTrial;

namespace MonadTrialTest
{
    public class MonadLawsOnMaybeString
    {
        [Test]
        public void MaybeStringtがMonad則その1を満たすこと()
        {
            // return x >>= f === f x
            Func<string, Maybe<string>> f = (x) =>
            {
                if (string.IsNullOrEmpty(x))
                {
                    return new Nothing<string>();
                }
                else
                {
                    return new Just<string>(x + x.ToLower());
                }
            };
            var value = "A";
            var lefthand = Maybe<string>.Bind(Maybe<string>.Return(value), f);
            var righthand = f(value);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(Maybe<string>.FromJust(lefthand), Is.EqualTo(Maybe<string>.FromJust(righthand)));
        }
    }
}
