namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        userId = c.Int(),
                        Question_id = c.Int(),
                        DateAndTime = c.DateTime(nullable: false),
                        CheckedByAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.Question_id)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.Question_id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        userId = c.Int(),
                        DateAndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        RepeatPassword = c.String(),
                        Role = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VoteType = c.Boolean(nullable: false),
                        VoteDate = c.DateTime(nullable: false),
                        UserID = c.Int(),
                        AnswerId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Answers", t => t.AnswerId)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.AnswerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "userId", "dbo.Users");
            DropForeignKey("dbo.Answers", "Question_id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "userId", "dbo.Users");
            DropForeignKey("dbo.Votes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Votes", "AnswerId", "dbo.Answers");
            DropIndex("dbo.Votes", new[] { "AnswerId" });
            DropIndex("dbo.Votes", new[] { "UserID" });
            DropIndex("dbo.Questions", new[] { "userId" });
            DropIndex("dbo.Answers", new[] { "Question_id" });
            DropIndex("dbo.Answers", new[] { "userId" });
            DropTable("dbo.Votes");
            DropTable("dbo.Users");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
