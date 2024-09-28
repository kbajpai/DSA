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
    ///     Finds the length of the longest sub-array with a sum less than or equal to the specified value.
    /// </summary>
    /// <param name="k">The maximum sum of the sub-array.</param>
    /// <param name="nums">The array of integers.</param>
    /// <returns>The length of the longest sub-array with a sum less than or equal to k.</returns>
    /// <exception cref="ArgumentException">Thrown when the array is null or empty.</exception>
    /// <remarks>
    ///     Space Complexity: O(1) - Uses a constant amount of extra space.
    ///     Time Complexity: O(n) - Iterates through the array once, where n is the length of the array.
    /// </remarks>
    public static int MaxSubArray(int k, int[] nums) {
        if (nums == null || nums.Length == 0) {
            throw new ArgumentException("Array cannot be null or empty");
        }

        int l = 0, currSum = 0, maxLen = 0;

        for (var r = 0; r < nums.Length; r++) {
            currSum += nums[r];

            while (currSum > k && l <= r) {
                currSum -= nums[l++];
            }

            maxLen = Math.Max(maxLen, r - l + 1);
        }

        return maxLen;
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

    /// <summary>
    ///     Returns an array of the squares of each number sorted in non-decreasing order.
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>An array of the squares of each number sorted in non-decreasing order.</returns>
    /// <remarks>
    ///     Space Complexity: O(n) - Uses extra space proportional to the length of the input array.
    ///     Time Complexity: O(n) - Iterates through the array once, where n is the length of the array.
    /// </remarks>
    public static int[] SortedSquares(int[] nums) {
        var sortedNums = new int[nums.Length];
        int l = 0, r = nums.Length - 1;

        for (var i = nums.Length - 1; i >= 0; i--) {
            var leftSquare = nums[l] * nums[l];
            var rightSquare = nums[r] * nums[r];

            if (leftSquare > rightSquare) {
                sortedNums[i] = leftSquare;
                l++;
            }
            else {
                sortedNums[i] = rightSquare;
                r--;
            }
        }

        return sortedNums;
    }
}