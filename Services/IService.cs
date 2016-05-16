using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService<T>
    {
        T Execute();
        Task<T> ExecuteAsync();
    }

    public interface IService
    {

    }
}
