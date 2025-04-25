using Api.Domain.Exceptions;

namespace Api.Domain.Assertions;

public static class Assert
{
    public static void IsNull(object? value, string message)
    {
        if (value is null)
        {
            return;
        }

        throw new AssertException(message);
    }

    public static void IsNotNull(object? value, string message)
    {
        if (value is not null)
        {
            return;
        }

        throw new AssertException(message);
    }

    public static void IsTrue(bool condition, string message)
    {
        if (condition)
        {
            return;
        }

        throw new AssertException(message);
    }

    public static void IsFalse(bool condition, string message)
    {
        if (!condition)
        {
            return;
        }

        throw new AssertException(message);
    }

    public static void IsNullOrEmpty(string value, string message)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }

        throw new AssertException(message);
    }

    public static void IsNullOrWhiteSpace(string value, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        throw new AssertException(message);
    }

    public static void IsGreaterThan<T>(T value, T limit, string message) where T : IComparable<T>
    {
        if (value.CompareTo(limit) > 0)
        {
            return;
        }

        throw new ArgumentException(message);
    }

    public static void IsLessThan<T>(T value, T limit, string message) where T : IComparable<T>
    {
        if (value.CompareTo(limit) < 0)
        {
            return;
        }

        throw new ArgumentException(message);
    }

    public static void IsGreaterThanOrEqual<T>(T value, T limit, string message) where T : IComparable<T>
    {
        if (value.CompareTo(limit) >= 0)
        {
            return;
        }

        throw new ArgumentException(message);
    }

    public static void IsLessThanOrEqual<T>(T value, T limit, string message) where T : IComparable<T>
    {
        if (value.CompareTo(limit) <= 0)
        {
            return;
        }

        throw new ArgumentException(message);
    }

    public static void IsInRange<T>(T value, T min, T max, string message) where T : IComparable<T>
    {
        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
        {
            return;
        }

        throw new ArgumentException(message);
    }

    public static void IsEqual<T>(T value1, T value2, string message) where T : IComparable<T>
    {
        if (value1.CompareTo(value2) == 0)
        {
            return;
        }

        throw new ArgumentException(message);
    }

    public static void IsNotEqual<T>(T value1, T value2, string message) where T : IComparable<T>
    {
        if (value1.CompareTo(value2) != 0)
        {
            return;
        }

        throw new ArgumentException(message);
    }

    public static void IsIn<T>(T value, params T[] values) where T : IComparable<T>
    {
        if (values.Contains(value))
        {
            return;
        }

        throw new ArgumentException($"'{value}' is not in '{string.Join(",", values)}'");
    }

    public static void IsNotIn<T>(T value, params T[] values) where T : IComparable<T>
    {
        if (!values.Contains(value))
        {
            return;
        }

        throw new ArgumentException($"'{value}' is in '{string.Join(",", values)}'");
    }

    public static void IsBetween<T>(T value, T min, T max, string message) where T : IComparable<T>
    {
        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
        {
            return;
        }

        throw new ArgumentException(message);
    }

    public static void IsNotBetween<T>(T value, T min, T max, string message) where T : IComparable<T>
    {
        if (value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0)
        {
            return;
        }

        throw new ArgumentException(message);
    }

    public static void IsHttpUrl(string url, string message)
    {
        if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return;
        }

        throw new ArgumentException(message);
    }
}
