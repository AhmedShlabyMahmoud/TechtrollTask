using Microsoft.EntityFrameworkCore;
using TechtrollTask.Domain.Entities;

namespace TechtrollTask.Infrastructure.Persistence
{
    public class FurnitureDbContext : DbContext
    {
        public FurnitureDbContext(DbContextOptions<FurnitureDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Subcomponent> Subcomponents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
              .HasColumnType("decimal(18,2)");
            var productId = 1;
            var componentId = 1;
            var subcomponentId = 1;
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = productId,
                Name = "كومود",
                Price = 1200m
            });


            modelBuilder.Entity<Component>().HasData(new Component
            {
                Id = componentId,
                Name = "علبة درج",
                Quantity = 2,
                ProductId = productId
            });

            modelBuilder.Entity<Subcomponent>().HasData(new Subcomponent
            {
                Id = subcomponentId,
                Name = "جنب 1",
                Material = "كونتر 18",
                CustomNotes = "مفحار للظهر",
                Count = 1,
                DetailLength = 36.1,
                DetailWidth = 42.1,
                DetailThickness = 2,
                CuttingLength = 41.1,
                CuttingWidth = 41.1,
                CuttingThickness = 2,
                FinalLength = 35.5,
                FinalWidth = 41.5,
                FinalThickness = 1.8,
                VeneerInner = "أرو",
                VeneerOuter = "أرو",
                ComponentId = componentId
            });
        }


    }

}
