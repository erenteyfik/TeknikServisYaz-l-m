namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupplierPaymentLists", "SupplierDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupplierPaymentLists", "SupplierDate");
        }
    }
}
