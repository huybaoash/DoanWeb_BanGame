namespace DoanWeb_BanGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartGame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(),
                        GameId = c.Int(nullable: false),
                        GameName = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleId = c.Int(nullable: false),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carts");
        }
    }
}
