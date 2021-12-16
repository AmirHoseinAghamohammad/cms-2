namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sliders", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "ImageName", c => c.String(nullable: false));
        }
    }
}
