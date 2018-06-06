namespace GeoAttractiveServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SityAndType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sights", "Sity", c => c.Int(nullable: false));
            AddColumn("dbo.Sights", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Sights", "SecondImagePath");
            DropColumn("dbo.Sights", "ThirdImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sights", "ThirdImagePath", c => c.String());
            AddColumn("dbo.Sights", "SecondImagePath", c => c.String());
            DropColumn("dbo.Sights", "Type");
            DropColumn("dbo.Sights", "Sity");
        }
    }
}
