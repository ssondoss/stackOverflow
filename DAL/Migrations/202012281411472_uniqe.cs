namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Users", "Email", unique: true, name: "Email_Index");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "Email_Index");
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
    }
}
