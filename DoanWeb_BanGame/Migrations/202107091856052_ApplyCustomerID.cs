namespace DoanWeb_BanGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyCustomerID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Bills", name: "Customer_Id", newName: "CustomerID");
            RenameIndex(table: "dbo.Bills", name: "IX_Customer_Id", newName: "IX_CustomerID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Bills", name: "IX_CustomerID", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.Bills", name: "CustomerID", newName: "Customer_Id");
        }
    }
}
