using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcessLayer.CRMDAL;
using EntityLayer.CRMEntity;


/// <summary>
/// Summary description for CRMBAL
/// </summary>
/// 
namespace BusinessLogicLayer.CRM
{
    public class CRMBAL : ICRMBAL
    {
        public CRMPealStatusResponse getPEALInfo(CRMEntity objPushData)
        {
            CRMDAL objDal = new CRMDAL();
            return objDal.getPEALInfo(objPushData);
        }

        public CRMServiceStatusResponse getServiceInfo(CRMEntity objPushData)
        {
            CRMDAL objDal = new CRMDAL();
            return objDal.getServiceInfo(objPushData);
        }
    }   
}