using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DrugLicense
/// </summary>
/// 
public class AuthStatus
{
    public string Action { get; set; }
    public string UserID { get; set; }
    public string Key { get; set; }
}

public class DrugLicenseUserProfile
{
    public string FIRSTNAME { get; set; }
    public string MIDDLENAME { get; set; }
    public string LASTNAME { get; set; }
    public string MobileNo { get; set; }
    public string UnitName { get; set; }
    public string CorrespondsAddresss { get; set; }
    public string PermanentAddress { get; set; }
    public string StateName { get; set; }
    public string DistrictName { get; set; }
    public string Email { get; set; }
    public string PinCode { get; set; }
    public string FirmAddress { get; set; }
    public string RegisteredType { get; set; }
}

public class RetailPushData
{
      public string Action { get; set; }
      public int ServiceID {get;set;}
      public string ApplicationNumber{get;set;}
      public string InvstorName{get;set;}
      public int ApplicationStatus{get;set;}
      public string UserID{get;set;} 
      public string ProposalID{get;set;}
      public int ActionTakenBy { get; set; }
      public int ActionToBeTakenBy { get; set; } 
      public int PaymentStatus{get;set;} 
      public string PaymentTransactionID{get;set;}
      public decimal PaymentAmount { get; set; }
      public string CertificateName { get; set; }
      public string ReferenceDocName { get; set; }
      public string Remark { get; set; }
      public string EscalationID { get; set; }
      public string ULBCode { get; set; }
      public int CreatedBy { get; set; }
}
public class RetailPushDataStatus
{
    public string StatusMsg { get; set; }
    public int Status { get; set; }
}