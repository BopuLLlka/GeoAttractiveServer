namespace GeoAttractiveServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                        SecondImagePath = c.String(),
                        ThirdImagePath = c.String(),
                        Lat = c.Double(nullable: false),
                        Lon = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.TestDatas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Test = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Sights");
        }
    }
}
