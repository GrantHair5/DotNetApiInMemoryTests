using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestAgainstMe.API.Models;
using TestAgainstMe.API.Services;

namespace TestAgainstMe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        private readonly IFruitRetrievalService _fruitRetrievalService;

        public FruitController(IFruitRetrievalService fruitRetrievalService)
        {
            _fruitRetrievalService = fruitRetrievalService;
        }

        [HttpGet]
        [Route("FruitsInBasket")]
        public IEnumerable<Fruit> GetAllInBasket([FromQuery] string nameOfFruit)
        {
            return _fruitRetrievalService.GetAllInBasket(nameOfFruit);
        }

        [HttpGet]
        [Route("Basket")]
        public IEnumerable<Fruit> GetBasketContents()
        {
            return _fruitRetrievalService.GetBasketContents();
        }

        [HttpGet]
        public Fruit GetFruit([FromQuery] Guid id)
        {
            return _fruitRetrievalService.Get(id);
        }
    }
}