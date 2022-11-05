using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer.CNETEntity;


/// <summary>
/// Summary description for ICnetDAL
/// </summary>

namespace DataAcessLayer.CnetDAL
{
    public interface ICnetDAL
    {
        List<CNETPushDataStatus> UpdatePEALIngrationWithIDCOStatus(CNET objDATA);
        List<CNETPushDataStatus> SWPPushDataCNET(CNET objDATA);    
        List<CNETPushDataStatus> SWPPushQuery(CNETPushQueryEntity objDATA);

        List<DashboardDtl> DashboardCount(string strYr);
    }
}