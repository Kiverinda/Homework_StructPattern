using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HomeworkStructPattern.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HomeworkStructPattern.Repositorys
{
    class AutomobileRepository : IRepositoryProduct<Automobile>
    {
        private string _pathToFile;
        private readonly ILogger<App> _logger;

        public AutomobileRepository(IOptions<AppSettings> appSettings, ILogger<App> logger)
        {
            _logger = logger;
            _pathToFile = appSettings.Value.PathToAutomobileRepo;
        }

        public async Task WriteProduct(Automobile product)
        {
            using (FileStream fs = new FileStream(_pathToFile, FileMode.Append))
            {
                await JsonSerializer.SerializeAsync<Automobile>(fs, product);
            }
        }

        public async Task WriteAllProducts(List<Automobile> products)
        {
            using FileStream createStream = File.Create(_pathToFile);
            await JsonSerializer.SerializeAsync(createStream, products);
        }

        public async Task<List<Automobile>> ReadProducts()
        {
            using FileStream openStream = File.OpenRead(_pathToFile);
            List<Automobile> products = await JsonSerializer.DeserializeAsync<List<Automobile>>(openStream);

            return products;
        }
    }
}
