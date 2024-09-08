using System.Text;

namespace LeetCode;

public static class ArraysStrings {
    public static bool IsPalindrome(string s) {
        if (string.IsNullOrEmpty(s) || s.Length == 1)
            return true;

        var left = 0;
        var right = s.Length - 1;

        while (left < right) {
            if (s[left] != s[right])
                return false;

            left++;
            right--;
        }

        return true;
    }

    public static int MaximumNumber(int[]? arr) {
        if (arr == null || arr.Length == 0) {
            throw new ArgumentException("Array cannot be null or empty");
        }

        var n = int.MinValue;

        foreach (var a in arr) {
            if (a > n) {
                n = a;
            }
        }

        if (n <= 0) {
            throw new InvalidOperationException("No positive number found");
        }

        return n;
    }

    public static string ReverseString(string s) {
        if (string.IsNullOrEmpty(s) || s.Length == 1) {
            return s;
        }

        var l = 0;
        var r = s.Length - 1;

        var sb = new StringBuilder(s);

        while (l < r) {
            (sb[l], sb[r]) = (sb[r], sb[l]);

            l++;
            r--;
        }

        return sb.ToString();
    }
}