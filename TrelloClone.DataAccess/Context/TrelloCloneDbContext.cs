using Microsoft.EntityFrameworkCore;
using TrelloClone.Entities.DbSets;

namespace TrelloClone.DataAccess.Context
{
    public class TrelloCloneDbContext : DbContext
    {
        public TrelloCloneDbContext(DbContextOptions<TrelloCloneDbContext> options) : base(options)
        {            
        }

        public DbSet<List> Lists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardOrders> CardOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<List>()
                .HasMany(l => l.CardOrders)
                .WithOne(co => co.List)
                .HasForeignKey(co => co.ListId);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.CardOrder)
                .WithOne(co => co.Card)
                .HasForeignKey<CardOrders>(co => co.CardId);

            modelBuilder.Entity<CardOrders>()
                .HasIndex(co => new { co.ListId, co.Index })
                .IsUnique();
        }
    }
}
