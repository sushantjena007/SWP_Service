using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer.CRMEntity;

/// <summary>
/// Summary description for ICRMBAL
/// </summary>

namespace BusinessLogicLayer.CRM
{
    [ServiceContract]
    public interface ICRMBAL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getPEALInfo")]
        CRMPealStatusResponse getPEALInfo(CRMEntity objPushData);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getServiceInfo")]
        CRMServiceStatusResponse getServiceInfo(CRMEntity objPushData);
    }
}