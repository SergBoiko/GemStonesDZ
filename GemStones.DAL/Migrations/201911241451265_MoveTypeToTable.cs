namespace GemStones.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveTypeToTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductEntities", "Type_Id", c => c.Int());
            CreateIndex("dbo.ProductEntities", "Type_Id");


            Sql(@"INSERT INTO [TypeEntities](Name) SELECT DISTINCT Type FROM ProductEntities");
            Sql(@"UPDATE [ProductEntities] SET Type_Id = [TypeEntities].Id FROM ProductEntities INNER JOIN TypeEntities ON ProductEntities.Type = TypeEntities.Name");

            AddForeignKey("dbo.ProductEntities", "Type_Id", "dbo.TypeEntities", "Id");
            DropColumn("dbo.ProductEntities", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductEntities", "Type", c => c.String());
            DropForeignKey("dbo.ProductEntities", "Type_Id", "dbo.TypeEntities");

            Sql(@"UPDATE ProductEntities SET Type = TypeEntities.Name FROM ProductEntities JOIN TypeEntities ON Type_Id = Type.Id");

            DropIndex("dbo.ProductEntities", new[] { "Type_Id" });
            DropColumn("dbo.ProductEntities", "Type_Id");
            DropTable("dbo.TypeEntities");
        }
    }
}
