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
    class СlothingRepository : IRepositoryProduct<Clothing>
    {
        private string _pathToFile;
        private readonly ILogger<App> _logger;

        public СlothingRepository(IOptions<AppSettings> appSettings, ILogger<App> logger)
        {
            _logger = logger;
            _pathToFile = appSettings.Value.PathToClothingRepo;
        }

        public async Task WriteProduct(Clothing product)
        {
            using (FileStream fs = new FileStream(_pathToFile, FileMode.Append))
            {
                await JsonSerializer.SerializeAsync<Clothing>(fs, product);
            }
        }

        public async Task WriteAllProducts(List<Clothing> products)
        {
            using FileStream createStream = File.Create(_pathToFile);
            await JsonSerializer.SerializeAsync(createStream, products);
        }

        public async Task<List<Clothing>> ReadProducts()
        {
            using FileStream openStream = File.OpenRead(_pathToFile);
            List<Clothing> products = await JsonSerializer.DeserializeAsync<List<Clothing>>(openStream);

            return products;
        }
    }
}
