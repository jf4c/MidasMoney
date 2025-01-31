using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MidasMoney.Core.Models;

namespace MidasMoney.Api.Infra;

public class AddDbContext(DbContextOptions<AddDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Transection> Transections { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}