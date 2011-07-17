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
        public void MaybeIntがMonad則その1を満たすこと()
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

        [Test]
        public void MaybeIntがMonad則その2を満たすこと()
        {
            // m >>= return === m
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
            var m = f(1);
            var lefthand = Maybe<int>.Bind(m, Maybe<int>.Return);
            var righthand = m;
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(lefthand.Value, Is.EqualTo(righthand.Value));
        }

        [Test]
        public void MaybeIntがMonad則その3を満たすこと()
        {
            // m >>= (\x -> f x >>= g) === (m >>= f) >>= g
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
            Func<int, Maybe<int>> g = (x) =>
                {
                    if (x < 0)
                    {
                        return new Nothing<int>();
                    }
                    else
                    {
                        return new Just<int>(x * 3);
                    }
                };
            Func<int, Maybe<int>> h = (x) =>
                {
                    if (x < 0)
                    {
                        return new Nothing<int>();
                    }
                    else
                    {
                        return new Just<int>(x);
                    }
                };
            var m = h(1);
            var lefthand = Maybe<int>.Bind(m, (x) => Maybe<int>.Bind(f(x), g));
            var righthand = Maybe<int>.Bind(Maybe<int>.Bind(m, f), g);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(lefthand.Value, Is.EqualTo(righthand.Value));
        }

        [Test]
        public void MaybeInt_NothingがMonad則その1を満たすこと()
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
            var value = -1;
            var lefthand = Maybe<int>.Bind(Maybe<int>.Return(value), f);
            var righthand = f(value);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(lefthand.Value, Is.EqualTo(righthand.Value));
        }

        [Test]
        public void MaybeInt_NothingがMonad則その2を満たすこと()
        {
            // m >>= return === m
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
            var m = f(-1);
            var lefthand = Maybe<int>.Bind(m, Maybe<int>.Return);
            var righthand = m;
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(lefthand.Value, Is.EqualTo(righthand.Value));
        }

        [Test]
        public void MaybeInt_NothingがMonad則その3を満たすこと()
        {
            // m >>= (\x -> f x >>= g) === (m >>= f) >>= g
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
            Func<int, Maybe<int>> g = (x) =>
            {
                if (x < 0)
                {
                    return new Nothing<int>();
                }
                else
                {
                    return new Just<int>(x * 3);
                }
            };
            Func<int, Maybe<int>> h = (x) =>
            {
                if (x < 0)
                {
                    return new Nothing<int>();
                }
                else
                {
                    return new Just<int>(x);
                }
            };
            var m = h(-1);
            var lefthand = Maybe<int>.Bind(m, (x) => Maybe<int>.Bind(f(x), g));
            var righthand = Maybe<int>.Bind(Maybe<int>.Bind(m, f), g);
            Assert.That(lefthand.GetType(), Is.EqualTo(righthand.GetType()));
            Assert.That(lefthand.Value, Is.EqualTo(righthand.Value));
        }
    }
}
