namespace GalleryApp.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUrlColumnAddedToGalleryTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galleries", "ImageUrl");
        }
    }
}
