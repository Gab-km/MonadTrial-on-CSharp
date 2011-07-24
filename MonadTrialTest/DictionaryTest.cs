using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MonadTrial;

namespace MonadTrialTest
{
    public class DictionaryTest
    {
        [Test]
        public void tryFindの引数にキーとそのキーを持つDictionaryを与えたらJustValueが返ってくること()
        {
            var dict = new Dictionary<string, int>();
            dict.Add("x", 1);
            dict.Add("y", 2);
            dict.Add("z", 3);
            var result = DictionarySample.tryFind("x", dict);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(1));
        }
    }
}
