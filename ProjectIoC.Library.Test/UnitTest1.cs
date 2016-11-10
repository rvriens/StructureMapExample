using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace ProjectIoC.Library.Test
{
    [TestClass]
    public class OrderServiceUnitTest
    {
        [TestMethod]
        public void NumberOfOrders_Is_Zero()
        {
            // Create datasource
            var datasource = MockRepository.GenerateStub<ProjectIoC.Datasource.IDataSource>();

            // Create orders
            var orders = new List<Order>();

            // Request orders
            datasource.Expect(q => q.DBSet<Order>()).Return(orders.AsQueryable());

            // Create service
            var service = MockRepository.GenerateStub<ProjectIoC.Library.IExternalOrderService>();

            // Service is beschikbaar
            service.Expect(q => q.IsAvailable()).Return(true);

            // create order service
            OrderService orderservice = new OrderService(datasource, service);
            // Assert 0
            Assert.AreEqual(0, orderservice.NumberOfOrders());

        }

        [TestMethod]
        public void NumberOfOrders_Service_Not_Available()
        {
            // Datasource anamkane
            var datasource = MockRepository.GenerateStub<ProjectIoC.Datasource.IDataSource>();

            // Create orders
            var orders = new List<Order>();

            // Request orders
            datasource.Expect(q => q.DBSet<Order>()).Return(orders.AsQueryable());

            // Create service
            var service = MockRepository.GenerateStub<ProjectIoC.Library.IExternalOrderService>();

            // Service is beschikbaar
            service.Expect(q => q.IsAvailable()).Return(false);

            // create order service
            OrderService orderservice = new OrderService(datasource, service);

            // Assert: Service not available result: -1
            Assert.AreEqual(-1, orderservice.NumberOfOrders());

        }

        [TestMethod]
        public void NumberOfOrders_One_Order()
        {
            // Create datasource
            var datasource = MockRepository.GenerateStub<ProjectIoC.Datasource.IDataSource>();

            // Create orders
            var orders = new List<Order>();
            orders.Add(new Order());

            // Request orders
            datasource.Expect(q => q.DBSet<Order>()).Return(orders.AsQueryable());

            // Create service
            var service = MockRepository.GenerateStub<ProjectIoC.Library.IExternalOrderService>();

            // Service is beschikbaar
            service.Expect(q => q.IsAvailable()).Return(true);

            // create order service
            OrderService orderservice = new OrderService(datasource, service);

            // Assert: one order available
            Assert.AreEqual(1, orderservice.NumberOfOrders());

        }
    }
}
