using DataAcessLayer.GOSMILEDAL;
using EntityLayer.GOSMILE_Entity;
using SWP_Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GOSMILEBAL
/// </summary>
/// 
namespace BusinessLogicLayer.GOSMILE
{
    public class GOSMILEBAL : IGOSMILEBAL
    {
        GOSMILEDAL objDal = new GOSMILEDAL();
        public List<GOSMILEStatusResponse> FetchPaymentDetails(GOSMILEEntity ObjParam)
        {            
            return objDal.FetchPaymentDetails(ObjParam);
        }
        public List<clsOutput> ApplicationStatusUpdate(GOSMILEEntity ObjParam)
        {
            return objDal.ApplicationStatusUpdate(ObjParam);
        }
    }
}