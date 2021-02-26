using System;
using System.Collections.Generic;
using System.Linq;
using TestAgainstMe.API.Data;
using TestAgainstMe.API.Models;

namespace TestAgainstMe.API.InMemoryTests.Stubs
{
    public class StubbedFruitBasket : IFruitBasket
    {
        private readonly IEnumerable<Fruit> _fruitBasket = PopulateFruitBasket();

        public static IEnumerable<Fruit> PopulateFruitBasket()
        {
            return new List<Fruit>
            {
                new Fruit
                {
                    Color = "Red",
                    Id = Guid.Parse("58E68249-A9F5-49E9-90A1-38421F056268"), IsRipe = true,
                    Name = "Apple"
                },
                new Fruit
                {
                    Color = "Green",
                    Id = Guid.Parse("58E68249-A9F5-49E9-90A1-38421F056267"), IsRipe = true,
                    Name = "Grape"
                }
            };
        }

        public IEnumerable<Fruit> GetBasketContents()
        {
            return _fruitBasket;
        }

        public Fruit Get(Guid id)
        {
            return _fruitBasket.Single(f => f.Id == id);
        }
    }
}