namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class descriptionAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupplierPaymentLists", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupplierPaymentLists", "Description");
        }
    }
}
