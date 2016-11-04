using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIoC.Datasource
{
    public interface IDataSource
    {
        IQueryable<T> DBSet<T>();

        void Add<T>(T model);
    }
}
