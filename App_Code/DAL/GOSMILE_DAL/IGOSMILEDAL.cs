
using EntityLayer.GOSMILE_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IGOSMILEDAL
/// </summary>
/// 
namespace DataAcessLayer.GOSMILEDAL
{
    public interface IGOSMILEDAL
    {
        List<GOSMILEStatusResponse> FetchPaymentDetails(GOSMILEEntity ObjParam);
        List<clsOutput> ApplicationStatusUpdate(GOSMILEEntity ObjParam);

    }
}