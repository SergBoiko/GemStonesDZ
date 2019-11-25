namespace GemStones.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGemstones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GemEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        Color = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductEntities", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GemEntities", "Product_Id", "dbo.ProductEntities");
            DropIndex("dbo.GemEntities", new[] { "Product_Id" });
            DropTable("dbo.GemEntities");
        }
    }
}
