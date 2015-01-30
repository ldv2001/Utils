using System;

namespace Utils.Misc
{
    public static class TupleExtensions
    {

        public static T Left<T, T1>(this Tuple<T, T1> t)
        {
            return t.Item1;
        }

        public static T1 Right<T, T1>(this Tuple<T, T1> t)
        {
            return t.Item2;
        }
    }
}
