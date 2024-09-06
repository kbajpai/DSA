namespace LeetCode.Misc;

public class Fibonacci {
    public static int Calculate(int n) {
        if (n <= 1) {
            return n;
        }

        return Calculate(n - 1) + Calculate(n - 2);
    }

    public static int CalculateIterative(int n) {
        if (n < 1) {
            throw new ArgumentException("n must be greater than or equal to 1");
        }

        if (n - 1 <= 1) {
            return n - 1;
        }

        var p = 0;
        var q = 1;
        for (var i = 2; i <= n; i++) {
            var r = q;
            q = p + q;
            p = r;
        }

        return q;
    }
}