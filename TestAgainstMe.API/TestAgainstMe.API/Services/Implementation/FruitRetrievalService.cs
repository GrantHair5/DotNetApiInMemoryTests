using System;
using System.Collections.Generic;
using System.Linq;
using TestAgainstMe.API.Data;
using TestAgainstMe.API.Models;

namespace TestAgainstMe.API.Services.Implementation
{
    public class FruitRetrievalService : IFruitRetrievalService
    {
        private readonly IFruitBasket _fruitBasket;

        public FruitRetrievalService(IFruitBasket fruitBasket)
        {
            _fruitBasket = fruitBasket;
        }

        public IEnumerable<Fruit> GetBasketContents()
        {
            return _fruitBasket.GetBasketContents();
        }

        public IEnumerable<Fruit> GetAllInBasket(string name)
        {
            return _fruitBasket.GetBasketContents().Where(x => string.Equals(x.Name, name));
        }

        public Fruit Get(Guid id)
        {
            return _fruitBasket.Get(id);
        }
    }
}