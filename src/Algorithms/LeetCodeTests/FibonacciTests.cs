using LeetCode.Misc;

namespace LeetCodeTests;

[TestClass]
public class FibonacciTests {
    [TestMethod]
    public void Calculate_Five_ReturnsFive() {
        Assert.AreEqual(5, Fibonacci.Calculate(5));
    }

    [TestMethod]
    public void Calculate_One_ReturnsOne() {
        Assert.AreEqual(1, Fibonacci.Calculate(1));
    }

    [TestMethod]
    public void Calculate_Ten_ReturnsFiftyFive() {
        Assert.AreEqual(55, Fibonacci.Calculate(10));
    }

    [TestMethod]
    public void Calculate_Zero_ReturnsZero() {
        Assert.AreEqual(0, Fibonacci.Calculate(0));
    }

    [TestMethod]
    public void CalculateIterative_Five_ReturnsFive() {
        Assert.AreEqual(5, Fibonacci.CalculateIterative(5));
    }

    [TestMethod]
    public void CalculateIterative_One_ReturnsOne() {
        Assert.AreEqual(0, Fibonacci.CalculateIterative(1));
    }

    [TestMethod]
    public void CalculateIterative_Ten_ReturnsFiftyFive() {
        Assert.AreEqual(55, Fibonacci.CalculateIterative(10));
    }

    [TestMethod]
    public void CalculateIterative_Zero_ReturnsZero() {
        Assert.ThrowsException<ArgumentException>(() => Fibonacci.CalculateIterative(0));
    }
}