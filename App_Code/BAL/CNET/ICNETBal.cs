using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer.CNETEntity;
using SWP_Services.DAL;

/// <summary>
/// Summary description for ICNETBal
/// </summary>

namespace BusinessLogicLayer.CNET
{
    [ServiceContract]
    public interface ICNETBal
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdatePEALIngrationWithIDCOStatus")]
        List<EntityLayer.CNETEntity.CNETPushDataStatus> UpdatePEALIngrationWithIDCOStatus(EntityLayer.CNETEntity.CNET objPushData);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPCNETPushDatas")]
        List<EntityLayer.CNETEntity.CNETPushDataStatus> SWPCNETPushDatas(EntityLayer.CNETEntity.CNET objPushData);

        //[OperationContract]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //string SWPPushQuery(string ApplicationNumber, int NoOfTime, string Remark, string Key, string statuscode, string IDCOStatus);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushQuery")]
        List<EntityLayer.CNETEntity.CNETPushDataStatus> SWPPushQuery(CNETPushQueryEntity objPushData);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "DashboardCount/{stryear}")]
        List<DashboardDtl> DashboardCount(string stryear);
    }
}