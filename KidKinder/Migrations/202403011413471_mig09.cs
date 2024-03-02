namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig09 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "GalleryPart", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galleries", "GalleryPart");
        }
    }
}
