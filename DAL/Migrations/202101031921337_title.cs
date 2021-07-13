﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class title : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Title");
        }
    }
}
