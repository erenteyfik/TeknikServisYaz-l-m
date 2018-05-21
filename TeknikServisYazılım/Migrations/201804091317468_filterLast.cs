namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filterLast : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ServiceRegistrationForms", "StateFiler");
            DropColumn("dbo.ServiceRegistrationForms", "UserFiler");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceRegistrationForms", "UserFiler", c => c.String());
            AddColumn("dbo.ServiceRegistrationForms", "StateFiler", c => c.String());
        }
    }
}
