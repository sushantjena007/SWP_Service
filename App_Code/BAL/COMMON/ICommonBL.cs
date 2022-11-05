
using EntityLayer.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

/// <summary>
/// Summary description for ICOMMONBL
/// </summary>
namespace BusinessLogicLayer.COMMON
{
    [ServiceContract]
    public interface ICOMMONBL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,RequestFormat =WebMessageFormat.Json, UriTemplate = "PushApplicationData")]
        List<ReturnMessage> PushApplicationData(COMMONEntity objcommon);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "PayMentStatusUpdate")]
        List<ApiReturnMessage> PayMentStatusUpdate(COMMONEntity objcommon);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "DemandStatusUpdate")]
        List<ApiReturnMessage> DemandStatusUpdate(COMMONEntity objcommon);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ApplicationStatusUpdate")]
        List<ApiReturnMessage> ApplicationStatusUpdate(COMMONEntity objcommon);
       
    }
   
}