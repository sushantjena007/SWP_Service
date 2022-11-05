using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonEntity
/// </summary>
/// 
namespace EntityLayer.COMMON_Entity
{
    public class CommonEntity
    {
        public CommonEntity()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string ApplicationNo { get; set; }
        public decimal PaymentAmount { get; set; }
        public string HeadOfAccount { get; set; }
        public string investorId { get; set; }
        
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