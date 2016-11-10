using ProjectIoC.Datasource;
using ProjectIoC.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIoC.Library
{

    public class ExternalOrderService : IExternalOrderService
    {
        private ILogger _logger;

        public ExternalOrderService(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsAvailable()
        {
            _logger.Log("service is available");

            return true;
        }
    }
}
