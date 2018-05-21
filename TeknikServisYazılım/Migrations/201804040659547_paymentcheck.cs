namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentcheck : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRegistrationForms", "PaymentCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRegistrationForms", "PaymentCheck");
        }
    }
}
