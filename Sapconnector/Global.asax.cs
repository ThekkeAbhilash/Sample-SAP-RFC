using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Sapconnector
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            string destinationConfigurationName = "QA";
            IDestinationConfiguration destinationConfig = null;
            bool IsDestinationInia = false;
            if (!IsDestinationInia)
            {
                destinationConfig = new SAPDestinationConfig();
                destinationConfig.GetParameters(destinationConfigurationName);
                if (RfcDestinationManager.TryGetDestination(destinationConfigurationName) == null)
                {
                    RfcDestinationManager.RegisterDestinationConfiguration(destinationConfig);
                    IsDestinationInia = true;
                }
            }
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}