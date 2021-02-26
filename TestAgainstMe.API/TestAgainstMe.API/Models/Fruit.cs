using System;

namespace TestAgainstMe.API.Models
{
    public class Fruit
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public bool IsRipe { get; set; }
    }
}