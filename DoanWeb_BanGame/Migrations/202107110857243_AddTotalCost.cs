namespace DoanWeb_BanGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalCost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "TotalCost");
        }
    }
}
