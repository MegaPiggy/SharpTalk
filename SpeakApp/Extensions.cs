using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;

public static class Extensions
{
    public static void SetText(this RichTextBox richTextBox, string content)
    {
        if (richTextBox.Document == null)
            richTextBox.Document = new FlowDocument();

        richTextBox.Document.Blocks.Clear();
        richTextBox.Document.Blocks.Add(new Paragraph(new Run(content)));
    }

    public static string GetText(this RichTextBox richTextBox) => new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text.Trim();

    /// <summary>
    /// Reverses the string
    /// </summary>
    public static string Reverse(this string s)
    {
        char[] charArray = s.ToCharArray();
        System.Array.Reverse(charArray);
        return new string(charArray);
    }

    /// <summary>
    /// Removes anything after the <paramref name="value"/> parameter
    /// </summary>
    /// <param name="value">The string to seek</param>
    /// <param name="include">Whether to remove the <paramref name="value"/></param>
    public static string RemoveEverythingAfter(this string str, string value, bool include = false)
    {
        int index = str.IndexOf(value);
        if (index >= 0)
            str = str.Substring(0, include ? index : (index + value.Length));
        return str;
    }

    /// <summary>
    /// Removes anything after the <paramref name="value"/> parameter
    /// </summary>
    /// <param name="value">The string to seek</param>
    /// <param name="include">Whether to remove the <paramref name="value"/></param>
    public static string RemoveEverythingBefore(this string str, string value, bool include = false)
    {
        int index = str.IndexOf(value);
        if (index >= 0)
            str = str.Substring(index);
        if (include)
            str = str.Substring(value.Length);
        return str;
    }

    public static string GetExtension(this string file, bool includeDot = false) => file.Reverse().RemoveEverythingAfter(".", !includeDot).Reverse();
    public static string RemoveExtension(this string file) => file.RemoveEverythingAfter(file.GetExtension(true), true);

    public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource element)
    {
        if (source == null)
            throw new ArgumentNullException("source");

        yield return element;
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
    }

    public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource element)
    {
        if (source == null)
            throw new ArgumentNullException("source");

        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
        yield return element;
    }

    public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> addition)
    {
        if (source == null)
            throw new ArgumentNullException("source");

        if (addition == null)
            throw new ArgumentNullException("addition");

        using (var enumerator = addition.GetEnumerator())
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
    }

    public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> addition)
    {
        if (source == null)
            throw new ArgumentNullException("source");

        if (addition == null)
            throw new ArgumentNullException("addition");

        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
        using (var enumerator = addition.GetEnumerator())
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
    }

    public static string Join(this IEnumerable<string> strings)
    {
        string final = string.Empty;

        if (strings != null)
        {
            foreach (string s in strings)
                final += s;
        }

        return final;
    }
}