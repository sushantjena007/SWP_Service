using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PartnershipFirm
/// </summary>

namespace EntityLayer.PartnershipFirmEntity
{
    public class PartnershipFirmUserProfile
    {
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string LASTNAME { get; set; }
        public string MobileNo { get; set; }
        public string IndustryName { get; set; }
     
        public string Email { get; set; }
       
        public string FirmAddress { get; set; }
    
    }
    public class PartnershipFirmPushData
    {
        public string Action { get; set; }
        public int ServiceID { get; set; }
        public string ApplicationNumber { get; set; }
        public string InvstorName { get; set; }
        public int ApplicationStatus { get; set; }
        public string UserID { get; set; }
        public string IndustryCode { get; set; }
        public int ActionTakenBy { get; set; }
        public int ActionToBeTakenBy { get; set; }
        public int PaymentStatus { get; set; }
        public string PaymentTransactionID { get; set; }
        public decimal PaymentAmount { get; set; }
        public string CertificateName { get; set; }
        public string ReferenceDocName { get; set; }
        public string Remark { get; set; }
        public string EscalationID { get; set; }
        public string ULBCode { get; set; }
        public int CreatedBy { get; set; }
    }
    public class AuthStatus
    {
        public string Action { get; set; }
        public string UserID { get; set; }
    }
    public class PartnershipFirmPushDataStatus
    {
        public string StatusMsg { get; set; }
        public int Status { get; set; }
    }
}