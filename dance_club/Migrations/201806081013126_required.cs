namespace dance_club.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Activities", new[] { "CategoryID" });
            AlterColumn("dbo.Activities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "CategoryID", c => c.Int());
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Surname", c => c.String(nullable: false));
            CreateIndex("dbo.Activities", "CategoryID");
            AddForeignKey("dbo.Activities", "CategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Activities", new[] { "CategoryID" });
            AlterColumn("dbo.Employees", "Surname", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Activities", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Activities", "Name", c => c.String());
            CreateIndex("dbo.Activities", "CategoryID");
            AddForeignKey("dbo.Activities", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}
