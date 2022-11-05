using EntityLayer.GOSMILE_Entity;
using SWP_Services.DAL.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Hosting;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for GOSMILEDAL
/// </summary>
/// 
namespace DataAcessLayer.GOSMILEDAL
{
    public class GOSMILEDAL : IGOSMILEDAL
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;
        string strGOSMILESecurityKey = ConfigurationManager.AppSettings["GOSMILESecurityKey"].ToString();
        object param = new object();

        /// <summary>
        /// Method to Fetch Payment Details for bolier inspection
        /// Added by manoj kumar behera on Dt:04-Jan-2021.
        /// This method is only useful for Bolier Inspection payment details
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<GOSMILEStatusResponse> FetchPaymentDetails(GOSMILEEntity ObjParam)
        {
            SqlDataReader reader;
            List<GOSMILEStatusResponse> list = new List<GOSMILEStatusResponse>();
            GOSMILEStatusResponse objResponse = new GOSMILEStatusResponse();
            int intValid = 0;

            try
            {
                ///// Write request log for each request.
                ///
                string strInput = "(Request)---Application No :- " + ObjParam.ApplicationNo.Trim() + " Security Key:- " + ObjParam.SecurityKey.Trim();
                Util.LogRequestResponse("GoSmileService", "FetchPaymentDetails", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/

                #region Validation

                objResponse.ApplicationNo = "";
                objResponse.BankTransId = "";
                objResponse.ChallanAmount = "0";
                objResponse.ChallanRefId = "";
                objResponse.PaymentDate = "";

                if (ObjParam.SecurityKey.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Security key should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.SecurityKey.Trim() != strGOSMILESecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (ObjParam.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service Id should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }

                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] arr = new object[] {  "P_VCH_ACTION","D",
                                                   "P_INT_SERVICEID",ObjParam.ServiceId,
                                                   "P_VCH_APPLICATION_NO",ObjParam.ApplicationNo
                                                };
                    reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_FETCH_PAYMENT_DETAILS", out param, arr);
                    list = reader.DataReaderMapToList<GOSMILEStatusResponse>(MappingDirection.Auto);

                    /*-----------------------------------------------------------*/
                    ///// Write response log for each request.               
                    JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                    var json = jsonSerialiser.Serialize(list);
                    string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
                    Util.LogRequestResponse("GoSmileService", "FetchPaymentDetails", strOutput);

                    /*-----------------------------------------------------------*/
                }
                else
                {
                    /*-----------------------------------------------------------*/

                    ///// Write response log for each request.
                    JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                    var json = jsonSerialiser.Serialize(objResponse);
                    string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
                    Util.LogRequestResponse("GoSmileService", "FetchPaymentDetails", strOutput);

                    /*-----------------------------------------------------------*/
                    list.Add(objResponse);
                }
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                objResponse.ApplicationNo = "";
                objResponse.BankTransId = "";
                objResponse.ChallanAmount = "0";
                objResponse.ChallanRefId = "";
                objResponse.PaymentDate = "";
                intValid = 1;
            }

            //return list;

            if (intValid == 0)
            {
                /*-----------------------------------------------------------*/
                ///// Write response log for each request.               
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(list);
                string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
                Util.LogRequestResponse("GoSmileService", "FetchPaymentDetails", strOutput);

                /*-----------------------------------------------------------*/

                return list;
            }
            else
            {
                /*-----------------------------------------------------------*/

                ///// Write response log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objResponse);
                string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
                Util.LogRequestResponse("GoSmileService", "FetchPaymentDetails", strOutput);

                /*-----------------------------------------------------------*/

                list.Add(objResponse);
                return list;
            }           
        }

        public List<clsOutput> ApplicationStatusUpdate(GOSMILEEntity ObjParam)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();
            string strTempFolderPath = System.Configuration.ConfigurationManager.AppSettings.Get("FileUploadPath");
            string Approvefilename = "";
            string ApproveFileFullPath = "";
            string ReferenceFilename = "";
            string ReferneceFileFullPath = "";
            bool isSuccess = false;
            FileStream fileStream = null;

            try
            {
                ///// Write request log for each request.
                ///
                string strInput = "(Request)---Application No :- " + ObjParam.ApplicationNo.Trim() + " Security Key:- " + ObjParam.SecurityKey.Trim() + " Approvrd Link:- " + ObjParam.ApprovalDoc + " Reference Link:- " + ObjParam.ReferenceDoc;
                Util.LogRequestResponse("GoSmileService", "ApplicationStatusUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (ObjParam.SecurityKey.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Security key should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.SecurityKey.Trim() != strGOSMILESecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (ObjParam.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.Status.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Status should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.Remarks.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Remarks should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.ReferenceDoc.Trim() != "")
                {
                    byte[] data;
                    using (WebClient client = new WebClient())
                    {
                        string strAddress = ObjParam.ReferenceDoc;
                        data = client.DownloadData(strAddress);
                    }

                    if (data.Length > 0)
                    {
                        if (IsFileValid(data))
                        {
                            if (!string.IsNullOrEmpty(strTempFolderPath))
                            {
                                Uri uri = new Uri(ObjParam.ReferenceDoc);
                                string filename = System.IO.Path.GetFileName(uri.AbsolutePath);
                                ReferenceFilename = string.Format("{0:yyyy_MM_dd}" + "_" + ObjParam.ApplicationNo + filename, DateTime.Now);
                                ReferneceFileFullPath = strTempFolderPath + ReferenceFilename;
                                fileStream = new FileStream(ReferneceFileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                using (System.IO.FileStream fs = fileStream)
                                {
                                    fs.Write(data, 0, data.Length);
                                    isSuccess = true;
                                }
                            }
                        }
                        else
                        {
                            objResponse.Status = 1;
                            objResponse.OutMessage = "Invalid or corrupted refernece document found.";
                            intValid = 1;
                        }
                    }
                    else
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "No refernece document found for download.";
                        intValid = 1;
                    }
                }

                if (ObjParam.Status.ToString().Trim() == "2") //// Approved
                {
                    if (ObjParam.ApprovalDoc.Trim() == "")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "Approval document should not be blank.";
                        intValid = 1;
                    }
                    else if (ObjParam.ApprovalDoc.Trim() != "")
                    {

                        byte[] data;
                        using (WebClient client = new WebClient())
                        {
                            string strAddress = ObjParam.ApprovalDoc;
                            data = client.DownloadData(strAddress);
                        }

                        if (data.Length > 0)
                        {
                            if (IsFileValid(data))
                            {
                                if (!string.IsNullOrEmpty(strTempFolderPath))
                                {
                                    Uri uri = new Uri(ObjParam.ApprovalDoc);
                                    string filename = System.IO.Path.GetFileName(uri.AbsolutePath);
                                    Approvefilename = string.Format("{0:yyyy_MM_dd_hh_mm_ss_tt_}" + "_" + filename.Trim(), DateTime.Now);
                                    ApproveFileFullPath = strTempFolderPath + Approvefilename;
                                    fileStream = new FileStream(ApproveFileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    using (System.IO.FileStream fs = fileStream)
                                    {
                                        fs.Write(data, 0, data.Length);
                                        isSuccess = true;
                                    }
                                }
                            }
                            else
                            {
                                objResponse.Status = 1;
                                objResponse.OutMessage = "Invalid or corrupted Approval document found.";
                                intValid = 1;
                            }
                        }
                        else
                        {
                            objResponse.Status = 1;
                            objResponse.OutMessage = "No Approval document found for download.";
                            intValid = 1;
                        }
                    }
                }


                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] objArray = new object[] { "@P_VCH_ACTION", "U",
                                                       "@P_VCH_APPLICATION_NO",ObjParam.ApplicationNo,
                                                       "@P_INT_SERVICEID",ObjParam.ServiceId,
                                                       "@P_INT_STATUS",ObjParam.Status,
                                                       "@P_VCH_CERTIFICATE_FILENAME",Approvefilename,
                                                       "@P_VCH_REFERENCE_DOC_NAME",ReferenceFilename,
                                                       "@P_VCH_REMARK",ObjParam.Remarks
                                                    };

                    string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_FETCH_PAYMENT_DETAILS", out param, objArray).ToString();

                    if (param.ToString() == "1")
                    {
                        objResponse.Status = 2;
                        objResponse.OutMessage = "Success";
                    }
                    else if (param.ToString() == "4")
                    {
                        objResponse.Status = 4;
                        objResponse.OutMessage = "Wrong Application Number.";
                    }
                    else if (param.ToString() == "5")
                    {
                        objResponse.Status = 5;
                        objResponse.OutMessage = "Invalid Application Number.";
                    }
                    else
                    {
                        objResponse.Status = 0;
                        objResponse.OutMessage = "Some Error Occured.Please Contact Administrator.";
                    }
                }

                /*-----------------------------------------------------------*/
                ///// Write response log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objResponse);
                string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
                Util.LogRequestResponse("GoSmileService", "ApplicationStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;

                Util.LogError(ex, "GoSmileService");
            }
            lstResponse.Add(objResponse);
            return lstResponse;
        }

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

    }
}