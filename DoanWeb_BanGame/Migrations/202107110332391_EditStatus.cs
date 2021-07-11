namespace DoanWeb_BanGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Enable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Games", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Status", c => c.String());
            DropColumn("dbo.Games", "Enable");
        }
    }
}
