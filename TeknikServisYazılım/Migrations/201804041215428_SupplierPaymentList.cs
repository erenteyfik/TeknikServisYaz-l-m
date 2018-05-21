namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierPaymentList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierPaymentLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Income = c.Int(nullable: false),
                        Expense = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SupplierPaymentLists");
        }
    }
}
