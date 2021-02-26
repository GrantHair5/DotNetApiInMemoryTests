using System;
using System.Collections.Generic;
using TestAgainstMe.API.Models;

namespace TestAgainstMe.API.Data
{
    public interface IFruitBasket
    {
        public IEnumerable<Fruit> GetBasketContents();

        public Fruit Get(Guid id);
    }
}