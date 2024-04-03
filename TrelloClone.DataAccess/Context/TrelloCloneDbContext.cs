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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<List>()
                .HasMany(l => l.Cards)
                .WithOne(c => c.List)
                .HasForeignKey(c => c.ListId);
        }
    }
}
