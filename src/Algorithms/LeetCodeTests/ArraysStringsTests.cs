using LeetCode;

namespace LeetCodeTests;

[TestClass]
public class ArraysStringsTests {
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void MaximumNumber_EmptyArray_ThrowsException() {
        int[] input = [];
        ArraysStrings.MaximumNumber(input);
    }

    [TestMethod]
    public void MaximumNumber_MixedNumbers_ReturnsMaximum() {
        int[] input = [-1, -3, 5, 7, -9];
        var result = ArraysStrings.MaximumNumber(input);
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void MaximumNumber_NoPositiveNumbers_ThrowsException() {
        int[] input = [-1, -3, -5, -7, -9];
        ArraysStrings.MaximumNumber(input);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void MaximumNumber_NullArray_ThrowsException() {
        int[]? input = null;
        ArraysStrings.MaximumNumber(input);
    }

    [TestMethod]
    public void MaximumNumber_PositiveNumbers_ReturnsMaximum() {
        int[] input = [1, 3, 5, 7, 9];
        var result = ArraysStrings.MaximumNumber(input);
        Assert.AreEqual(9, result);
    }
}