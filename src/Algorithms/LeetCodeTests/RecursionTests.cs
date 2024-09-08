using LeetCode;

namespace LeetCodeTests;

[TestClass]
public class RecursionTests {
    [TestMethod]
    public void Calculate_Five_ReturnsFive() {
        Assert.AreEqual(5, Recursion.Calculate(5));
    }

    [TestMethod]
    public void Calculate_One_ReturnsOne() {
        Assert.AreEqual(1, Recursion.Calculate(1));
    }

    [TestMethod]
    public void Calculate_Ten_ReturnsFiftyFive() {
        Assert.AreEqual(55, Recursion.Calculate(10));
    }

    [TestMethod]
    public void Calculate_Zero_ReturnsZero() {
        Assert.AreEqual(0, Recursion.Calculate(0));
    }

    [TestMethod]
    public void CalculateIterative_Five_ReturnsFive() {
        Assert.AreEqual(5, Recursion.CalculateIterative(5));
    }

    [TestMethod]
    public void CalculateIterative_One_ReturnsOne() {
        Assert.AreEqual(0, Recursion.CalculateIterative(1));
    }

    [TestMethod]
    public void CalculateIterative_Ten_ReturnsFiftyFive() {
        Assert.AreEqual(55, Recursion.CalculateIterative(10));
    }

    [TestMethod]
    public void CalculateIterative_Zero_ReturnsZero() {
        Assert.ThrowsException<ArgumentException>(() => Recursion.CalculateIterative(0));
    }
}