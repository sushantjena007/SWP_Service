using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer.APAA;

/// <summary>
/// Summary description for IAPAABL
/// </summary>
/// 
namespace BusinessLogicLayer.APAA
{
    [ServiceContract]
    public interface IAPAABL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ApplyWaterAllotment")]
        List<retMessage> ApplyWaterAllotment(APAAEntity objApaa);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "QueryRaised")]
        List<retMessage> QueryRaised(APAAEntity objApaa);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "QueryResponse")]
        List<retMessage> QueryResponse(APAAEntity objApaa);
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateStatus")]
        List<retMessage> UpdateStatus(APAAEntity objApaa);
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "IssueCertificate")]
        List<retMessage> IssueCertificate(APAAEntity objApaa);
    }
}