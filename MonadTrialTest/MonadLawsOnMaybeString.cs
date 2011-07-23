﻿using System;
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
        public void MaybeStringがMonad則その1を満たすこと()
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

        [Test]
        public void MaybeStringがMonad則その2を満たすこと()
        {
            // m >>= return === m
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
            var m = f("A");
            var lefthand = Maybe<string>.Bind(m, Maybe<string>.Return);
            var righthand = m;
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(Maybe<string>.FromJust(lefthand), Is.EqualTo(Maybe<string>.FromJust(righthand)));
        }

        [Test]
        public void MaybeStringがMonad則その3を満たすこと()
        {
            // m >>= (\x -> f x >>= g) === (m >>= f) >>= g
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
            Func<string, Maybe<string>> g = (x) =>
            {
                if (string.IsNullOrEmpty(x))
                {
                    return new Nothing<string>();
                }
                else
                {
                    return new Just<string>(x + x);
                }
            };
            Func<string, Maybe<string>> h = (x) =>
            {
                if (string.IsNullOrEmpty(x))
                {
                    return new Nothing<string>();
                }
                else
                {
                    return new Just<string>(x);
                }
            };
            var m = h("A");
            var lefthand = Maybe<string>.Bind(m, (x) => Maybe<string>.Bind(f(x), g));
            var righthand = Maybe<string>.Bind(Maybe<string>.Bind(m, f), g);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(Maybe<string>.FromJust(lefthand), Is.EqualTo(Maybe<string>.FromJust(righthand)));
        }
    }
}
