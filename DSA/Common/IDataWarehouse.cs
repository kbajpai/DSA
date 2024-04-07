namespace DSA.Common;

public interface IDataWarehouse {
    IEnumerable<int> GetNumbers(string numberFileName);

    void GenerateUniqueIntegers(string filePath, int count);
}