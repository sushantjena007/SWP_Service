using EntityLayer.FIREEntity;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

/// <summary>
/// Summary description for IFIREBL
/// </summary>
/// 
namespace BusinessLogicLayer.Fire
{
    [ServiceContract]
    public interface IFIREBL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "FireApplicationStatusUpdate")]
        List<clsOutput> FireApplicationStatusUpdate(FIREEntity objFire);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "FirePaymentUpdate")]
        List<clsOutput> FirePaymentUpdate(FIREEntity objFire);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "FireQueryCompliance")]
        List<clsOutput> FireQueryCompliance(FIREEntity objFire);
    }
}