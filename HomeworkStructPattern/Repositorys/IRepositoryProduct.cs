using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Repositorys
{
    public interface IRepositoryProduct<T> : IRepository<T>
    {
        public Task WriteAllProducts(List<T> t);
    }
}
