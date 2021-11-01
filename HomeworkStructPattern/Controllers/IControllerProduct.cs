using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Controllers
{
    public interface IControllerProduct<T> : IController<T>
    {
        public void GenerationProducts();
    }
}
