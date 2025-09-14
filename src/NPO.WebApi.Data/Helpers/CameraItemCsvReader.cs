using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace NPO.WebApi.Data.Helpers;

public static class CameraItemCsvReader
{
    public static List<CameraItem> Read(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";", // Set the delimiter to semicolon
        };

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, config);
        csv.Context.RegisterClassMap<CameraItemMap>();
        return csv.GetRecords<CameraItem>().ToList();
    }
}

public sealed class CameraItemMap : ClassMap<CameraItem>
{
    public CameraItemMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
    }
}
