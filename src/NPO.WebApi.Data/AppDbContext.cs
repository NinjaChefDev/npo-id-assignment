using Microsoft.EntityFrameworkCore;

namespace NPO.WebApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<CameraItem> Items { get; set; }
}
