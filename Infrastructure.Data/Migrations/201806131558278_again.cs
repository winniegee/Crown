namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Products_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Products_Id");
            AddForeignKey("dbo.Orders", "Products_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Products_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Products_Id" });
            DropColumn("dbo.Orders", "Products_Id");
        }
    }
}
