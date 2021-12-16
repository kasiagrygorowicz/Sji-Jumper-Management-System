using System;
namespace Zawodnicy.Infrastructure
{
    public class Competition
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public SkiJump SkiJump{get; set;}
        public DateTime DateOfCompetition { get; set; }

            
       
    }
}
