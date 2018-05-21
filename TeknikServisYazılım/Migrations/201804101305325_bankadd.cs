namespace TeknikServisYazılım.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bankadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Payment = c.Int(nullable: false),
                        WhoUser = c.String(),
                        BankDescription = c.String(),
                        BankTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Banks");
        }
    }
}
