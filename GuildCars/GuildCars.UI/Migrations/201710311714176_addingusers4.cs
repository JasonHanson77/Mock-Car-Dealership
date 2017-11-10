namespace GuildCars.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingusers4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
    }
}
