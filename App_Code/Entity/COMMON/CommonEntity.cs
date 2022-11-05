using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for COMMONEntity
/// </summary>
namespace EntityLayer.COMMON
{
    public class COMMONEntity
    {
        public COMMONEntity()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int INT_APPLICATIONID { get; set; }
        public int INT_DEPARTMENTID { get; set; }
        public int INT_SERVICEID { get; set; }
        public string VCH_INVESTORNAME { get; set; }
        public string VCH_INVESTOREMAIL { get; set; }
        public string VCH_INVESTORPHONE { get; set; }
        public string VCH_INVESTORPAN { get; set; }
        public string VCH_INVESTORUSERID { get; set; }
        public int INT_PAYMENTSTATUS { get; set; }
        public string DEC_PAYMENTAMOUNT { get; set; }
        public int INT_DEMANDSTATUS { get; set; }
        public string DEC_DEMANDAMOUNT { get; set; }
        public string VCH_CHALLANNO { get; set; }
        public string VCH_BANKTRANID { get; set; }
        public string VCH_REMARK { get; set; }
        public int INT_APPLICATIONSTATUS { get; set; }
        public string VCH_CERTIFICATE { get; set; }
    }
    public class ApiReturnMessage
    {
        public int status { get; set; }
        public string Response { get; set; }       
    }
    public class ReturnMessage
    {
        public int INT_APPLICATIONID { get; set; }
        public string Response { get; set; }
    }
}