using System;
using System.Collections.Generic;
using EntityLayer.NSWSEntity;
using System.Configuration;
using SWP_Services.DAL.Data;
using DWHServiceReference;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;
using RestSharp;
using Newtonsoft.Json;

/// <summary>
/// Summary description for NSWSDAL
/// </summary>
/// 

namespace DataAcessLayer.NSWSDAL
{
    public class NSWSDAL : INSWSDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString();
        object param1 = new object();
        object param2 = new object();
        object param3 = new object();
        string strNswsSecurityKey = ConfigurationManager.AppSettings["NSWSSecurityKey"].ToString();

        /// <summary>
        /// Created By:- Sushant Jena
        /// Creation Date:- 17-Mar-2021
        /// This methos is used to register a NSWS user in GOSWIFT portal.
        /// </summary>
        /// <param name="objNsws"></param>
        /// <returns></returns>
        public List<clsOutput1> NSWSUserRegistration(NSWSEntity objNsws)
        {
            clsOutput1 objResponse = new clsOutput1();
            List<clsOutput1> lstResponse = new List<clsOutput1>();

            try
            {
                /*--==============================================================================================================--*/
                /// PROCESS FLOW DESCRIPTION:
                /*--==============================================================================================================--*/
                /// 1. Validate the input details and ensure that all mandatory fields are provided by user.
                /// 2. After successfully validating the input fields,Download the EIN/IEM document from NSWS portal using "Pull Document" API method.
                /// 3. After successfully downloading the document, rename it using the GOSWIFT naming format and include the text 'NSWS' in the file name to make it easier to recognise.
                /// 4. Register the user in GOSWIFT db and generate the PAN based user id as per the GOSWIFT user id format.
                /// 5. After successfully inserting data into GOSWIFT portal,then push the record to SSO (DWH) server.
                /// 6. After successfully pushing data to DWH,Generate dynamic url using PAN and SWS Id.
                /// 7. Then update the redirection URL and the UNIQUE ID returned by DWH, in GOSWIFT db. 
                /// 8. Send the redirection URL to NSWS portal using "Redirection" API method.
                /// 9. After sending redirection URL to NSWS portal, Return the "Success" status along with redirection URL sent status to the NSWS portal.                
                /*--==============================================================================================================--*/


                /*--------------------------------------------------------------------*/
                ///Write request log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser1 = new JavaScriptSerializer();
                var json1 = jsonSerialiser1.Serialize(objNsws);
                string strInput = "(REQUEST_FROM_NSWS)--[REQUEST_JSON_STRING]:- " + json1;
                Util.LogRequestResponse("NSWS", "NSWSUserRegistration", strInput);

                /*--------------------------------------------------------------------*/
                ///Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Input Validation

                if (objNsws.SecurityKey.Trim() != strNswsSecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (objNsws.PAN.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "PAN number should not be blank.";
                    intValid = 1;
                }
                else if (objNsws.ApplicantName.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Applicant name should not be blank.";
                    intValid = 1;
                }
                else if (objNsws.ApplicantAddress.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Applicant address should not be blank.";
                    intValid = 1;
                }
                else if (objNsws.MobileNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Mobile number should not be blank.";
                    intValid = 1;
                }
                else if (objNsws.EmailId.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Email id should not be blank.";
                    intValid = 1;
                }
                else if (objNsws.UnitName.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Unit name should not be blank.";
                    intValid = 1;
                }
                else if (objNsws.InvestmentLevel != 1 && objNsws.InvestmentLevel != 2)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid investment level.";
                    intValid = 1;
                }
                else if (objNsws.DistrictCode == 0)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "District code should not be zero(0).";
                    intValid = 1;
                }
                else if (objNsws.BlockCode == 0)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Block code should not be zero(0).";
                    intValid = 1;
                }
                else if (objNsws.SectorCode == 0)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Sector code should not be zero(0).";
                    intValid = 1;
                }
                else if (objNsws.SubSectorCode == 0)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Sub sector code should not be zero(0).";
                    intValid = 1;
                }
                else if (objNsws.EinIemType.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "EIN/IEM type should not be blank.";
                    intValid = 1;
                }
                else if (objNsws.EinIemNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "EIN/IEM number should not be blank.";
                    intValid = 1;
                }
                else if (objNsws.EinIemDoc.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "EIN/IEM document link should not be blank.";
                    intValid = 1;
                }
                else if (objNsws.InvestorSWSId.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Investor SWS id should not be blank.";
                    intValid = 1;
                }

                /*--------------------------------------------------------------------------------------------------*/
                ///Regular expression validation for PAN format
                /*--------------------------------------------------------------------------------------------------*/
                Regex regPAN = new Regex(@"^[A-Z]{5}\d{4}[A-Z]{1}");
                if (!regPAN.IsMatch(objNsws.PAN.Trim()))
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid PAN Number.";
                    intValid = 1;
                }

                /*--------------------------------------------------------------------------------------------------*/
                ///If above validation get success,then check for document validation.
                /*--------------------------------------------------------------------------------------------------*/
                string strFileName = "";
                if (intValid == 0)
                {
                    /*--------------------------------------------------------------------------------------------------*/
                    ///Download the EIN/IEM document from NSWS and Save to GOSWIFT application.
                    /*--------------------------------------------------------------------------------------------------*/
                    string strReturnVal = DownloadDocument(objNsws.EinIemDoc.Trim());
                    string[] strRetStatus = new string[2];
                    strRetStatus = strReturnVal.Split('~');

                    if (strRetStatus[0] == "1")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "No file found for download.";
                        intValid = 1;
                    }
                    else if (strRetStatus[0] == "2")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "File not found (404 error on file download).";
                        intValid = 1;
                    }
                    else if (strRetStatus[0] == "3")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "Invalid or corrupted file found.";
                        intValid = 1;
                    }
                    else if (strRetStatus[0] == "4")
                    {
                        strFileName = strRetStatus[1].ToString();
                        intValid = 0;
                    }
                    else if (strRetStatus[0] == "5")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "No file found in remote server.";
                        intValid = 1;
                    }
                }

                #endregion

                /*--=======================================================================================================================--*/

                if (intValid == 0)
                {
                    /*--------------------------------------------------------------------*/
                    ///User Registration Process in GOSWIFT.
                    /*--------------------------------------------------------------------*/
                    object[] objArray = new object[] { 
                                                       "@P_VCH_ACTION", "A", 
                                                       "@P_VCH_PAN",objNsws.PAN,
                                                       "@P_VCH_APP_NAME",objNsws.ApplicantName,
                                                       "@P_VCH_APP_ADDRESS",objNsws.ApplicantAddress,
                                                       "@P_VCH_MOBILE_NO",objNsws.MobileNo,
                                                       "@P_VCH_EMAIL_ID",objNsws.EmailId,
                                                       "@P_VCH_UNIT_NAME",objNsws.UnitName,
                                                       "@P_INT_INDUSTRY_CATEGORY",objNsws.InvestmentLevel,
                                                       "@P_VCH_SITE_LOCATION",objNsws.SiteLocation,
                                                       "@P_VCH_LICENCE_NO_TYPE",objNsws.EinIemType,
                                                       "@P_VCH_LICENCE_NO",objNsws.EinIemNo,
                                                       "@P_VCH_LICENCE_DOC",strFileName,
                                                       "@P_INT_DISTRICT_CODE",objNsws.DistrictCode,
                                                       "@P_INT_BLOCK_CODE",objNsws.BlockCode,
                                                       "@P_INT_SECTOR_CODE",objNsws.SectorCode,
                                                       "@P_INT_SUB_SECTOR_CODE",objNsws.SubSectorCode,
                                                       "@P_VCH_GSTIN",objNsws.GSTIN,
                                                       "@P_VCH_INV_SWS_ID_NSWS",objNsws.InvestorSWSId
                                                    };

                    string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_NSWS_USER_REGISTRATION", out param1, objArray).ToString();

                    string[] strValueArr = param1.ToString().Split('~');
                    if (strValueArr[0] == "2") //// Data Pushed to the GOSWIFT Successfully.
                    {
                        string strUserId = Convert.ToString(strValueArr[1]);
                        string strParentId = Convert.ToString(strValueArr[2]);
                        string strParentUnqId = Convert.ToString(strValueArr[3]);

                        /*--------------------------------------------------------------------*/
                        ///Push Records to DWH
                        /*--------------------------------------------------------------------*/
                        /// Service Initialization
                        DWHServiceHostClient objSrvRef = new DWHServiceHostClient();
                        DWH_Model objEnt = new DWH_Model();

                        /*--------------------------------------------------------------------*/
                        ///Assign value to property                        
                        /*--------------------------------------------------------------------*/
                        objEnt.VCHINDUSTRYNAME = objNsws.UnitName;
                        objEnt.VCHEMAILID = objNsws.EmailId;
                        objEnt.VCHMOBILENO = objNsws.MobileNo;
                        objEnt.INTSALUTATION = 0;
                        objEnt.VCHPROMOTERFNAME = objNsws.ApplicantName;
                        objEnt.VCHPROMOTERMNAME = "";
                        objEnt.VCHPROMOTERLNAME = "";
                        objEnt.VCHADDRESS = objNsws.ApplicantAddress;
                        objEnt.VCHUSERNAME = strUserId; //// User Id Generated from GOSWIFT                       
                        objEnt.INTDISTRICT = objNsws.DistrictCode;
                        objEnt.INTBLOCK = objNsws.BlockCode;
                        objEnt.INTSECTOR = objNsws.SectorCode;
                        objEnt.INTSUBSECTOR = objNsws.SubSectorCode;
                        objEnt.INTPARENTID = Convert.ToInt32(strParentId);
                        objEnt.VCHPANNO = objNsws.PAN;
                        objEnt.VCHEINIEM = objNsws.EinIemNo;
                        objEnt.VCHLICENCENOTYPE = objNsws.EinIemType;
                        objEnt.VCHLICENCEDOC = strFileName;
                        objEnt.INTUSERLEVEL = 1;
                        objEnt.VCHUSERUNIQUEID = strParentUnqId;
                        objEnt.VCHCORADDRESS = objNsws.SiteLocation;
                        objEnt.VCHTINNO = objNsws.GSTIN;
                        objEnt.INTINDUSTRYCATEGORY = objNsws.InvestmentLevel;
                        objEnt.INTAPPROVALLEVEL = 2; //// Second Level or Final Approval                         
                        objEnt.VCHINVNSWSID = objNsws.InvestorSWSId; //// Investor SWS Id Received from NSWS

                        /*--------------------------------------------------------------------*/
                        ///Generate Encryption Key (Security key to access Data Warehouse servce methods)
                        /*--------------------------------------------------------------------*/
                        string strEncryptionKey = ConfigurationManager.AppSettings["DWHEncryptionKey"];
                        string strSecurityKey = objSrvRef.KeyEncryption(strEncryptionKey);

                        /*--------------------------------------------------------------------*/
                        ///DML opertion through service (DWH)
                        /*--------------------------------------------------------------------*/
                        string strReturnVal = objSrvRef.UserRegistration(objEnt, strSecurityKey);
                        if (strReturnVal != "")
                        {
                            string[] strArrRetVal = strReturnVal.Split('_');

                            if (strArrRetVal[0] == "1")
                            {
                                objResponse.Status = 1;
                                objResponse.OutMessage = "User name already exists.";
                            }
                            else if (strArrRetVal[0] == "4") //// Successfully data pushed to DWH
                            {
                                /*--------------------------------------------------------------------*/
                                ///After successfully pushing data to DWH,Generate dynamic url using PAN and SWS Id.
                                ///Then update the redirection URL and the UNIQUE ID returned by DWH, in GOSWIFT db. 
                                ///After updating the Unique SSO Id and Redirection URL in GOSWIFT portal, Send the "Success" status to NSWS portal along with Unique/SSO Id.
                                /*--------------------------------------------------------------------*/

                                string strUniqueIdDWH = strArrRetVal[1]; ///// Unique Id or SSO Id Received from DWH

                                /*--------------------------------------------------------------------*/
                                ///Generate Dynamic Url Here
                                /*--------------------------------------------------------------------*/
                                string strGoswiftLandingPage = ConfigurationManager.AppSettings["NSWSLandingPage"].ToString();
                                string strValToEncrypt = objNsws.PAN + "|" + objNsws.InvestorSWSId;

                                EncryptDecryptQueryString objEncDec = new EncryptDecryptQueryString();
                                string strEncVal = objEncDec.Encrypt(strValToEncrypt, "gR35GrvT");
                                string strGoswiftRedirectUrl = strGoswiftLandingPage + "?nparam=" + strEncVal;

                                /*--------------------------------------------------------------------*/
                                ///Update Unique Id and Dynamic Redirection URL in GOSWIFT DB.
                                /*--------------------------------------------------------------------*/
                                object[] objArray1 = new object[] { 
                                                                    "@P_VCH_ACTION", "UID", 
                                                                    "@P_VCH_UNIQUE_ID",strUniqueIdDWH,                                                                 
                                                                    "@P_VCH_INV_USER_ID",strUserId,
                                                                    "@P_VCH_REDIRECT_URL_NSWS",strGoswiftRedirectUrl                                       
                                                                   };
                                string RetValue1 = SqlHelper.ExecuteNonQuery(connectionString, "USP_NSWS_USER_REGISTRATION", out param2, objArray1).ToString();
                                if (param2.ToString() == "1")//// Successfully updated Unique (SSO) Id at GOSWIFT
                                {
                                    objResponse.Status = 2;
                                    objResponse.OutMessage = "Success";
                                    objResponse.SSOId = strUniqueIdDWH;

                                    /*--------------------------------------------------------------------*/
                                    ///Send the redirection URL to NSWS portal.
                                    ///Generate token and call the Redirection API for sending of dynamic url.
                                    /*--------------------------------------------------------------------*/
                                    ///Get the API Address from the Web.Config
                                    string strTokenUrl = ConfigurationManager.AppSettings["NswsTokenGenerationUrl"].ToString();
                                    string strRedirectApiUrl = ConfigurationManager.AppSettings["NswsRedirectionApiUrl"].ToString();

                                    /*--------------------------------------------------------------------*/
                                    ///Generate Access Token
                                    /*--------------------------------------------------------------------*/
                                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                                    var client1 = new RestClient(strTokenUrl);
                                    client1.Timeout = -1;
                                    var request1 = new RestRequest(Method.POST);
                                    //string strAuthKey = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("sws_state:643790eb-2b2a-4187-8c43-54a663b840eb"));
                                    //request1.AddHeader("Authorization", strAuthKey);
                                    request1.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                                    request1.AddParameter("grant_type", "password");
                                    request1.AddParameter("username", "odisha");
                                    request1.AddParameter("password", "Odisha@nsws");
                                    request1.AddParameter("client_secret", "643790eb-2b2a-4187-8c43-54a663b840eb");
                                    request1.AddParameter("client_id", "sws_state");
                                    IRestResponse responseToken = client1.Execute(request1);

                                    if (responseToken.Content.ToString() != "")
                                    {
                                        /*--------------------------------------------------------------------*/
                                        ///Get the Access Token
                                        /*--------------------------------------------------------------------*/
                                        string strAccessToke = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseToken.Content)["access_token"].ToString();

                                        /*--------------------------------------------------------------------*/
                                        ///Call Redirection API Here
                                        /*--------------------------------------------------------------------*/
                                        string strRedirectionJson = "{\"licenseId\": \"\",\"stateId\": \"12\",\"departmentId\": \"\",\"redirectionUrl\": \"" + strGoswiftRedirectUrl + "\",\"swsId\": \"" + objNsws.InvestorSWSId + "\"}";

                                        /*--------------------------------------------------------------------*/
                                        ///Write the Request JSON string in the Log file.
                                        /*--------------------------------------------------------------------*/
                                        Util.LogRequestResponse("NSWS", "SEND_NSWS_REDIRECT_URL", "(REQUEST_FROM_GOSWIFT)--[REQUEST_JSON_STRING] :- " + strRedirectionJson);

                                        var client2 = new RestClient(strRedirectApiUrl);
                                        client2.Timeout = -1;
                                        var request2 = new RestRequest(Method.POST);
                                        request2.AddHeader("Authorization", "Bearer " + strAccessToke);
                                        request2.AddHeader("Content-Type", "application/json");
                                        request2.AddParameter("application/json", strRedirectionJson, ParameterType.RequestBody);
                                        IRestResponse responseRedirectApi = client2.Execute(request2);

                                        /*--------------------------------------------------------------------*/
                                        ///Write the Redirection URL API Response in the Log File.
                                        /*--------------------------------------------------------------------*/
                                        Util.LogRequestResponse("NSWS", "SEND_NSWS_REDIRECT_URL", "(RESPONSE_FROM_NSWS)--[RESPONSE_JSON_STRING]:- " + responseRedirectApi.Content.ToString());

                                        if (responseRedirectApi.Content.ToString() != "")
                                        {
                                            string strStatus = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseRedirectApi.Content)["status"].ToString();
                                            if (strStatus.ToUpper() == "TRUE")
                                            {
                                                object[] objArray2 = new object[] { 
                                                                                    "@P_VCH_ACTION", "C",                                                                                                                                    
                                                                                    "@P_VCH_INV_USER_ID",strUserId                                                                                                       
                                                                                  };
                                                string RetValue2 = SqlHelper.ExecuteNonQuery(connectionString, "USP_NSWS_USER_REGISTRATION", out param3, objArray2).ToString();
                                                if (param3.ToString() == "1") /////Redirection URL sent status updated successfully.
                                                {
                                                    objResponse.OutMessage = "Data Saved Successfully and Redirection URL Sent Successfully !";
                                                    objResponse.Status = 2;
                                                }
                                            }
                                            else
                                            {
                                                objResponse.OutMessage = "Data Saved Successfully and Rediection URL not Landed at NSWS !";
                                                objResponse.Status = 2;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Util.LogRequestResponse("NSWS", "TOKEN_GENERATION", "[BLANK_TOKEN_RESPONSE_FROM_NSWS]:- " + responseToken.Content.ToString());
                                    }
                                }
                                else if (param2.ToString() == "2")
                                {
                                    objResponse.Status = 0;
                                    objResponse.OutMessage = "Oops,Some Error Occured.Please Contact Administrator.";
                                    Util.LogRequestResponse("NSWS", "UNIQUE_ID_UPDATE_IN_GOSWIFT", "[FAILURE_TO_UPDATE_UNIQUE_ID_IN_GOSWIFT_PORTAL]");
                                }
                            }
                            else
                            {
                                Util.LogRequestResponse("NSWS", "RESPONSE_FROM_DWH", "[UNABLE_TO_PUSH_DATA_IN_DWH]:- " + strReturnVal);
                            }
                        }
                        else
                        {
                            Util.LogRequestResponse("NSWS", "RESPONSE_FROM_DWH", "[BLANK_RESPONSE_FROM_DWH]:- " + strReturnVal);
                        }
                    }
                    else if (strValueArr[0].ToString() == "1")
                    {
                        objResponse.Status = 4;
                        objResponse.OutMessage = "The Investor SWS Id is already exists.";
                    }
                    else if (strValueArr[0].ToString() == "4")
                    {
                        objResponse.Status = 5;
                        objResponse.OutMessage = "The EIN/IEM number is already exists.";
                    }
                    else
                    {
                        objResponse.Status = 0;
                        objResponse.OutMessage = "Some Error Occured.Please Contact Administrator.";
                    }
                }

                /*--------------------------------------------------------------------*/
                ///Write response log for each request.
                /*--------------------------------------------------------------------*/
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json2 = jsonSerialiser.Serialize(objResponse);
                string strOutput = "(RESPONSE_FROM_GOSWIFT)--[INPUT_VALIDITY_STATUS]:- " + intValid.ToString() + " <----> [RESPONSE_JSON_STRING]:- " + json2;
                Util.LogRequestResponse("NSWS", "NSWSUserRegistration", strOutput);
                /*--------------------------------------------------------------------*/
            }
            catch (Exception ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = "Some Error Occured,Please try again.";
                Util.LogError(ex, "NSWS");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        /// <summary>
        /// Common class for download the document from NSWS portal.
        /// </summary>
        /// <param name="strNswsFileName"></param>
        /// <returns></returns>
        private string DownloadDocument(string strNswsFileName)
        {
            string strReturnVal = "";
            try
            {
                string strFileContentId = JsonConvert.DeserializeObject<Dictionary<string, object>>(strNswsFileName.Replace("[", "").Replace("]", ""))["value"].ToString();

                /*---------------------------------------------------------------------------------------*/
                ///Get the API address,access-id,access-secret and api key from web configuration file.
                /*---------------------------------------------------------------------------------------*/
                string strPullDocApiUrl = ConfigurationManager.AppSettings["NswsPullDocApiUrl"].ToString();
                string strAccessId = ConfigurationManager.AppSettings["NswsApiAccessId"].ToString();
                string strAccessSecret = ConfigurationManager.AppSettings["NswsApiAccessSecret"].ToString();
                string strApiKeyPullDoc = ConfigurationManager.AppSettings["NswsApiKeyPullDoc"].ToString();

                /*---------------------------------------------------------------------------------------*/

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                string strJson = "{\"contentId\":[\"" + strFileContentId + "\"]}";
                var client = new RestClient(strPullDocApiUrl);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("access-id", strAccessId);
                request.AddHeader("access-secret", strAccessSecret);
                request.AddHeader("api-key", strApiKeyPullDoc);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", strJson, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                string strFileResposnse = response.Content.Length > 200 ? response.Content.ToString().Substring(0, 200) : response.Content.ToString();
                Util.LogRequestResponse("NSWS", "DownloadDocument", "(REQUEST_FROM_GOSWIFT)--[REQUEST_JSON_STRING]:- " + strJson + " <----> " + "(RESPONSE_FROM_NSWS)--[RESPONSE_JSON_STRING]:- " + strFileResposnse);

                if (response.Content.ToString() != "")
                {
                    PullApiDoc objApp = JsonConvert.DeserializeObject<PullApiDoc>(response.Content);
                    string strStatus = objApp.status;
                    if (strStatus == "200")
                    {
                        List<DocResponseFile> objDocRes = new List<DocResponseFile>();
                        objDocRes = objApp.response.ToList();

                        string strFileName = objDocRes[0].fileName;
                        string strFileResponse = objDocRes[0].fileResponse; ///Byte stream of the file to be downloaded.

                        byte[] data = Convert.FromBase64String(strFileResponse);
                        if (data.Length > 0)
                        {
                            if (IsFileValid(data))
                            {
                                /*--------------------------------------------------------------------*/
                                ///Rename the file as per the GOSWIFT naming format.
                                /*--------------------------------------------------------------------*/
                                strFileName = string.Format("{0:yyyyMMddhhmmss}", DateTime.Now) + "_LICNDOC_NSWS.pdf";
                                string strPath = ConfigurationManager.AppSettings["FileUploadPathRegdDoc"]; ///Physical path for GOSWIFT document folder.

                                /*--------------------------------------------------------------------*/
                                ///Save the file to destination folder. (In GOSWIFT Application)
                                /*--------------------------------------------------------------------*/
                                FileStream fileStream = null;
                                if (!string.IsNullOrEmpty(strPath))
                                {
                                    fileStream = new FileStream(strPath + strFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    using (System.IO.FileStream fs = fileStream)
                                    {
                                        fs.Write(data, 0, data.Length);
                                        strReturnVal = "4" + "~" + strFileName;
                                    }
                                }
                            }
                            else
                            {
                                strReturnVal = "3"; ///Invalid or corrupted file found.
                            }
                        }
                        else
                        {
                            strReturnVal = "1"; ///No file found for download.
                        }
                    }
                    else
                    {
                        strReturnVal = "2"; ///Not found (404 Error).
                    }
                }
                else
                {
                    strReturnVal = "1"; ///No response found for file.
                }
            }
            catch (WebException ex)
            {
                strReturnVal = "5"; ///"No file found in remote server.";
                Util.LogError(ex, "NSWS");
            }

            return strReturnVal;
        }

        /// <summary>
        /// Check Mime Type for PDF File.
        /// </summary>
        private static readonly byte[] PDF = { 37, 80, 68, 70, 45, 49, 46 };
        private bool IsFileValid(byte[] filebyte)
        {
            if (filebyte.Take(7).SequenceEqual(PDF))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public class PullApiDoc
        {
            public string status { get; set; }
            public string message { get; set; }
            public List<DocResponseFile> response { get; set; }
        }
        public class DocResponseFile
        {
            public string fileName { get; set; }
            public string fileResponse { get; set; }
        }
    }
}



