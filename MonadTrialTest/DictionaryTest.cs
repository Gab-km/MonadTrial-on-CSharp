using System.Collections.Generic;
using NUnit.Framework;
using MonadTrial;

namespace MonadTrialTest
{
    public class DictionaryTest
    {
        Dictionary<string, int> dict;

        [SetUp]
        public void setUp()
        {
            dict = new Dictionary<string, int>();
            dict.Add("x", 1);
            dict.Add("y", 2);
            dict.Add("z", 3);
        }

        [Test]
        public void tryFindの引数にxとxをキーを持つDictionaryを与えたらJust1が返ってくること()
        {
            var result = DictionarySample.tryFind("x", dict);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(1));
        }

        [Test]
        public void tryFindの引数にyとyをキーに持つDictionaryを与えたらJust2が返ってくること()
        {
            var result = DictionarySample.tryFind("y", dict);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(2));
        }

        [Test]
        public void tryFindの引数にwとwをキーに持たないDictionaryを与えたらNothingが返ってくること()
        {
            var result = DictionarySample.tryFind("w", dict);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void doMaybeにxとyを与えるとJust3が返ってくること()
        {
            var result = DictionarySample.doMaybe(dict, "x", "y");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(3));
        }

        [Test]
        public void doMaybeにyとzを与えるとJust5が返ってくること()
        {
            var result = DictionarySample.doMaybe(dict, "y", "z");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(5));
        }

        [Test]
        public void doMaybeにzとwを与えるとNothingが返ってくること()
        {
            var result = DictionarySample.doMaybe(dict, "z", "w");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void doMaybeThisにxとyを与えるとJust3が返ってくること()
        {
            var result = DictionarySample.doMaybeThis(dict, "x", "y");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(3));
        }

        [Test]
        public void doMaybeThisにyとzを与えるとJust5が返ってくること()
        {
            var result = DictionarySample.doMaybeThis(dict, "y", "z");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(5));
        }

        [Test]
        public void doMaybeThisにzとwを与えるとNothingが返ってくること()
        {
            var result = DictionarySample.doMaybeThis(dict, "z", "w");
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }
    }
}
