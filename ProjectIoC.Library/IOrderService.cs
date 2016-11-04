using ProjectIoC.Datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIoC.Library
{

    public interface IOrderService
    {

        Order GetOrder();

        int NumberOfOrders();


        void SaveOrder(Order order);
    }
}
