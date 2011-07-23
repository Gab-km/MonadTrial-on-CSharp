using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MonadTrial;

namespace MonadTrialTest
{
    public class MaybeStringTest
    {
        [Test]
        public void tryCatの引数にAとBを与えたらJustABが返ってくること()
        {
            var result = MaybeStringSample.tryCat("A", "B");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<string>)));
            Assert.That(Maybe<string>.FromJust(result), Is.EqualTo("AB"));
        }

        [Test]
        public void tryCatの引数にCとDを与えたらJustCDが返ってくること()
        {
            var result = MaybeStringSample.tryCat("C", "D");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<string>)));
            Assert.That(Maybe<string>.FromJust(result), Is.EqualTo("CD"));
        }

        [Test]
        public void tryCatの引数にstringEmptyとEを与えたらNothingが返ってくること()
        {
            var result = MaybeStringSample.tryCat("", "E");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<string>)));
        }

        [Test]
        public void tryCatの引数にnullとFを与えたらNothingが返ってくること()
        {
            var result = MaybeStringSample.tryCat(null, "F");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<string>)));
        }

        [Test]
        public void tryCatの引数にGとstringEmptyを与えたらNothingが返ってくること()
        {
            var result = MaybeStringSample.tryCat("G", "");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<string>)));
        }

        [Test]
        public void tryCatの引数にHとnullを与えたらNothingが返ってくること()
        {
            var result = MaybeStringSample.tryCat("H", null);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<string>)));
        }

        [Test]
        public void doMaybeの引数にAとBを与えたらJustABが返ってくること()
        {
            var result = MaybeStringSample.doMaybe("A", "B");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<string>)));
            Assert.That(Maybe<string>.FromJust(result), Is.EqualTo("AB"));
        }

        [Test]
        public void doMaybeの引数にCとDを与えたらJustCDが返ってくること()
        {
            var result = MaybeStringSample.doMaybe("C", "D");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<string>)));
            Assert.That(Maybe<string>.FromJust(result), Is.EqualTo("CD"));
        }
    }
}
