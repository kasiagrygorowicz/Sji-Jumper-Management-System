using System;
namespace Zawodnicy.Core.Domain
{
    public class SkiJumper
    {
       
       
 public int Id { get; set; }
        public string Name { get; set; }
        public string ForeName { get; set; }
        public string Country { get; set; }
        public DateTime DateTime { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public Trainer Trainer { get; set; }
        
    }
}
