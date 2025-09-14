using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NPO.Shared.Models;
using NPO.WebApi.Data;
using NPO.WebApi.Extensions;

namespace NPO.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class CamerasController : ControllerBase
{
    private readonly AppDbContext _cameraData;

    public CamerasController(AppDbContext context)
    {
        _cameraData = context;
    }

    [HttpGet("{id}")]
    public ActionResult<CameraLocation> GetById(int id)
    {
        var result = _cameraData.Items.FirstOrDefault(c => c.Id == id);
        return result != null ? Ok(result.ToCameraLocation()) : NotFound();
    }

    [HttpGet("range")]
    public ActionResult<IEnumerable<CameraLocation>> GetByRange(int from, int to)
    {
        var results = _cameraData.Items
            .Where(c => c.Id >= from && c.Id <= to)
            .Select(c => c.ToCameraLocation());
        return Ok(results);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<CameraLocation>> SearchByName(string query)
    {
        var results = _cameraData.Items
            .Where(c => c.Camera.Contains(query, StringComparison.OrdinalIgnoreCase))
            .Select(c => c.ToCameraLocation());

        return Ok(results);
    }
}
