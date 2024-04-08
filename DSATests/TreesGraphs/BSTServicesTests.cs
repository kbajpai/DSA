using DSA.Common;
using DSA.TreesGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static DSA.Common.Constants;
using static DSA.DSAServices;

namespace DSATests.TreesGraphs;

[TestClass]
public class BSTServicesTests {
    private static int[] _largeArray = null!;
    private static TreeNode? _largeTree;
    private static readonly IBSTServices BSTServices = GetRequiredService<IBSTServices>();
    private static readonly IDataWarehouse DataServices = GetRequiredService<IDataWarehouse>();

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
        var result = BSTServices.BuildBST(nums);

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
        var result = BSTServices.BuildBST(_largeArray);

        if (result != null)
            Assert.AreEqual(888069, result.Value);
    }

    [ClassInitialize]
    public static void ClassSetup(TestContext context) {
        _largeArray = DataServices.GetNumbers(S_FILE_MILLION_UNIQUE).ToArray();
        _largeTree = BSTServices.BuildBST(_largeArray);
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
        var result = BSTServices.GetMaximumDepth(root);

        // Assert
        Assert.AreEqual(expectedDepth, result);
    }

    [TestMethod]
    public void GetMaximumDepthTest_EmptyTree() {
        // Arrange
        TreeNode? root = null;
        var expectedDepth = 0;

        // Act
        var result = BSTServices.GetMaximumDepth(root);

        // Assert
        Assert.AreEqual(expectedDepth, result);
    }

    [TestMethod]
    public void GetMaximumDepthTest_LargeTree() {
        // Arrange
        var expectedDepth = 51;

        // Act
        var result = BSTServices.GetMaximumDepth(_largeTree);

        // Assert
        Assert.AreEqual(expectedDepth, result);
    }

    [TestMethod]
    public void GetMaximumDepthTest_SingleNode() {
        // Arrange
        var root = new TreeNode { Value = 1 };
        var expectedDepth = 1;

        // Act
        var result = BSTServices.GetMaximumDepth(root);

        // Assert
        Assert.AreEqual(expectedDepth, result);
    }

    [TestMethod]
    public void GetMinimumDifferenceTest_MultipleNodes() {
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

        // Act
        var result = BSTServices.GetMinimumDifference(root);

        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetMinimumDifferenceTest_TwoNodes() {
        // Arrange
        var root = new TreeNode {
            Value = 2,
            Left = new TreeNode { Value = 1 }
        };

        // Act
        var result = BSTServices.GetMinimumDifference(root);

        // Assert
        Assert.AreEqual(1, result);
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
        var result = BSTServices.InvertTree(root);

        // Assert
        Assert.IsTrue(BSTServices.IsSameTree(expected, result));
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
        var result = BSTServices.IsSameTree(tree1, tree2);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsSameTreeTest_NullTrees() {
        // Arrange
        TreeNode? tree1 = null;
        TreeNode? tree2 = null;

        // Act
        var result = BSTServices.IsSameTree(tree1, tree2);

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
        var result = BSTServices.IsSameTree(tree1, tree2);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValidBSTTest_InvalidBST() {
        // Arrange
        var root = new TreeNode {
            Value = 2,
            Left = new TreeNode { Value = 3 },
            Right = new TreeNode { Value = 1 }
        };

        // Act
        var result = BSTServices.IsValidBST(root);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidBSTTest_SingleNode() {
        // Arrange
        var root = new TreeNode { Value = 1 };

        // Act
        var result = BSTServices.IsValidBST(root);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValidBSTTest_ValidBST() {
        // Arrange
        var root = new TreeNode {
            Value = 2,
            Left = new TreeNode { Value = 1 },
            Right = new TreeNode { Value = 3 }
        };

        // Act
        var result = BSTServices.IsValidBST(root);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void RangeSumBSTTest_EmptyTree() {
        // Arrange
        TreeNode? root = null;
        var low = 1;
        var high = 5;

        // Act
        var result = BSTServices.RangeSumBST(root, low, high);

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void RangeSumBSTTest_LargeTree() {
        // Arrange
        var low = 200000;
        var high = 800000;

        // Act
        if (_largeTree != null) {
            var result = BSTServices.RangeSumBST(_largeTree, low, high);

            // Assert
            // The expected result depends on the specific values in _largeTree
            // Replace 'expected' with the correct value
            var expected = 300000500000;
            Assert.AreEqual(expected, result);
        }
    }

    [TestMethod]
    public void RangeSumBSTTest_MultipleNodes() {
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
        var low = 3;
        var high = 7;

        // Act
        var result = BSTServices.RangeSumBST(root, low, high);

        // Assert
        Assert.AreEqual(25, result);
    }

    [TestMethod]
    public void RangeSumBSTTest_SingleNode() {
        // Arrange
        var root = new TreeNode { Value = 1 };
        var low = 1;
        var high = 5;

        // Act
        var result = BSTServices.RangeSumBST(root, low, high);

        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void SearchTest_EmptyTree() {
        // Arrange
        TreeNode? root = null;
        var searchValue = 1;

        // Act
        var result = BSTServices.Search(searchValue, root);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void SearchTest_NodeDoesNotExist() {
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
        var searchValue = 8;

        // Act
        var result = BSTServices.Search(searchValue, root);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void SearchTest_NodeExists() {
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
        var searchValue = 5;

        // Act
        var result = BSTServices.Search(searchValue, root);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(searchValue, result?.Value);
    }

    [TestMethod]
    public void SearchTest_NodeExists_Large() {
        // Arrange
        var searchValue = 298334;

        // Act
        var result = BSTServices.Search(searchValue, _largeTree);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(searchValue, result.Value);
    }
}