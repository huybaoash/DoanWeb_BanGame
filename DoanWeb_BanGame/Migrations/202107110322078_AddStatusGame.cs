namespace DoanWeb_BanGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Status");
        }
    }
}
