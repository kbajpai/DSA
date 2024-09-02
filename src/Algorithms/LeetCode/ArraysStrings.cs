namespace LeetCode;

public static class ArraysStrings {
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
}