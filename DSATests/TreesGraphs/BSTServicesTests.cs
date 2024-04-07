using DSA.Common;
using DSA.TreesGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static DSA.DSAServices;

namespace DSATests.TreesGraphs;

[TestClass]
public class BSTServicesTests {
    private readonly IBSTServices _bstServices = GetRequiredService<IBSTServices>();
    private readonly IDataWarehouse _dataServices = GetRequiredService<IDataWarehouse>();
    private readonly int[] _largeArray;

    public BSTServicesTests() {
        _largeArray = _dataServices.GetNumbers(Constants.S_FILE_MILLION_UNIQUE).ToArray();
    }

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

    [TestMethod]
    public void BuildBSTTest_Large() {
        // Act
        var result = _bstServices.BuildBST(_largeArray);

        if (result != null)
            Assert.AreEqual(888069, result.Value);
    }

    [TestMethod]
    public void GetMaximumDepthTest() {
        // Arrange
        var root = new TreeNode {
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

        var expectedDepth = 3;

        // Act
        var result = _bstServices.GetMaximumDepth(root);

        // Assert
        Assert.AreEqual(expectedDepth, result);
    }

    [TestMethod]
    public void GetMaximumDepthTest_EmptyTree() {
        // Arrange
        TreeNode? root = null;
        var expectedDepth = 0;

        // Act
        var result = _bstServices.GetMaximumDepth(root);

        // Assert
        Assert.AreEqual(expectedDepth, result);
    }

    [TestMethod]
    public void GetMaximumDepthTest_SingleNode() {
        // Arrange
        var root = new TreeNode { Value = 1 };
        var expectedDepth = 1;

        // Act
        var result = _bstServices.GetMaximumDepth(root);

        // Assert
        Assert.AreEqual(expectedDepth, result);
    }

    [TestInitialize]
    public void Initialize() {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "LOC");
    }

    [TestMethod]
    public void InvertTreeTest() {
        // Arrange
        var root = new TreeNode {
            Value = 4,
            Left = new TreeNode {
                Value = 2,
                Left = new TreeNode { Value = 1 },
                Right = new TreeNode { Value = 3 }
            },
            Right = new TreeNode {
                Value = 7,
                Left = new TreeNode { Value = 6 },
                Right = new TreeNode { Value = 9 }
            }
        };

        var expected = new TreeNode {
            Value = 4,
            Left = new TreeNode {
                Value = 7,
                Left = new TreeNode { Value = 9 },
                Right = new TreeNode { Value = 6 }
            },
            Right = new TreeNode {
                Value = 2,
                Left = new TreeNode { Value = 3 },
                Right = new TreeNode { Value = 1 }
            }
        };

        // Act
        var result = _bstServices.InvertTree(root);

        // Assert
        Assert.IsTrue(_bstServices.IsSameTree(expected, result));
    }

    [TestMethod]
    public void IsSameTreeTest_DifferentTree() {
        // Arrange
        var tree1 = new TreeNode {
            Value = 1,
            Left = new TreeNode { Value = 2 },
            Right = new TreeNode { Value = 3 }
        };

        var tree2 = new TreeNode {
            Value = 1,
            Left = new TreeNode { Value = 2 },
            Right = new TreeNode { Value = 4 }
        };

        // Act
        var result = _bstServices.IsSameTree(tree1, tree2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsSameTreeTest_NullTrees() {
        // Arrange
        TreeNode? tree1 = null;
        TreeNode? tree2 = null;

        // Act
        var result = _bstServices.IsSameTree(tree1, tree2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsSameTreeTest_SameTree() {
        // Arrange
        var tree1 = new TreeNode {
            Value = 1,
            Left = new TreeNode { Value = 2 },
            Right = new TreeNode { Value = 3 }
        };

        var tree2 = new TreeNode {
            Value = 1,
            Left = new TreeNode { Value = 2 },
            Right = new TreeNode { Value = 3 }
        };

        // Act
        var result = _bstServices.IsSameTree(tree1, tree2);

        // Assert
        Assert.IsTrue(result);
    }
}