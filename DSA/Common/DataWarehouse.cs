namespace DSA.Common;

/// <summary>
///     Class DataWarehouse provides methods to generate unique integers and read numbers from a file.
/// </summary>
public class DataWarehouse : IDataWarehouse {
    private const string S_FILE_DATA_ROOT = "Data";

    /// <summary>
    ///     Generates a specified count of unique integers and writes them to a file.
    /// </summary>
    /// <param name="filePath">The path of the file where the integers will be written.</param>
    /// <param name="count">The count of unique integers to generate.</param>
    public void GenerateUniqueIntegers(string filePath, int count) {
        var random = new Random();
        var numbers = Enumerable.Range(1, count).OrderBy(x => random.Next()).ToList();

        // Write to file
        File.WriteAllLines(filePath, numbers.Select(x => x.ToString()));
    }

    /// <summary>
    ///     Reads numbers from a file and returns them as an IEnumerable of integers.
    /// </summary>
    /// <param name="numberFileName">The name of the file from which to read the numbers.</param>
    /// <returns>An IEnumerable of integers read from the file.</returns>
    public IEnumerable<int> GetNumbers(string numberFileName) {
        return File.ReadAllLines(
                $"{S_FILE_DATA_ROOT}{Path.DirectorySeparatorChar}{numberFileName}")
            .Select(int.Parse);
    }
}