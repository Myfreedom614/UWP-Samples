namespace ProductService.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductService.Models.ProductServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductService.Models.ProductServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            // New code 
            context.Products.AddOrUpdate(new Product[] {
        new Product() { ID = 1, Name = "Hat", Price = 15, Category = "Apparel" },
        new Product() { ID = 2, Name = "Socks", Price = 5, Category = "Apparel" },
        new Product() { ID = 3, Name = "Scarf", Price = 12, Category = "Apparel" },
        new Product() { ID = 4, Name = "Yo-yo", Price = 4.95M, Category = "Toys" },
        new Product() { ID = 5, Name = "Puzzle", Price = 8, Category = "Toys" },
    });
        }
    }
}
