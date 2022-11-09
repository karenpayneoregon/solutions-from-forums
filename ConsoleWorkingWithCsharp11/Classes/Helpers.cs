using System.Numerics;

namespace ConsoleWorkingWithCsharp11.Classes;

public class Helpers
{
    public interface IAddable<T> where T : IAddable<T>
    {
        static abstract T Zero { get; }
        static abstract T operator +(T t1, T t2);
    }

    public static  T Sum<T>(T[] values) where T : INumber<T>
    {

        T result = T.Zero;

        foreach (var value in values)
        {
            result += value;
        }

        return result;
    }

    public static T Add<T>(T left, T right) where T : INumber<T> => left + right;

    public static T AddAll1<T>(params T[] elements) where T : INumber<T> =>
        elements switch
        {
            [] => T.Zero,
            [var first, .. var rest] => first + AddAll1<T>(rest),
        };

    public static T AddAll2<T>(T[] sender) where T : IAddable<T>
    {
        T result = T.Zero;
        foreach (T item in sender) { result += item; }
        return result;
    }
}