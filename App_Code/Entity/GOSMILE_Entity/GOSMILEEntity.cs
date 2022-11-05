using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GOSMILEEntity
/// </summary>

namespace EntityLayer.GOSMILE_Entity
{
    public class GOSMILEStatusResponse
    {
        public GOSMILEStatusResponse()
        {

        }             
        public string ApplicationNo { get; set; }
        public string PaymentDate { get; set; }
        public string ChallanAmount { get; set; }
        public string BankTransId { get; set; }
        public string ChallanRefId { get; set; }
        public int Status { get; set; }
        public string OutMessage { get; set; }
    }
    public class GOSMILEEntity
    {
        public string ApplicationNo { get; set; }
        public string SecurityKey { get; set; }
        public int Status { get; set; }
        public string ApprovalDoc { get; set; }
        public string ReferenceDoc { get; set; }
        public string Remarks { get; set; }
        public int ServiceId { get; set; }
    }
    public class clsOutput
    {
        public int Status { get; set; }
        public string OutMessage { get; set; }
    }
}