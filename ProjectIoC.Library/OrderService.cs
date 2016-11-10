using ProjectIoC.Datasource;
using ProjectIoC.Logger;
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
        private IExternalOrderService _externalOrderService;

        public OrderService(IDataSource datasource, IExternalOrderService service)
        {
            _datasource = datasource;
            _externalOrderService = service;


        }

        public Order GetOrder()
        {
            throw new NotImplementedException();
        }

        public int NumberOfOrders()
        {
           return _externalOrderService.IsAvailable() ? _datasource.DBSet<Order>().Count() : -1;
        }

        public void SaveOrder(Order order)
        {
            _datasource.Add<Order>(order);
        }
    }
}
