using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Controllers
{
    public interface IController<T>
    {
        public List<T> GetAllProducts();
        public void AddProduct (T t);
    }
}
