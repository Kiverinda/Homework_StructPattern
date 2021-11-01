using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using HomeworkStructPattern.Repositorys;
using HomeworkStructPattern.Models;
using HomeworkStructPattern.Controllers;
using System.Collections.Generic;
using HomeworkStructPattern.Adapters;

namespace HomeworkStructPattern
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private IControllerProduct<Clothing> _controllerClothing;
        private IControllerProduct<Automobile> _controllerAutomobile;
        private IController<IProduct> _controllerCart;

        public App(ILogger<App> logger, IControllerProduct<Clothing> controllerСlothing, 
            IControllerProduct<Automobile> controllerAutomobile, IController<IProduct> controllerCart)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _controllerClothing = controllerСlothing;
            _controllerAutomobile = controllerAutomobile;
            _controllerCart = controllerCart;
        }

        public async Task Run(string[] args)
        {
            _logger.LogInformation("Starting...");

            _controllerAutomobile.GenerationProducts();
            _controllerClothing.GenerationProducts();

            List<Automobile> automobile = _controllerAutomobile.GetAllProducts();
            List<Clothing> clothing = _controllerClothing.GetAllProducts();

            foreach (Clothing product in clothing)
            {
                _controllerCart.AddProduct(new AdapterForClothing(product));
            }

            foreach (Automobile product in automobile)
            {
                _controllerCart.AddProduct(new AdapterForAutomobile(product));
            }

            _logger.LogInformation("Finish !!!");
            Console.Read();
            await Task.CompletedTask;
        }
    }
}
