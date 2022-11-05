using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessLayer.PartnershipFirmDAL;
using EntityLayer.PartnershipFirmEntity;


namespace BusinessLogicLayer.PartnershipFirm
{
    public class PartnershipFirmBal : IPartnershipFirmBal
    {



        public List<EntityLayer.PartnershipFirmEntity.PartnershipFirmUserProfile> GetUserProfile(EntityLayer.PartnershipFirmEntity.AuthStatus objAuthStatus)
        {
            PartnershipFirmDAL objDal = new PartnershipFirmDAL();
            return objDal.ViewInvestorDetails(objAuthStatus);
        }

        public List<EntityLayer.PartnershipFirmEntity.PartnershipFirmPushDataStatus> SWPPushData(EntityLayer.PartnershipFirmEntity.PartnershipFirmPushData objPushData)
        {
            PartnershipFirmDAL objDal = new PartnershipFirmDAL();
            return objDal.SWPPushDataPartnershipFirm(objPushData);
        }
     


     
    }
}
