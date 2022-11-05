using EntityLayer.COMMON_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

/// <summary>
/// Summary description for ICOMMON_BAL
/// </summary>
namespace BusinessAcessLayer.COMMON_BAL
{
    [ServiceContract]
    public interface ICOMMON_BAL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ApplicationStatusUpdate")]
        List<ApiReturnMessage> ApplicationStatusUpdate(List<CommonEntity> objcommon);
    }
}
