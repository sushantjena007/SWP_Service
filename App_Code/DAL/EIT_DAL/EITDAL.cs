using EntityLayer.EITEntity;
using SWP_Services.DAL.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for EITDAL
/// </summary>
/// 
namespace DataAcessLayer.EITDAL
{
    public class EITDAL : IEITDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString();
        string RetValue;
        object param = new object();
        string strEITSecurityKey = ConfigurationManager.AppSettings["EITSecurityKey"].ToString();

        #region Application Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 22-Jan-2021 for EIT application status update.
        /// </summary>
        /// <param name="objEIT"></param>
        /// <returns></returns>
        public List<clsOutput> EITApplicationStatusUpdate(EITEntity objEIT)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();
            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + objEIT.ApplicationNo.Trim() + " Security Key:- " + objEIT.SecurityKey.Trim();
                Util.LogRequestResponse("EIT", "EITApplicationStatusUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (objEIT.SecurityKey.Trim() != strEITSecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (objEIT.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (objEIT.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (objEIT.Status.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Status should not be blank.";
                    intValid = 1;
                }
                else if (objEIT.Remarks.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Remarks should not be blank.";
                    intValid = 1;
                }

                //if (objEIT.Status.ToString().Trim() == "3") //// Rejected
                //{
                //    if (objEIT.ReferenceDocFileLink.Trim() == "")
                //    {
                //        objResponse.Status = 1;
                //        objResponse.OutMessage = "Reference document link should not be blank.";
                //        intValid = 1;
                //    }
                //}

                //if (objEIT.Status.ToString().Trim() == "2") //// Approved
                //{
                //    if (objEIT.ApprovalDocFileLink.Trim() == "")
                //    {
                //        objResponse.Status = 1;
                //        objResponse.OutMessage = "Approval document link should not be blank.";
                //        intValid = 1;
                //    }
                //}


                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] objArray = new object[] { "@P_VCH_ACTION", "ASU",
                                                       "@P_VCH_APPLICATION_UNQ_KEY",objEIT.ApplicationNo,
                                                       "@P_INT_SERVICEID",objEIT.ServiceId,
                                                       "@P_INT_STATUS",objEIT.Status,
                                                       "@P_VCH_CERTIFICATE_FILENAME",objEIT.ApprovalDocFileLink,
                                                       "@P_VCH_REMARK",objEIT.Remarks,
                                                       "@P_VCH_REFERENCE_DOC_NAME",objEIT.ReferenceDocFileLink
                                                    };

                    string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_EIT_ALLOTMENT", out param, objArray).ToString();

                    if (param.ToString() == "1")
                    {
                        objResponse.Status = 2;
                        objResponse.OutMessage = "Success";
                    }
                    else if (param.ToString() == "4")
                    {
                        objResponse.Status = 4;
                        objResponse.OutMessage = "Invalid Application Number.";
                    }
                    else if (param.ToString() == "5")
                    {
                        objResponse.Status = 5;
                        objResponse.OutMessage = "Invalid Service Id.";
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
                Util.LogRequestResponse("EIT", "EITApplicationStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "EIT");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion

        #region Payment Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 22-Jan-2021 for EIT payment status update.
        /// </summary>
        /// <param name="objEIT"></param>
        /// <returns></returns>
        public List<clsOutput> EITPaymentStatusUpdate(EITEntity objEIT)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + objEIT.ApplicationNo.Trim() + " Security Key:- " + objEIT.SecurityKey.Trim();
                Util.LogRequestResponse("EIT", "EITPaymentStatusUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/

                int intValid = 0;

                #region Validation

                if (objEIT.SecurityKey.Trim() != strEITSecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (objEIT.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (objEIT.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (objEIT.PaymentStatus.ToString().Trim() != "1" && objEIT.PaymentStatus.ToString().Trim() != "0")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid payment status.";
                    intValid = 1;
                }

                if (objEIT.PaymentStatus.ToString().Trim() == "1")
                {
                    if (objEIT.PaymentAmount.ToString().Trim() == "")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "Payment amount should not be blank.";
                        intValid = 1;
                    }
                    else if (objEIT.BankTransId.Trim() == "")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "Bank transction id should not be blank.";
                        intValid = 1;
                    }
                    else if (objEIT.ChallanNo.Trim() == "")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "Challan number should not be blank.";
                        intValid = 1;
                    }
                }

                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] arr = new object[] { "@P_VCH_ACTION","PU",
                                                  "@P_VCH_APPLICATION_UNQ_KEY",objEIT.ApplicationNo,
                                                  "@P_INT_SERVICEID",objEIT.ServiceId,
                                                  "@P_INT_PAYMENT_STATUS",objEIT.PaymentStatus,
                                                  "@P_NUM_PAYMENT_AMOUNT",objEIT.PaymentAmount,
                                                  "@P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objEIT.BankTransId,
                                                  "@P_VCH_CHALLAN_NO",objEIT.ChallanNo
                                                };

                    string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_EIT_ALLOTMENT", out param, arr).ToString();

                    if (param.ToString() == "1")
                    {
                        objResponse.Status = 2;
                        objResponse.OutMessage = "Success";
                    }
                    else if (param.ToString() == "4")
                    {
                        objResponse.Status = 4;
                        objResponse.OutMessage = "Invalid Application Number.";
                    }
                    else if (param.ToString() == "5")
                    {
                        objResponse.Status = 5;
                        objResponse.OutMessage = "Invalid Service Id.";
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
                Util.LogRequestResponse("EIT", "EITPaymentStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "EIT");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion

        #region  Query Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 22-Jan-2021 for EIT query status update.
        /// </summary>
        /// <param name="objEIT"></param>
        /// <returns></returns>
        public List<clsOutput> EITQueryStatusUpdate(EITEntity objEIT)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + objEIT.ApplicationNo.Trim() + " Security Key:- " + objEIT.SecurityKey.Trim();
                Util.LogRequestResponse("EIT", "EITQueryStatusUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (objEIT.SecurityKey.Trim() != strEITSecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (objEIT.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (objEIT.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (objEIT.QueryStatus.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Query status should not be blank.";
                    intValid = 1;
                }
                else if (objEIT.QueryStatus.ToString().Trim() != "5" && objEIT.QueryStatus.ToString().Trim() != "6")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid query status.";
                    intValid = 1;
                }

                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] arr = new object[] {  "@P_VCH_ACTION","QU",
                                                   "@P_VCH_APPLICATION_UNQ_KEY",objEIT.ApplicationNo,
                                                   "@P_INT_SERVICEID",objEIT.ServiceId,
                                                   "@P_INT_QUERY_STATUS",objEIT.QueryStatus
                                                };

                    string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_EIT_ALLOTMENT", out param, arr).ToString();

                    if (param.ToString() == "1")
                    {
                        objResponse.Status = 2;
                        objResponse.OutMessage = "Success";
                    }
                    else if (param.ToString() == "4")
                    {
                        objResponse.Status = 4;
                        objResponse.OutMessage = "Invalid Application Number.";
                    }
                    else if (param.ToString() == "5")
                    {
                        objResponse.Status = 5;
                        objResponse.OutMessage = "Invalid Service Id.";
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
                Util.LogRequestResponse("EIT", "EITQueryStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "EIT");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion
    }
}