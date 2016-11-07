using ProjectIoC.Logger;
using StructureMap.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class BasePage : System.Web.UI.Page
    {

        public ILogger Logger { get; set; }

    }
}