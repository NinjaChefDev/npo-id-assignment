using System.Net.Http.Json;
using System.Text.Json;
using NPO.Shared.Models;

namespace NPO.Cli;

class Program
{
    static async Task<int> Main(string[] args)
    {
        if (args.Length < 2 || args[0] != "--name")
        {
            Console.WriteLine("Usage: NPO.Cli --name <value>");
            return 1;
        }

        string nameValue = args[1];
        string apiEndpoint = Environment.GetEnvironmentVariable("NPO_API_ENDPOINT") ?? "http://localhost:5188/api/Cameras/search?query=";

        string requestUrl = $"{apiEndpoint}{Uri.EscapeDataString(nameValue)}";
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(requestUrl);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"API request failed: {response.StatusCode}");
            return 2;
        }

        var json = await response.Content.ReadAsStringAsync();
        var cameras = new List<CameraLocation>();
        try
        {
            cameras = JsonSerializer.Deserialize<List<CameraLocation>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (JsonException je)
        {
            Console.WriteLine("Failed to parse JSON response: {0}", je.Message);
            return 3;
        }

        if (cameras == null || cameras.Count == 0)
        {
            Console.WriteLine("No camera locations found.");
            return 4;
        }

        foreach (var camera in cameras)
        {
            Console.WriteLine(camera.Camera);
        }

        return 0;
    }
}