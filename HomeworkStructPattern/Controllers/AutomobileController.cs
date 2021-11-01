using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkStructPattern.Models;
using HomeworkStructPattern.Repositorys;
using Microsoft.Extensions.Logging;

namespace HomeworkStructPattern.Controllers
{
    public class AutomobileController : IControllerProduct<Automobile>
    {
        private readonly ILogger<App> _logger;
        private readonly IRepositoryProduct<Automobile> _repository;

        public AutomobileController(ILogger<App> logger, IRepositoryProduct<Automobile> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async void AddProduct(Automobile product)
        {
            await _repository.WriteProduct(product);
        }

        public void AddProducts(List<Automobile> products)
        {
            _repository.WriteAllProducts(products);
        }

        public void GenerationProducts()
        {
            List<Automobile> products = new List<Automobile>();
            Random randomize = new Random();

            for (int i = 0; i < 10; i++)
            {
                products.Add(new Automobile($"Name_{i}", "black", (float)randomize.Next(1, 370), (float)randomize.Next(100, 10000), $"specification{i}", $"http://test.com//Clothing{i}"));

            }

            AddProducts(products);
        }

        public List<Automobile> GetAllProducts()
        {
            return _repository.ReadProducts().Result;
        }
    }
}
