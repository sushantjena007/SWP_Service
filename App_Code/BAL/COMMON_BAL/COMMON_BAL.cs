using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcessLayer.COMMON_DAL;
using EntityLayer.COMMON_Entity;

/// <summary>
/// Summary description for COMMON_BAL
/// </summary>
/// 

namespace BusinessAcessLayer.COMMON_BAL
{
    public class COMMON_BAL : ICOMMON_BAL
    {
        COMMON_DAL objCommonDal = new COMMON_DAL();
        public List<ApiReturnMessage> ApplicationStatusUpdate(List<CommonEntity> objcommon)
        {
            return objCommonDal.ApplicationStatusUpdate(objcommon);
        }
    }
}