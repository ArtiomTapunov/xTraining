namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 4000),
                        RepeatCount = c.Int(nullable: false),
                        SetCount = c.Int(nullable: false),
                        MuscleGroup = c.String(nullable: false, maxLength: 4000),
                        UserID = c.Int(nullable: false),
                        ProgramTitle = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.UserAccounts", "Sex", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "Sex");
            DropTable("dbo.Exercises");
        }
    }
}
