using DataAcessLayer.EITDAL;
using EntityLayer.EITEntity;
using System.Collections.Generic;


/// <summary>
/// Summary description for EITBL
/// </summary>
/// 
namespace BusinessLogicLayer.EIT
{
    public class EITBL : IEITBL
    {
        EITDAL OBJEITDAL = new EITDAL();

        public List<clsOutput> EITApplicationStatusUpdate(EITEntity objEIT)
        {
            return OBJEITDAL.EITApplicationStatusUpdate(objEIT);
        }

        public List<clsOutput> EITPaymentStatusUpdate(EITEntity objEIT)
        {
            return OBJEITDAL.EITPaymentStatusUpdate(objEIT);
        }

        public List<clsOutput> EITQueryStatusUpdate(EITEntity objEIT)
        {
            return OBJEITDAL.EITQueryStatusUpdate(objEIT);
        }
    }
}