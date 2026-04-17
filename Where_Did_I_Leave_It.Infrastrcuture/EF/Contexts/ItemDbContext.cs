using Microsoft.EntityFrameworkCore;
using Where_Did_I_Leave_It.Domain.Item;
using Where_Did_I_Leave_It.Infrastrcuture.EF.Config;

namespace Where_Did_I_Leave_It.Infrastrcuture.EF.Contexts
{
    public class ItemDbContext: DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemConfiguration).Assembly);
        }

        public DbSet<Item> Items { get; set; }
    }
}
