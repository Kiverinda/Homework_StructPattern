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
    class СartRepository : IRepository<IProduct>
    {
        private string _pathToFile;
        private readonly ILogger<App> _logger;

        public СartRepository(IOptions<AppSettings> appSettings, ILogger<App> logger)
        {
            _logger = logger;
            _pathToFile = appSettings.Value.PathToCartRepo;
        }

        public async Task<List<IProduct>> ReadProducts()
        {
            using FileStream openStream = File.OpenRead(_pathToFile);
            List<IProduct> products = await JsonSerializer.DeserializeAsync<List<IProduct>>(openStream);
            return products;
        }

        public async Task WriteProduct(IProduct product)
        {
            using (FileStream fs = new FileStream(_pathToFile, FileMode.Append))
            {
                await JsonSerializer.SerializeAsync<IProduct>(fs, product);
            }
        }
    }
}
