using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer.APAA;
using DataAcessLayer.APAA;

/// <summary>
/// Summary description for APAABL
/// </summary>
/// 
namespace BusinessLogicLayer.APAA
{
    public class APAABL:IAPAABL
    {
        APAADAL objApaaDal = new APAADAL();
        public List<retMessage> ApplyWaterAllotment(APAAEntity objApaa)
        {
            return objApaaDal.ApplyWaterAllotment(objApaa);
        }

        public List<retMessage> QueryRaised(APAAEntity objApaa)
        {
            return objApaaDal.QueryRaised(objApaa);
        }

        public List<retMessage> QueryResponse(APAAEntity objApaa)
        {
            return objApaaDal.QueryResponse(objApaa);
        }

        public List<retMessage> UpdateStatus(APAAEntity objApaa)
        {
            return objApaaDal.UpdateStatus(objApaa);
        }

        public List<retMessage> IssueCertificate(APAAEntity objApaa)
        {
            return objApaaDal.IssueCertificate(objApaa);
        }
    }
}