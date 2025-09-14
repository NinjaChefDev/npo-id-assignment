namespace NPO.Shared.Models;

public record CameraLocation
{
    public int Id { get; init; }
    public string? Camera { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
}