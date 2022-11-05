
using EntityLayer.EITEntity;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

/// <summary>
/// Summary description for IEITBL
/// </summary>
/// 
namespace BusinessLogicLayer.EIT
{
    [ServiceContract]
    public interface IEITBL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "EITApplicationStatusUpdate")]
        List<clsOutput> EITApplicationStatusUpdate(EITEntity objEIT);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "EITPaymentStatusUpdate")]
        List<clsOutput> EITPaymentStatusUpdate(EITEntity objEIT);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "EITQueryStatusUpdate")]
        List<clsOutput> EITQueryStatusUpdate(EITEntity objEIT);
    }
}