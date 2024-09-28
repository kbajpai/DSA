using LeetCode;

namespace LeetCodeTests;

[TestClass]
public class ArraysStringsTests {
    [TestMethod]
    public void IsPalindrome_EmptyString_ReturnsTrue() {
        // Arrange
        var input = string.Empty;

        // Act
        var result = ArraysStrings.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsPalindrome_InvalidPalindrome_ReturnsFalse() {
        // Arrange
        var input = "NITUIN";

        // Act
        var result = ArraysStrings.IsPalindrome(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsPalindrome_MixedCasePalindrome_ReturnsTrue() {
        // Arrange
        const string S_INPUT = "RaceCar";

        // Act
        var result = ArraysStrings.IsPalindrome(S_INPUT);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsPalindrome_NonPalindromeWithSpaces_ReturnsFalse() {
        // Arrange
        var input = "hello world";

        // Act
        var result = ArraysStrings.IsPalindrome(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsPalindrome_SingleCharacter_ReturnsTrue() {
        // Arrange
        const string S_INPUT = "a";

        // Act
        var result = ArraysStrings.IsPalindrome(S_INPUT);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsPalindrome_ValidPalindrome_ReturnsTrue() {
        // Arrange
        var input = "NITTIN";

        // Act
        var result = ArraysStrings.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }

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

    [TestMethod]
    public void MaxSubArray_AllElementsGreaterThanK_ReturnsZero() {
        // Arrange
        var k = 5;
        int[] input = [6, 7, 8, 9];

        // Act
        var result = ArraysStrings.MaxSubArray(k, input);

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void MaxSubArray_EmptyArray_ReturnsZero() {
        // Arrange
        var k = 5;
        var input = Array.Empty<int>();

        // Act
        var result = ArraysStrings.MaxSubArray(k, input);

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void MaxSubArray_MixedElements_ReturnsCorrectLength() {
        // Arrange
        var k = 8;
        int[] input = [1, 2, 3, 4, 5];

        // Act
        var result = ArraysStrings.MaxSubArray(k, input);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void MaxSubArray_MultipleElements_ReturnsCorrectLength() {
        // Arrange
        var k = 5;
        int[] input = [1, 2, 1, 0, 1, 1, 2];

        // Act
        var result = ArraysStrings.MaxSubArray(k, input);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void MaxSubArray_SingleElementGreaterThanK_ReturnsZero() {
        // Arrange
        var k = 5;
        int[] input = [6];

        // Act
        var result = ArraysStrings.MaxSubArray(k, input);

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void MaxSubArray_SingleElementLessThanK_ReturnsOne() {
        // Arrange
        var k = 5;
        int[] input = [3];

        // Act
        var result = ArraysStrings.MaxSubArray(k, input);

        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void MaxSubArray_AllGreaterThanK_ReturnsZero() {
        // Arrange
        var k = 5;
        int[] input = [10, 7, 8, 6, 8, 10, 22];

        // Act
        var result = ArraysStrings.MaxSubArray(k, input);

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void ReverseString_EmptyString_ReturnsEmptyString() {
        // Arrange
        var input = string.Empty;

        // Act
        var result = ArraysStrings.ReverseString(input);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void ReverseString_PalindromeString_ReturnsSameString() {
        // Arrange
        var input = "racecar";

        // Act
        var result = ArraysStrings.ReverseString(input);

        // Assert
        Assert.AreEqual("racecar", result);
    }

    [TestMethod]
    public void ReverseString_SingleCharacter_ReturnsSameCharacter() {
        // Arrange
        var input = "a";

        // Act
        var result = ArraysStrings.ReverseString(input);

        // Assert
        Assert.AreEqual("a", result);
    }

    [TestMethod]
    public void ReverseString_ValidString_ReturnsReversedString() {
        // Arrange
        var input = "Hello, World!";

        // Act
        var result = ArraysStrings.ReverseString(input);

        // Assert
        Assert.AreEqual("!dlroW ,olleH", result);
    }

    [TestMethod]
    public void SortedSquares_AllNegativeNumbers_ReturnsSortedSquares() {
        // Arrange
        int[] input = [-5, -4, -3, -2, -1];

        // Act
        var result = ArraysStrings.SortedSquares(input);

        // Assert
        CollectionAssert.AreEqual((int[]) [1, 4, 9, 16, 25], result);
    }

    [TestMethod]
    public void SortedSquares_AllPositiveNumbers_ReturnsSortedSquares() {
        // Arrange
        int[] input = [1, 2, 3, 4, 5];

        // Act
        var result = ArraysStrings.SortedSquares(input);

        // Assert
        CollectionAssert.AreEqual((int[]) [1, 4, 9, 16, 25], result);
    }

    [TestMethod]
    public void SortedSquares_EmptyArray_ReturnsEmptyArray() {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = ArraysStrings.SortedSquares(input);

        // Assert
        CollectionAssert.AreEqual(Array.Empty<int>(), result);
    }

    [TestMethod]
    public void SortedSquares_MixedNumbers_ReturnsSortedSquares() {
        // Arrange
        int[] input = [-4, -1, 0, 3, 10];

        // Act
        var result = ArraysStrings.SortedSquares(input);

        // Assert
        CollectionAssert.AreEqual((int[]) [0, 1, 9, 16, 100], result);
    }

    [TestMethod]
    public void SortedSquares_SingleElement_ReturnsSquare() {
        // Arrange
        int[] input = [3];

        // Act
        var result = ArraysStrings.SortedSquares(input);

        // Assert
        CollectionAssert.AreEqual((int[]) [9], result);
    }
}