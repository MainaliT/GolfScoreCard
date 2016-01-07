namespace GoldScoreCard.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoldScoreCard.Models.ScoreCardDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GoldScoreCard.Models.ScoreCardDBContext context)
        {
            context.scores.AddOrUpdate(i => i.PlayerName,

                new ScoreCard
                {
                    PlayerName = "Parul",
                    Tees = "Blue",
                    Par = 5,
                    holeOne = 3,
                    holeTwo = 4,
                    holeThree = 5,
                    holeFour = 2,
                    holeFive = 1,
                    holeSix = 4,
                    holeSeven = 2,
                    holeEight = 3,
                    holeNine = 3
                });

        }
    }
}
