namespace assignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Shopper> Shoppers { get; set; }
        public virtual DbSet<Shopperss> Shoppersses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shopper>()
                .Property(e => e.Products)
                .IsFixedLength();

            modelBuilder.Entity<Shopper>()
                .Property(e => e.Food)
                .IsFixedLength();

            modelBuilder.Entity<Shopper>()
                .Property(e => e.Medicine)
                .IsFixedLength();

            modelBuilder.Entity<Shopper>()
                .HasOptional(e => e.Shopperss)
                .WithRequired(e => e.Shopper);

            modelBuilder.Entity<Shopperss>()
                .Property(e => e.Stock)
                .IsFixedLength();

            modelBuilder.Entity<Shopperss>()
                .Property(e => e.Staff)
                .IsFixedLength();

            modelBuilder.Entity<Shopperss>()
                .Property(e => e.Accessories)
                .IsFixedLength();
        }
    }
}
