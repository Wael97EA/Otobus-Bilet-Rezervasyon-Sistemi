using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class FileHelper
{
    public static void SaveToFile<T>(string filePath, T data)
    {
        var json = JsonSerializer.Serialize(data);
        File.WriteAllText(filePath, json);
    }

    public static T? LoadFromFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
            return default;
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}
