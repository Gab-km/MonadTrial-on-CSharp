﻿using System;
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
            var result = MaybeNatSample.tryAdd(1, 2);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(3));
        }

        [Test]
        public void tryAddの引数に3と4を与えたらJust7が返ってくること()
        {
            var result = MaybeNatSample.tryAdd(3, 4);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(7));
        }

        [Test]
        public void tryAddの引数にminus1と4を与えたらNothingが返ってくること()
        {
            var result = MaybeNatSample.tryAdd(-1, 4);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void tryAddの引数に5とminus2を与えたらNothingが返ってくること()
        {
            var result = MaybeNatSample.tryAdd(5, -2);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void doMaybeNestの引数に1と2を与えたらJust3が返ってくること()
        {
            var result = MaybeNatSample.doMaybeNest(1, 2);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(3));
        }

        [Test]
        public void doMaybeNestの引数に3と4を与えたらJust7が返ってくること()
        {
            var result = MaybeNatSample.doMaybeNest(3, 4);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(7));
        }

        [Test]
        public void doMaybeNestの引数にminus1と4を与えたらNothingが返ってくること()
        {
            var result = MaybeNatSample.doMaybeNest(-1, 4);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void doMaybeNestの引数に5とminus2を与えたらNothingが返ってくること()
        {
            var result = MaybeNatSample.doMaybeNest(5, -2);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void doMaybeThisの引数に1と2を与えたらJust3が返ってくること()
        {
            var result = MaybeNatSample.doMaybeThis(1, 2);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(3));
        }

        [Test]
        public void doMaybeThisの引数に3と4を与えたらJust7が返ってくること()
        {
            var result = MaybeNatSample.doMaybeThis(3, 4);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Just<int>)));
            Assert.That(Maybe<int>.FromJust(result), Is.EqualTo(7));
        }

        [Test]
        public void doMaybeThisの引数にminus1と4を与えたらNothingが返ってくること()
        {
            var result = MaybeNatSample.doMaybeThis(-1, 4);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void doMaybeThisの引数に5とminus2を与えたらNothingが返ってくること()
        {
            var result = MaybeNatSample.doMaybeThis(5, -2);
            Assert.That(result.GetType(), Is.EqualTo(typeof(Nothing<int>)));
        }

        [Test]
        public void Just5から価を取り出したら5が返ってくること()
        {
            var just5 = new Just<int>(5);
            Assert.That(just5.Value, Is.EqualTo(5));
            Assert.That(Just<int>.FromJust(just5), Is.EqualTo(5));
        }
    }
}
