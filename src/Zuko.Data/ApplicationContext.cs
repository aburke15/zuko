using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using Zuko.Data.Models;

namespace Zuko.Data;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Repo>()
            .ToCollection("repos");
    }

    public virtual DbSet<Repo> Repos { get; set; }
}
