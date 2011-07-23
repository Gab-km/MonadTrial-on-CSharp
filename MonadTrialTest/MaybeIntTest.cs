using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MonadTrial;

namespace MonadTrialTest
{
    public class MaybeIntTest
    {
        [Test]
        public void tryParseの引数に1を与えるとJust1が返ってくること()
        {
            var result = MaybeIntSample.tryParse("1");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(1));
        }

        [Test]
        public void tryParseの引数にminus1を与えるとJustMinus1が返ってくること()
        {
            var result = MaybeIntSample.tryParse("-1");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(-1));
        }
    }
}
