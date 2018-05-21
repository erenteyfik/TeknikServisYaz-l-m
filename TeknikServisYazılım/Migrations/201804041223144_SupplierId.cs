namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupplierPaymentLists", "SupplierId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupplierPaymentLists", "SupplierId");
        }
    }
}
