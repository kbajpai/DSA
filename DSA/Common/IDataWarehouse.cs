namespace DSA.Common;

public interface IDataWarehouse {
    void GenerateUniqueIntegers(string filePath, int count);

    IEnumerable<int> GetNumbers(string numberFileName);
}