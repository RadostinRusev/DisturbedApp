namespace DisturbedAppsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "Link", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "Link", c => c.String(nullable: false));
        }
    }
}
