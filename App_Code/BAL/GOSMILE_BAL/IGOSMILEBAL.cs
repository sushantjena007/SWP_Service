using EntityLayer.GOSMILE_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;

/// <summary>
/// Summary description for IGOSMILEBAL
/// </summary>
/// 
namespace BusinessLogicLayer.GOSMILE
{
    [ServiceContract]
    public interface IGOSMILEBAL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "FetchPaymentDetails")]
        List<GOSMILEStatusResponse> FetchPaymentDetails(GOSMILEEntity ObjParam);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ApplicationStatusUpdate")]
        List<clsOutput> ApplicationStatusUpdate(GOSMILEEntity ObjParam);
    }
}