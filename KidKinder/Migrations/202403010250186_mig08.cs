namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig08 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Galleries", "ImageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Galleries", "ImageStatus", c => c.String());
        }
    }
}
