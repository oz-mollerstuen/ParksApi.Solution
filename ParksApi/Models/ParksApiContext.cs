using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
  public class ParksApiContext : DbContext
  {
    public DbSet<Parkrec> Parkrecs { get; set; }
    public DbSet<Tipe> Tipes { get; set; }
    public object Users { get; internal set; }

    public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options)
    {
    }
  }
}