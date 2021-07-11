namespace DoanWeb_BanGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlatformDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlatformDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlatformId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        PublicDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Platforms", t => t.PlatformId, cascadeDelete: true)
                .Index(t => t.PlatformId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ProducerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlatformDetails", "PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.PlatformDetails", "GameId", "dbo.Games");
            DropIndex("dbo.PlatformDetails", new[] { "GameId" });
            DropIndex("dbo.PlatformDetails", new[] { "PlatformId" });
            DropTable("dbo.Platforms");
            DropTable("dbo.PlatformDetails");
        }
    }
}
