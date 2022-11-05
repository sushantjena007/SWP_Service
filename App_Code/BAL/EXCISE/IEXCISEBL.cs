
using EntityLayer.EXCISEEntity;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

/// <summary>
/// Summary description for IEXCISEBL
/// </summary>
/// 
namespace BusinessLogicLayer.Excise
{
    [ServiceContract]
    public interface IEXCISEBL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ExciseApplicationStatusUpdate")]
        List<clsOutput> ExciseApplicationStatusUpdate(EXCISEEntity objExcise);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ExcisePaymentStatusUpdate")]
        List<clsOutput> ExcisePaymentStatusUpdate(EXCISEEntity objExcise);

        //[OperationContract]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ExciseQueryStatusUpdate")]
        //List<clsOutput> ExciseQueryStatusUpdate(EXCISEEntity objExcise);        
    }
}