#if NETFRAMEWORK
using System.Buffers;

namespace System.Text;

/// <summary>
/// Minimal <see cref="Rune"/> polyfill for .NET Framework 4.8.
/// Provides the subset of the standard <c>System.Text.Rune</c> API used by Forme.
/// </summary>
internal readonly struct Rune : IEquatable<Rune>
{
    /// <summary>Gets the Unicode scalar value of this rune.</summary>
    public int Value { get; }

    internal Rune(int value) => Value = value;

    /// <summary>
    /// Decodes the leading UTF-16 sequence from <paramref name="source"/> into a <see cref="Rune"/>.
    /// </summary>
    public static OperationStatus DecodeFromUtf16(
        ReadOnlySpan<char> source,
        out Rune result,
        out int charsConsumed)
    {
        if (source.IsEmpty)
        {
            result = default;
            charsConsumed = 0;
            return OperationStatus.NeedMoreData;
        }

        char first = source[0];

        if (!char.IsHighSurrogate(first))
        {
            result = new Rune(first);
            charsConsumed = 1;
            return OperationStatus.Done;
        }

        if (source.Length < 2)
        {
            result = default;
            charsConsumed = 0;
            return OperationStatus.NeedMoreData;
        }

        char second = source[1];

        if (!char.IsLowSurrogate(second))
        {
            result = default;
            charsConsumed = 1;
            return OperationStatus.InvalidData;
        }

        result = new Rune(char.ConvertToUtf32(first, second));
        charsConsumed = 2;
        return OperationStatus.Done;
    }

    /// <inheritdoc/>
    public bool Equals(Rune other) => Value == other.Value;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Rune r && Equals(r);

    /// <inheritdoc/>
    public override int GetHashCode() => Value;
}
#endif
