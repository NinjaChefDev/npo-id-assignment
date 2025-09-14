using NPO.WebApi.Extensions;

namespace NPO.WebApi.Tests;

public class CameraLocationTests
{
    [Fact]
    public void CameraLocation_MapsCorrectFields()
    {
        // Arrange
        var dataItem = new Data.CameraItem
        {
            Id = 1,
            Camera = "Camera 1",
            Latitude = 52.0,
            Longitude = 13.0
        };

        // Act
        var model = dataItem.ToCameraLocation();

        // Assert
        Assert.Equal(dataItem.Id, model.Id);
        Assert.Equal(dataItem.Camera, model.Camera);
        Assert.Equal(dataItem.Latitude, model.Latitude);
        Assert.Equal(dataItem.Longitude, model.Longitude);
    }
}