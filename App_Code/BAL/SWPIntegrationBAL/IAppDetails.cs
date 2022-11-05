using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace BusinessLogicLayer.SWPIntegrationBAL
{
     [ServiceContract]
  public  interface IAppDetails
    {

      [OperationContract]
      [WebInvoke(Method = "GET",
      ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "getTest/{userid}/{swpCode}")]
      string getTest(string userid, string swpCode);
    }
}
