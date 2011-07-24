
namespace MonadTrial
{
    public class MaybeNatSample
    {
        public static Maybe<int> tryAdd(int a, int b)
        {
            if (a < 0)
                return new Nothing<int>();
            else if (b < 0)
                return new Nothing<int>();
            else
                return new Just<int>(a + b);
        }

        public static Maybe<int> doMaybe(int a, int b)
        {
            return Maybe<int>.Bind(maybe(a), (x) =>
                    Maybe<int>.Bind(maybe(b), (y) =>
                        Maybe<int>.Return(x + y)));
        }

        private static Maybe<int> maybe(int x)
        {
            if (x < 0)
                return new Nothing<int>();
            else
                return new Just<int>(x);
        }

        public static Maybe<int> doMaybeThis(int a, int b)
        {
            return maybe(a).Bind((x) =>
                    maybe(b).Bind((y) =>
                        Maybe<int>.Return(x + y)));
        }
    }
}
