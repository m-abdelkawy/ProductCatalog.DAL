namespace ProductCatalog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Photo", c => c.Binary());
        }
    }
}
