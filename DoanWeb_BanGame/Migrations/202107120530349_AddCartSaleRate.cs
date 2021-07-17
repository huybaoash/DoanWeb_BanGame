namespace DoanWeb_BanGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartSaleRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Rate");
        }
    }
}
