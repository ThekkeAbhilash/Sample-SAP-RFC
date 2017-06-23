using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Sapconnector
{
    public class SAPConnectorInterface
    {
        private RfcDestination rfcDestination;

        public bool TestConnection(string destinationName)
        {
            bool result = false;

            try
            {
                rfcDestination = RfcDestinationManager.GetDestination(destinationName);
                if (rfcDestination != null)
                {
                    rfcDestination.Ping();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Failure Error :" + ex.Message);
            }

            return result;
        }

        public void RetrieveData(string destinationName)
        {
            DataSet ds = new DataSet();
            try
            {
                
                if (rfcDestination != null)
                {
                    rfcDestination = RfcDestinationManager.GetDestination(destinationName);

                }
                RfcRepository rfcRepository = rfcDestination.Repository;
                IRfcFunction rfcFunction = rfcRepository.CreateFunction("ZPMFM_GET_RESOURCE_CAPACITY");
                rfcFunction.Invoke(rfcDestination);
                //ds.Tables.Add(ConvertToDotNetTable)
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Failure Error :" + ex.Message);
            }
        }
    }
}