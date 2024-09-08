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
        var input = "RaceCar";

        // Act
        var result = ArraysStrings.IsPalindrome(input);

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
        var input = "a";

        // Act
        var result = ArraysStrings.IsPalindrome(input);

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
}