using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
  public class ParksApiContext : DbContext
  {
    public DbSet<Parkrec> Parkrecs { get; set; }
    public DbSet<Type> Types { get; set; }

    public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options)
    {
    }
  }
}