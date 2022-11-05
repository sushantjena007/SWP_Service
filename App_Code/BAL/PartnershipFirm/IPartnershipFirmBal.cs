using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer.PartnershipFirmEntity;
using SWP_Services.DAL;

namespace BusinessLogicLayer.PartnershipFirm
{
     [ServiceContract]
    public interface IPartnershipFirmBal
    {


         [OperationContract]
         [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json, UriTemplate = "GETUserProfiles")]
         List<EntityLayer.PartnershipFirmEntity.PartnershipFirmUserProfile> GetUserProfile(EntityLayer.PartnershipFirmEntity.AuthStatus objAuthStatus);


         [OperationContract]
         [WebInvoke(Method = "POST",ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDatas")]
         List<EntityLayer.PartnershipFirmEntity.PartnershipFirmPushDataStatus> SWPPushData(EntityLayer.PartnershipFirmEntity.PartnershipFirmPushData objPushData);
    }
}
