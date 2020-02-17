namespace SyncaBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttrEdit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Blogs", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "Name", c => c.String(nullable: false));
        }
    }
}
