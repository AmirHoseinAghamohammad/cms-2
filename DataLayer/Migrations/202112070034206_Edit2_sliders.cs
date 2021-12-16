namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit2_sliders : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sliders", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Sliders", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sliders", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
