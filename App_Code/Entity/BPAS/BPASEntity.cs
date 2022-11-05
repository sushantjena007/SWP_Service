using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BPASEntity
/// </summary>
public class BPASPaymentStatus
{
    public string strAction { get; set; }
    public string strUniqueID { get; set; }
    public int intServiceid { get; set; }
    public int intpaymentstatus { get; set; }
    public string decpaymentamount { get; set; }
}
public class BPASApplicationStatus
{
    public string strAction { get; set; }
    public string strUniqueID { get; set; }
    public int intServiceid { get; set; }
    public int status { get; set; }
    public string decpaymentamount { get; set; }
}

public class BPASUserProfile
{
    public string StrIndustryName { get; set; }   
    public int intServiceid { get; set; }

}

public class BPASPushData
{
    public string strAction { get; set; }
    public int intServiceid { get; set; }
    public string strApplicationNumber { get; set; }
    public string strUniqueID { get; set; } 
    public int intApplicationStatus { get; set; }
    public string strProposalID { get; set; }
    public string strCertificateName { get; set; }
    public string strReferenceDocName { get; set; }
    public string strRemark { get; set; }   
    public string strUserName { get; set; }
}
public class BPASPushDataStatus
{
    public string strStatusMsg { get; set; }
    public int intStatus { get; set; }
}
public class BPASApplicationunique
{
    public string strUniqueID { get; set; }
}