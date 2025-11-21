namespace MvcOnlineTicaretOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailId = c.Int(nullable: false, identity: true),
                        productName = c.String(maxLength: 30, unicode: false),
                        productInformation = c.String(maxLength: 2000, unicode: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetailId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "ProductId", "dbo.Products");
            DropIndex("dbo.Details", new[] { "ProductId" });
            DropTable("dbo.Details");
        }
    }
}
