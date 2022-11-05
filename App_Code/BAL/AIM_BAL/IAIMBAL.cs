using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer.AIMEntity;

/// <summary>
/// Summary description for IAIMBAL
/// </summary>
namespace BusinessLogicLayer.AIM
{
    [ServiceContract]
    public interface IAIMBAL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateEinPc")]
        AIMStatusResponse UpdateEinPc(AIMEntity objPushData);
    }
}