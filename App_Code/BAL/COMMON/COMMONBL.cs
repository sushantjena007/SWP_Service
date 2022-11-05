using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcessLayer.COMMON;
using EntityLayer.COMMON;

/// <summary>
/// Summary description for COMMONBL
/// </summary>
namespace BusinessLogicLayer.COMMON
{
    public class COMMONBL : ICOMMONBL
    {
        COMMONDAL objCommonDal = new COMMONDAL();
        public List<ReturnMessage> PushApplicationData(COMMONEntity objcommon)
        {
            return objCommonDal.PushApplicationData(objcommon);
        }
        public List<ApiReturnMessage> PayMentStatusUpdate(COMMONEntity objcommon)
        {
            return objCommonDal.PayMentStatusUpdate(objcommon);
        }
        public List<ApiReturnMessage> DemandStatusUpdate(COMMONEntity objcommon)
        {
            return objCommonDal.DemandStatusUpdate(objcommon);
        }
        public List<ApiReturnMessage> ApplicationStatusUpdate(COMMONEntity objcommon)
        {
            return objCommonDal.ApplicationStatusUpdate(objcommon);
        }       
    }
}