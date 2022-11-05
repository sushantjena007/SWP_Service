using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AIMEntity
/// </summary> 

namespace EntityLayer.AIMEntity
{
    public class AIMEntity
    {
        public string strUniqueId { get; set; }
        public string strSecurityKey { get; set; }
        public string strEinPcNo { get; set; }
        public string strEinPcType { get; set; }
        //public string strEinPcDoc { get; set; }
    }

    public class AIMStatusResponse
    {
        public string strStatusMsg { get; set; }
        public int intStatus { get; set; }
    }
}