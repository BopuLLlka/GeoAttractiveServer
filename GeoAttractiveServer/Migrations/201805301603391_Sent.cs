namespace GeoAttractiveServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SentAttractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                        Sity = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Lat = c.Double(nullable: false),
                        Lon = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SentAttractions");
        }
    }
}
