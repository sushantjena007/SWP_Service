using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer.CRMEntity;


/// <summary>
/// Summary description for ICRMDAL
/// </summary>
namespace DataAcessLayer.CRMDAL
{
    public interface ICRMDAL
    {
        CRMPealStatusResponse getPEALInfo(CRMEntity objDATA);
        CRMServiceStatusResponse getServiceInfo(CRMEntity objDATA);   
    }
}