namespace GoldScoreCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScoreCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        Tees = c.String(),
                        Par = c.Int(nullable: false),
                        holeOne = c.Int(nullable: false),
                        holeTwo = c.Int(nullable: false),
                        holeThree = c.Int(nullable: false),
                        holeFour = c.Int(nullable: false),
                        holeFive = c.Int(nullable: false),
                        holeSix = c.Int(nullable: false),
                        holeSeven = c.Int(nullable: false),
                        holeEight = c.Int(nullable: false),
                        holeNine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScoreCards");
        }
    }
}
