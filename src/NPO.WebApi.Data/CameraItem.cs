using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPO.WebApi.Data;

public class CameraItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Camera { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}
