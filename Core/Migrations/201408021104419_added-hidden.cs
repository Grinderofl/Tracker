namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedhidden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Hidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "Hidden");
        }
    }
}
