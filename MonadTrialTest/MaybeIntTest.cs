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

        [Test]
        public void tryParseの引数にAを与えるとNothingが返ってくること()
        {
            var result = MaybeIntSample.tryParse("A");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void doMaybeの引数に1と2を与えるとJust3が返ってくること()
        {
            var result = MaybeIntSample.doMaybe("1", "2");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(3));
        }

        [Test]
        public void doMaybeの引数に3と4を与えるとJust7が返ってくること()
        {
            var result = MaybeIntSample.doMaybe("3", "4");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(7));
        }

        [Test]
        public void doMaybeの引数にAと5を与えるとNothingが返ってくること()
        {
            var result = MaybeIntSample.doMaybe("A", "5");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void doMaybeの引数に6とBを与えるとNothingが返ってくること()
        {
            var result = MaybeIntSample.doMaybe("6", "B");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void doMaybeの引数にminus1と7を与えるとJust6が返ってくること()
        {
            var result = MaybeIntSample.doMaybe("-1", "7");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(6));
        }
    }
}
