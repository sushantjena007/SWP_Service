using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for APAAEntity
/// </summary>

namespace EntityLayer.APAA
{
    public class APAAEntity
    {
        public APAAEntity()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string VCH_INVESTOR_NAME {get;set;}
        public int INT_STATUS {get;set;}
        public int INT_PAYMENT_STATUS {get;set;}
        public string VCH_PAYMENT_ACKNOWLEDGEMENT_NO {get;set;}
        public string VCH_CHALLAN_NO {get;set;}
        public decimal NUM_PAYMENT_AMOUNT {get;set;}
        public string VCH_CERTIFICATE_FILENAME {get;set;}
        public string VCH_REMARK {get;set;}
        public int intApprovalLevel {get;set;}
        public int intQueryStatus {get;set;}
        public int INTDISTRICTID {get;set;}
        public string DTM_RAISE_QUERY {get;set;}
        public string DTM_REVERT_QUERY {get;set;}
        public int INT_CONFIG_QUERY_TIMES {get;set;}
        public int INT_CURRENT_QUERY_TIMES {get;set;}
        public decimal num_Demand_Amount {get;set;}
        public string VCH_PANNO {get;set;}
        public string VCH_APPLICATION_NO { get; set; }
        public string VCH_APPLICATION_UNQ_KEY { get; set; }
        public int INT_SERVICEID { get; set; }
        public string VCH_PROPOSALID { get; set; }
    }
    public class clsOutput
    {       
        public string Status { get; set; }
        
        public string OutMessage { get; set; }
    }
   
    public class retMessage
    {       
        public List<clsOutput> objOutParam { get; set; }
    }
}