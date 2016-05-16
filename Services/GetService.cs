using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class GetService<T> : IService<T>
    {
        public abstract T Execute();

        public abstract Task<T> ExecuteAsync();
    }
}
