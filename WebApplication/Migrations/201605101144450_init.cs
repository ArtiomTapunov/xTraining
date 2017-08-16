namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 4000),
                        LastName = c.String(nullable: false, maxLength: 4000),
                        Email = c.String(nullable: false, maxLength: 4000),
                        Username = c.String(nullable: false, maxLength: 4000),
                        Password = c.String(nullable: false, maxLength: 4000),
                        ConfirmPassword = c.String(maxLength: 4000),
                        Role = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAccounts");
        }
    }
}
