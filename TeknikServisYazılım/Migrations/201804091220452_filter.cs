namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRegistrationForms", "StateFiler", c => c.String());
            AddColumn("dbo.ServiceRegistrationForms", "UserFiler", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRegistrationForms", "UserFiler");
            DropColumn("dbo.ServiceRegistrationForms", "StateFiler");
        }
    }
}
