using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer.PartnershipFirmEntity;

/// <summary>
/// Summary description for IPartnershipFirmDAL
/// </summary>
/// 

namespace DataAcessLayer.PartnershipFirmDAL
{

    public interface IPartnershipFirmDAL
    {
        List<PartnershipFirmUserProfile> ViewInvestorDetails(EntityLayer.PartnershipFirmEntity.AuthStatus objUser);
        List<PartnershipFirmPushDataStatus> SWPPushDataPartnershipFirm(PartnershipFirmPushData objDATA);
    }
}