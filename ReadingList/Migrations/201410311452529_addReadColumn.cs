namespace ReadingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReadColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Read", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Read");
        }
    }
}
