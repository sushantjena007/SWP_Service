using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer.NSWSEntity;

/// <summary>
/// Summary description for INSWSBAL
/// </summary>
/// 
namespace BusinessLogicLayer.NSWS
{
    [ServiceContract]
    public interface INSWSBAL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "NSWSUserRegistration")]
        List<clsOutput1> NSWSUserRegistration(NSWSEntity objNsws);
    }
}