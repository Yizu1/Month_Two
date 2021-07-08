using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_IRepository
{
    public interface ITid1LxinRepository<T>
    {
        List<T> Bang();
    }
}
