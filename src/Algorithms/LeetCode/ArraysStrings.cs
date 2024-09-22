using System.Text;

namespace LeetCode;

public static class ArraysStrings {
    /// <summary>
    ///     Determines whether the specified string is a palindrome.
    /// </summary>
    /// <param name="s">The string to check.</param>
    /// <returns>True if the string is a palindrome; otherwise, false.</returns>
    /// <remarks>
    ///     Space Complexity: O(1) - Uses a constant amount of extra space.
    ///     Time Complexity: O(n) - Iterates through the string once, where n is the length of the string.
    /// </remarks>
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

    /// <summary>
    ///     Finds the maximum positive number in the specified array.
    /// </summary>
    /// <param name="arr">The array to search.</param>
    /// <returns>The maximum positive number in the array.</returns>
    /// <exception cref="ArgumentException">Thrown when the array is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown when no positive number is found.</exception>
    /// <remarks>
    ///     Space Complexity: O(1) - Uses a constant amount of extra space.
    ///     Time Complexity: O(n) - Iterates through the array once, where n is the length of the array.
    /// </remarks>
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

    /// <summary>
    ///     Reverses the specified string.
    /// </summary>
    /// <param name="s">The string to reverse.</param>
    /// <returns>The reversed string.</returns>
    /// <remarks>
    ///     Space Complexity: O(n) - Uses extra space proportional to the length of the string.
    ///     Time Complexity: O(n) - Iterates through the string once, where n is the length of the string.
    /// </remarks>
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

    public static int[] SortedSquares(int[] nums) {
        var sortedNums = new int[nums.Length];
        int l = 0, r = nums.Length - 1;

        for (var i = nums.Length - 1; i >= 0; i--) {
            if (Math.Abs(nums[l]) > Math.Abs(nums[r])) {
                sortedNums[i] = nums[l] * nums[l];
                l++;
            }
            else {
                sortedNums[i] = nums[r] * nums[r];
                r--;
            }
        }

        return sortedNums;
    }
}