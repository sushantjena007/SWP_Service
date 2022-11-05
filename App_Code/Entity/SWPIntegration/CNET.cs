using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CNET
/// </summary>
/// 

namespace EntityLayer.CNETEntity
{
    public class CNET
    {
        public string ProposalNo { get; set; }
        public string CAFNo { get; set; }
        public string IndustryCode { get; set; }
        public string statuscode { get; set; }
        public string ProcessingFeeAmount { get; set; }
        public string ProcessingFeeStatus { get; set; }
        public string PaymentReferenceNo { get; set; }
        public string ProcessingFeeRealizationStatus { get; set; }
        public string DemandNoteLink { get; set; }
        public string DemandStatus { get; set; }
        public string DemandReceipt { get; set; }
        public string AllotmentOrderLink { get; set; }
        public string PaymentRealizationReferenceNo { get; set; }
        public string IDCOStatus { get; set; }
        public string successmessage { get; set; }
        public string IDCOLandAllotment { get; set; }
        public string IDCOAmount { get; set; }
    }
    public class CNETPushDataStatus
    {
        public string StatusMsg { get; set; }
        public int Status { get; set; }
    }

    /// <summary>
    /// Entity Class for Push Query Method
    /// </summary>
    public class CNETPushQueryEntity
    {
        public string strApplicationNumber { get; set; } //// Proposal No
        public int intNoOfTime { get; set; } //// No. Of Times Query Raised (1 or 2)
        public string strRemark { get; set; } //// Query Raised and Response Remark
        public string strKey { get; set; } //// Security key shared between IDCO and GOSWIFT for authentication purpose
        public string strStatusCode { get; set; } //// Mapping Application Status Code (5-Raised and 6-Response)
        public string strIdcoStatus { get; set; } //// Application status name(text) of IDCO
    }

    public class DashboardDtl
    {
        public string Received { get; set; }
        public string Approved { get; set; }
        public string TotCapital { get; set; }

        public string TotEmpProp { get; set; }
        public string Status { get; set; }
    }
}