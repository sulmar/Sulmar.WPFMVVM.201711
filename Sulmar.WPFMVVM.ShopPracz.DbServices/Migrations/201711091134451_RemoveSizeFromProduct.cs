namespace Sulmar.WPFMVVM.ShopPracz.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSizeFromProduct : DbMigration
    {
        public override void Up()
        {
            // TODO: Save Size to file


            DropColumn("dbo.Products", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Size", c => c.String());
        }
    }
}
