namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbatteryserialno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PBatterySerialNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PBatterySerialNumber");
        }
    }
}
