using System;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Infrastructure
{
    public class SkiJump
    {
        public int Id { get; set; }
        public City City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public int K{ get; set; }
        public int Sedz { get; set; }

        

    }
}
