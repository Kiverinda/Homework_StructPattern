using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Repositorys
{
    public interface IRepository<T>
    {
        public Task<List<T>> ReadProducts();
        public Task WriteProduct(T t);
    }
}
