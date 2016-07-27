namespace ProductService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductRatings", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.ProductRatings", new[] { "ProductID" });
            AlterColumn("dbo.Products", "SupplierId", c => c.String());
            DropTable("dbo.ProductRatings");
            DropTable("dbo.Suppliers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.ProductRatings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Products", "SupplierId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProductRatings", "ProductID");
            CreateIndex("dbo.Products", "SupplierId");
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "Key");
            AddForeignKey("dbo.ProductRatings", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
