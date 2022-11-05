using EntityLayer.PAReSHRAM_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

/// <summary>
/// Summary description for IPAReSHRAMBAL
/// </summary>
namespace BusinessLogicLayer.PAReSHRAM
{
    [ServiceContract]
    public interface IPAReSHRAMBAL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "PSMPaymentStatusUpdate")]
        List<clsOutput> PSMPaymentStatusUpdate(PAReSHRAM_Entity ObjParam);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "PSMApplicationStatusUpdate")]
        List<clsOutput> PSMApplicationStatusUpdate(PAReSHRAM_Entity ObjParam);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "PSMQueryStatusUpdate")]
        List<clsOutput> PSMQueryStatusUpdate(PAReSHRAM_Entity ObjParam);
    }
}