using NPO.Shared.Models;

namespace NPO.WebApi.Extensions;

public static class CameraLocationExtensions
{
    public static CameraLocation ToCameraLocation(this Data.CameraItem item)
    {
        return new CameraLocation
        {
            Id = item.Id,
            Camera = item.Camera,
            Latitude = item.Latitude,
            Longitude = item.Longitude
        };
    }
}