using HomeworkStructPattern.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkStructPattern.Repositorys;

namespace HomeworkStructPattern.Controllers
{
    public class ClothingController : IControllerProduct<Clothing>
    {
        private readonly ILogger<App> _logger;
        private readonly IRepositoryProduct<Clothing> _repository;

        public ClothingController(ILogger<App> logger, IRepositoryProduct<Clothing> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public void AddProduct(Clothing product)
        {
             _repository.WriteProduct(product);
        }

        public void AddProducts(List<Clothing> products)
        {
            _repository.WriteAllProducts(products);
        }

        public void GenerationProducts()
        {
            List<Clothing> products = new List<Clothing>();
            Random randomize = new Random();

            for (int i = 0; i < 10; i++)
            {
                products.Add(new Clothing($"Name_{i}", (int)randomize.Next(1, 70), (float)randomize.Next(100, 10000), 
                            $"http://test.com//Clothing{i}", $"decription{i}"));
                
            }

            AddProducts(products);
        }

        public List<Clothing> GetAllProducts()
        {
            return _repository.ReadProducts().Result;
        }
    }
}
