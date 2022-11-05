using DataAcessLayer.PAReSHRAMDAL;
using EntityLayer.PAReSHRAM_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PAReSHRAMBAL
/// </summary>
namespace BusinessLogicLayer.PAReSHRAM
{
    public class PAReSHRAMBAL:IPAReSHRAMBAL
    {
        PAReSHRAMDAL objDal = new PAReSHRAMDAL();

        public List<clsOutput> PSMPaymentStatusUpdate(PAReSHRAM_Entity ObjParam)
        {
            return objDal.PSMPaymentStatusUpdate(ObjParam);
        }

        public List<clsOutput> PSMApplicationStatusUpdate(PAReSHRAM_Entity ObjParam)
        {
            return objDal.PSMApplicationStatusUpdate(ObjParam);
        }

        public List<clsOutput> PSMQueryStatusUpdate(PAReSHRAM_Entity ObjParam)
        {
            return objDal.PSMQueryStatusUpdate(ObjParam);
        }
    }
}