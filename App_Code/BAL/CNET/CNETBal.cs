using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessLayer.CnetDAL;
using EntityLayer.CNETEntity;

/// <summary>
/// Summary description for CNETBal
/// </summary>

namespace BusinessLogicLayer.CNET
{
    public class CNETBal : ICNETBal
    {
        public List<CNETPushDataStatus> UpdatePEALIngrationWithIDCOStatus(EntityLayer.CNETEntity.CNET objPushData)
        {
            CnetDAL objDal = new CnetDAL();
            return objDal.UpdatePEALIngrationWithIDCOStatus(objPushData);
        }
        public List<CNETPushDataStatus> SWPCNETPushDatas(EntityLayer.CNETEntity.CNET objPushData)
        {
            CnetDAL objDal = new CnetDAL();
            return objDal.SWPPushDataCNET(objPushData);
        }  
        public List<CNETPushDataStatus> SWPPushQuery(CNETPushQueryEntity objPushData)
        {
            CnetDAL objDal = new CnetDAL();
            return objDal.SWPPushQuery(objPushData);
        }

        public List<DashboardDtl> DashboardCount(string stryear)
        {
            CnetDAL objDal = new CnetDAL();
            return objDal.DashboardCount(stryear);
        }
    }
}