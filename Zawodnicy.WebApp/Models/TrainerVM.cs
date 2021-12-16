using System;

namespace Zawodnicy.WebApp.Models
{
    public class TrainerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
    }
}