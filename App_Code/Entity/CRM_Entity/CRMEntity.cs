using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CRMEntity
/// </summary>
/// 
namespace EntityLayer.CRMEntity
{
    public class CRMEntity
    {
        public string strSSOId { get; set; }
        public string strSecurityKey { get; set; }
    }

    public class CRMPealStatusResponse
    {
        public string strStatusMsg { get; set; }
        public int intStatus { get; set; }
        public List<CRMPealDetails> CRMPealDetails { get; set; }
    }
    public class CRMPealDetails
    {
        public string strProposalNo { get; set; }
        public string strCompanyName { get; set; }
        public int intApplicationStatus { get; set; }
        public int intQueryStatus { get; set; }
        public string strAppliedDate { get; set; }
        public string strApprovalDate { get; set; }
    }

    public class CRMServiceStatusResponse
    {
        public string strStatusMsg { get; set; }
        public int intStatus { get; set; }
        public List<CRMServiceDetails> CRMServiceDetails { get; set; }
    }
    public class CRMServiceDetails
    {
        public string strApplicationNo { get; set; }
        public int intServiceId { get; set; }
        public int intApplicationStatus { get; set; }
        public int intQueryStatus { get; set; }
        public string strAppliedDate { get; set; }
        public string strApprovalDate { get; set; }
    }
}