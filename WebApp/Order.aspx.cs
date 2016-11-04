using ProjectIoC.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNumberOfOrders.Text = String.Format("Orders={0}",WebApp.Global.MyContainer.GetInstance<IOrderService>().NumberOfOrders());
        }

        protected void OnAddOrder_Click(object sender, EventArgs e)
        {
            ProjectIoC.Library.Order order = new ProjectIoC.Library.Order();
            WebApp.Global.MyContainer.GetInstance<IOrderService>().SaveOrder(order);
        }
    }
}