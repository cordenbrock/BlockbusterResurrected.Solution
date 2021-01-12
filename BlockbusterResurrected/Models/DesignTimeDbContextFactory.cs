using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BlockbusterResurrected.Models
{
  public class BlockbusterResurrectedContextFactory : IDesignTimeDbContextFactory<BlockbusterResurrectedContext>
  {

    BlockbusterResurrectedContext IDesignTimeDbContextFactory<BlockbusterResurrectedContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<BlockbusterResurrectedContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new BlockbusterResurrectedContext(builder.Options);
    }
  }
}