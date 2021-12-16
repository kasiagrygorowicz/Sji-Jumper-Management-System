using System;
using System.Xml.Linq;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Infrastructure.DTO
{
    public class SkiJumperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ForeName { get; set; }
        public string Country { get; set; }
        public DateTime DateTime { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }



        public override bool Equals(object o)
        {

            var s = o as SkiJumperDTO;
            if (s != null)
            {
                return (Id == s.Id &&
                    Name == s.Name &&
                    ForeName == s.ForeName &&
                    Country == s.Country &&
                    DateTime == s.DateTime &&
                    Weight == s.Weight &&
                    Height == s.Height
                    );
            }
            return false;
        }
    }
}
