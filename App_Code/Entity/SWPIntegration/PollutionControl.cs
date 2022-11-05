#region
//******************************************************************************************************************
// File Name             :   SWPIntegration/PollutionControl.cs
// Description           :   Declaration of various properties used in Pollution Control integration
// Created by            :   Pranay Kumar
// Created on            :   08-Sept-2017
// Modified by           :  
// Created on            :   
// Modification History  :
//       <CR no.>                      <Date>             <Modified by>                <Modification Summary>'                                                          
//         
//********************************************************************************************************************
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PollutionControl
/// </summary>
public class PollutionAuthStatus
{
    public string strAction { get; set; }
    public string strUserID { get; set; }
    public string strUniqueKey { get; set; }
    public string StrProposalID { get; set; }
}

public class PollutionControlUserProfile
{
    public string StrFirstName { get; set; }
    public string StrMiddleName { get; set; }
    public string StrLastName { get; set; }
    public string StrMobNo { get; set; }
    public string StrUnitName { get; set; }
    public string StrCorrespondsAddresss { get; set; }
    public string StrPermanentAddress { get; set; }
    public string StrStateName { get; set; }
    public string StrDistrictName { get; set; }
    public string StrEmail { get; set; }
    public string StrPinCode { get; set; }
    public string StrFirmAddress { get; set; }
    public string vchPhoneNo { get; set; }
    public decimal decTotCapitalInvestment { get; set; }
    public decimal decPlantndMachinery { get; set; }
    public decimal decLandIncLandDev { get; set; }
    public decimal decBuildingndConstruction { get; set; }
    public decimal decOthers { get; set; }

    public string vchPollutionCategory { get; set; }
    public string StrDistrictName1 { get; set; }
}

public class PollutionPushData
{
    public string strAction { get; set; }
    public int intServiceID { get; set; }
    public string strApplicationNumber { get; set; }
    public string strInvstorName { get; set; }
    public int intApplicationStatus { get; set; }
    public string strUserID { get; set; }
    public string strIndustryCode { get; set; }
    public int intActionTakenBy { get; set; }
    public int intActionToBeTakenBy { get; set; }
    public int intPaymentStatus { get; set; }
    public string strPaymentTransactionID { get; set; }
    public decimal decPaymentAmount { get; set; }
    public string strCertificateName { get; set; }
    public string strReferenceDocName { get; set; }
    public string strRemark { get; set; }
    public string strEscalationID { get; set; }
    public string strULBCode { get; set; }
    public int intCreatedBy { get; set; }
}
public class PollutionPushDataStatus
{
    public string strStatusMsg { get; set; }
    public int intStatus { get; set; }
}