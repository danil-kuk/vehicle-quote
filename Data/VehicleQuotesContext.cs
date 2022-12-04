using Microsoft.EntityFrameworkCore;
using VehicleQuotes.Models;

namespace VehicleQuotes.Data;

public class VehicleQuotesContext : DbContext
{
    public VehicleQuotesContext(DbContextOptions<VehicleQuotesContext> options) : base(options)
    { }

    public DbSet<Make> Makes => Set<Make>();
    public DbSet<Size> Sizes => Set<Size>();
    public DbSet<BodyType> BodyTypes => Set<BodyType>();

    public DbSet<Model> Models => Set<Model>();
    public DbSet<ModelStyle> ModelStyles => Set<ModelStyle>();
    public DbSet<ModelStyleYear> ModelStyleYears => Set<ModelStyleYear>();

    public DbSet<QuoteOverride> QuoteOverrides => Set<QuoteOverride>();
    public DbSet<QuoteRule> QuoteRules => Set<QuoteRule>();

    public DbSet<Quote> Quotes => Set<Quote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Size>().HasData(
            new Size { ID = 1, Name = "Subcompact" },
            new Size { ID = 2, Name = "Compact" },
            new Size { ID = 3, Name = "Mid Size" },
            new Size { ID = 4, Name = "Full Size" }
        );
    }
}
