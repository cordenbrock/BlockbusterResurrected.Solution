using Microsoft.EntityFrameworkCore;

namespace BlockbusterResurrected.Models
{
  public class BlockbusterResurrectedContext : DbContext
  {
    public DbSet<Game> Games { get; set; }
    public DbSet<GConsole> GConsoles { get; set; }
    public DbSet<ConsoleGame> ConsoleGame { get; set; }
    public BlockbusterResurrectedContext(DbContextOptions options) : base(options) {}
  }
}