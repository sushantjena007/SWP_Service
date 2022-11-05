using EntityLayer.PAReSHRAM_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IPAReSHRAMDAL
/// </summary>

namespace DataAcessLayer.PAReSHRAMDAL
{
    public interface IPAReSHRAMDAL
    {
        List<clsOutput> PSMPaymentStatusUpdate(PAReSHRAM_Entity ObjParam);
        List<clsOutput> PSMApplicationStatusUpdate(PAReSHRAM_Entity ObjParam);
        List<clsOutput> PSMQueryStatusUpdate(PAReSHRAM_Entity ObjParam);
    }
}