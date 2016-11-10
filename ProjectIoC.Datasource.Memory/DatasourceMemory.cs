using ProjectIoC.Datasource;
using ProjectIoC.Logger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIoC.Datasource.Memory
{
    public class DatasourceMemory : IDataSource
    {
        private IDictionary<Type, IList> _models;
        private ILogger _logger;
          
        public DatasourceMemory(ILogger logger)
        {
            _logger = logger;
            _models = new Dictionary<Type, IList>();
        }

        public void Add<T>(T model)
        {
            _logger.Log(string.Format("Add {0}", typeof(T).Name));
            IList list = null; 
            if (!_models.ContainsKey(typeof(T)))
            {
                list = new List<T>();
                _models.Add(typeof(T), list);
            }
            else
            {
                list = _models[typeof(T)];
            }
            list.Add(model);
        }

        public IQueryable<T> DBSet<T>()
        {
            _logger.Log(string.Format("Get {0}", typeof(T).Name));
            IList list = null;
            if (_models.ContainsKey(typeof(T)))
            {
                list = _models[typeof(T)];
            }
            return list != null ? list.Cast<T>().AsQueryable<T>() : new List<T>().AsQueryable();
        }
    }
}
