using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GoldScoreCard.Models
{
    public class ScoreCard
    {

        public int ID { set; get; }

        [Display(Name = "Name")]
        public string PlayerName { get; set; }

        public string Tees { get; set; }

        public int Par { get; set; }

        [Display(Name = "One")]
        public int holeOne { get; set; }

        [Display(Name = "Two")]
        public int holeTwo { get; set; }

        [Display(Name = "Three")]
        public int holeThree { get; set; }

        [Display(Name = "Four")]
        public int holeFour { get; set; }

        [Display(Name = "Five")]
        public int holeFive { get; set; }

        [Display(Name = "Six")]
        public int holeSix { get; set; }

        [Display(Name = "Seven")]
        public int holeSeven { get; set; }

        [Display(Name = "Eight")]
        public int holeEight { get; set; }

        [Display(Name = "Nine")]
        public int holeNine { get; set; }

        [Display(Name = "Total")]
        public int Total
        {
            get
            {
                int sum = 0;

                int[] holes = new int[] { holeOne, holeTwo, holeThree, holeFour, holeFive, holeSix, holeSeven, holeEight, holeNine };

                for (int i = 0; i < holes.Length; i++)
                {
                    sum += holes[i];
                }          

                return sum;
            }
        }       
    }


    public class ScoreCardDBContext : DbContext
    {
        public DbSet<ScoreCard> scores { get; set; }
    }
    
}