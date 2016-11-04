using ProjectIoC.Datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIoC.Library
{

    public class OrderService : IOrderService
    {
        private IDataSource _datasource;

        public OrderService(IDataSource datasource)
        {
            _datasource = datasource;
        }

        public Order GetOrder()
        {
            throw new NotImplementedException();
        }

        public int NumberOfOrders()
        {
           return _datasource.DBSet<Order>().Count();
        }

        public void SaveOrder(Order order)
        {
            _datasource.Add<Order>(order);
        }
    }
}
