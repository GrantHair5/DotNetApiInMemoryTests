using System;
using System.Collections.Generic;
using TestAgainstMe.API.Models;

namespace TestAgainstMe.API.Services
{
    public interface IFruitRetrievalService
    {
        public IEnumerable<Fruit> GetBasketContents();

        public IEnumerable<Fruit> GetAllInBasket(string name);

        public Fruit Get(Guid id);
    }
}