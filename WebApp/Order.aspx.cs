
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNet.Identity.Owin;
using ProjectIoC.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Order : BasePage
    {
        private IOrderService _orderService;

        protected Order()
        {
        }

        public Order(IOrderService orderService)
        {
            _orderService = orderService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Logger.Log("Hi");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblNumberOfOrders.Text = String.Format("Orders={0}", _orderService.NumberOfOrders()); //WebApp.Global.MyContainer.GetInstance<IOrderService>().NumberOfOrders());
        }

        protected void OnAddOrder_Click(object sender, EventArgs e)
        {
            ProjectIoC.Library.Order order = new ProjectIoC.Library.Order();
            // WebApp.Global.MyContainer.GetInstance<IOrderService>().SaveOrder(order);
            _orderService.SaveOrder(order);
        }
    }
}