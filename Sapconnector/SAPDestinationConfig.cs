using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sapconnector
{
    public class SAPDestinationConfig : IDestinationConfiguration
    {
        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public bool ChangeEventsSupported()
        {
            return false;
        }

        public RfcConfigParameters GetParameters(string destinationName)
        {
            RfcConfigParameters parms = new RfcConfigParameters();
            parms.Add(RfcConfigParameters.Name, "AS4");
            parms.Add(RfcConfigParameters.AppServerHost, "ussltcsnl1268.solutions.glbsnet.com");
            parms.Add(RfcConfigParameters.SystemNumber, "00");
            parms.Add(RfcConfigParameters.SystemID, "AS4");
            parms.Add(RfcConfigParameters.User, "BYRANNA");
            parms.Add(RfcConfigParameters.Password, "Welcome@123");
            parms.Add(RfcConfigParameters.Client, "100");
       

            return parms;
        }
    }
}