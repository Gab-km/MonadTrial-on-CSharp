using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MonadTrial;

namespace MonadTrialTest
{
    public class MaybeNatTest
    {
        [Test]
        public void tryAddの引数に1と2を与えたらJust3が返ってくること()
        {
            var expected = new Just<int>(3);
            var result = MaybeNatSample.tryAdd(1, 2);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(result.Value, Is.EqualTo(expected.Value));
        }

        [Test]
        public void tryAddの引数に3と4を与えたらJust7が返ってくること()
        {
            var expected = new Just<int>(7);
            var result = MaybeNatSample.tryAdd(3, 4);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(result.Value, Is.EqualTo(expected.Value));
        }
    }
}
