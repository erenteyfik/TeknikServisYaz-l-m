namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRegistrationForms", "SRFArrivalDatetime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRegistrationForms", "SRFArrivalDatetime");
        }
    }
}
