using DSA.Common;
using DSA.TreesGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static DSA.DSAServices;

namespace DSATests.TreesGraphs;

[TestClass]
public class BSTServicesTests {
    private readonly IBSTServices _bstServices = GetRequiredService<IBSTServices>();

    [TestMethod]
    public void BuildBSTTest() {
        // Arrange
        int[] nums = [4, 2, 6, 1, 3, 5, 7];
        var expected = new TreeNode {
            Value = 4,
            Left = new TreeNode {
                Value = 2,
                Left = new TreeNode { Value = 1 },
                Right = new TreeNode { Value = 3 }
            },
            Right = new TreeNode {
                Value = 6,
                Left = new TreeNode { Value = 5 },
                Right = new TreeNode { Value = 7 }
            }
        };

        // Act
        var result = _bstServices.BuildBST(nums);

        // Assert
        Assert.AreEqual(expected.Value, result?.Value);
        Assert.AreEqual(expected.Left?.Value, result?.Left?.Value);
        Assert.AreEqual(expected.Left?.Left?.Value, result?.Left?.Left?.Value);
        Assert.AreEqual(expected.Left?.Right?.Value, result?.Left?.Right?.Value);
        Assert.AreEqual(expected.Right?.Value, result?.Right?.Value);
        Assert.AreEqual(expected.Right?.Left?.Value, result?.Right?.Left?.Value);
        Assert.AreEqual(expected.Right?.Right?.Value, result?.Right?.Right?.Value);
    }

    [TestInitialize]
    public void Initialize() {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "LOC");
    }
}