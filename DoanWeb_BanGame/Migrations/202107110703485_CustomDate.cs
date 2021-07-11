namespace DoanWeb_BanGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "YearBought", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "YearBought");
        }
    }
}
