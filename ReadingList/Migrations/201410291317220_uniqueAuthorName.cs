namespace ReadingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueAuthorName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Authors", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Authors", "Name");
        }
    }
}
