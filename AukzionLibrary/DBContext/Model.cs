namespace AukzionLibrary.DBContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelAuction")
        {
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sold> Sold { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>()
                .Property(e => e.Cash)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.Sold)
                .WithOptional(e => e.Buyer)
                .HasForeignKey(e => e.ID_Buyer);

            modelBuilder.Entity<Product>()
                .Property(e => e.StartPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.SellPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Sold)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.ID_Product);
        }
    }
}
