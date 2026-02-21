using Microsoft.EntityFrameworkCore;

namespace Entity_learning.Entities.Contexts;

public class TestEntityContext: DbContext
{
    public TestEntityContext(DbContextOptions<TestEntityContext> contextOptions)
        : base(contextOptions)
    {

    }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //}

    //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    //{
    //    base.ConfigureConventions(configurationBuilder);
    //}
}
