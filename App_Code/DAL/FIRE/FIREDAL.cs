using EntityLayer.FIREEntity;
using SWP_Services.DAL.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for FIREDAL
/// </summary>
/// 
namespace DataAcessLayer.FIREDAL
{
    public class FIREDAL : IFIREDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString();
        string RetValue;
        object param = new object();
        string strFIRESecurityKey = ConfigurationManager.AppSettings["FIRESecurityKey"].ToString();

        #region Application Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for Fire safety application status update.
        /// </summary>
        /// <param name="objFire"></param>
        /// <returns></returns>
        public List<clsOutput> FireApplicationStatusUpdate(FIREEntity objFire)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();
            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + objFire.ApplicationNo.Trim() + " Security Key:- " + objFire.SecurityKey.Trim();
                Util.LogRequestResponse("FIRE", "FireApplicationStatusUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (objFire.SecurityKey.Trim() != strFIRESecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (objFire.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (objFire.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (objFire.Status.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Status should not be blank.";
                    intValid = 1;
                }
                else if (objFire.Remarks.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Remarks should not be blank.";
                    intValid = 1;
                }

                //if (objFire.Status.ToString().Trim() == "3") //// Rejected
                //{
                //    if (objFire.ReferenceDocFileLink.Trim() == "")
                //    {
                //        objResponse.Status = 1;
                //        objResponse.OutMessage = "Reference document link should not be blank.";
                //        intValid = 1;
                //    }
                //}

                if (objFire.Status.ToString().Trim() == "2") //// Approved
                {
                    if (objFire.ApprovalDocFileLink.Trim() == "")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "Approval document link should not be blank.";
                        intValid = 1;
                    }
                }


                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] objArray = new object[] { "@P_VCH_ACTION", "ASU",
                                                       "@P_VCH_APPLICATION_UNQ_KEY",objFire.ApplicationNo,
                                                       "@P_INT_SERVICEID",objFire.ServiceId,
                                                       "@P_INT_STATUS",objFire.Status,
                                                       "@P_VCH_CERTIFICATE_FILENAME",objFire.ApprovalDocFileLink,
                                                       "@P_VCH_REMARK",objFire.Remarks,
                                                       "@P_VCH_REFERENCE_DOC_NAME",objFire.ReferenceDocFileLink
                                                    };

                    RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_FIRE_ALLOTMENT", out param, objArray).ToString();

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
                Util.LogRequestResponse("FIRE", "FireApplicationStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "FIRE");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion

        #region Payment Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2019 for Fire safety payment status update.
        /// </summary>
        /// <param name="objFire"></param>
        /// <returns></returns>
        public List<clsOutput> FirePaymentUpdate(FIREEntity objFire)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + objFire.ApplicationNo.Trim() + " Security Key:- " + objFire.SecurityKey.Trim();
                Util.LogRequestResponse("FIRE", "FirePaymentUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/

                int intValid = 0;

                #region Validation

                if (objFire.SecurityKey.Trim() != strFIRESecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (objFire.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (objFire.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (objFire.PaymentStatus.ToString().Trim() != "1")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid payment status.";
                    intValid = 1;
                }
                else if (objFire.PaymentAmount.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Payment amount should not be blank.";
                    intValid = 1;
                }
                else if (objFire.BankTransId.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Bank transction id should not be blank.";
                    intValid = 1;
                }
                else if (objFire.ChallanNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Challan number should not be blank.";
                    intValid = 1;
                }


                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] arr = new object[] { "@P_VCH_ACTION","PU",
                                                  "@P_VCH_APPLICATION_UNQ_KEY",objFire.ApplicationNo,
                                                  "@P_INT_SERVICEID",objFire.ServiceId,
                                                  "@P_INT_PAYMENT_STATUS",objFire.PaymentStatus,
                                                  "@P_NUM_PAYMENT_AMOUNT",objFire.PaymentAmount,
                                                  "@P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objFire.BankTransId,
                                                  "@P_VCH_CHALLAN_NO",objFire.ChallanNo
                                                };

                    string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_FIRE_ALLOTMENT", out param, arr).ToString();

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
                Util.LogRequestResponse("FIRE", "FirePaymentUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "FIRE");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion

        #region Compliance Status or Query Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for Fire safety compliance or query status update.
        /// </summary>
        /// <param name="objFire"></param>
        /// <returns></returns>
        public List<clsOutput> FireQueryCompliance(FIREEntity objFire)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + objFire.ApplicationNo.Trim() + " Security Key:- " + objFire.SecurityKey.Trim();
                Util.LogRequestResponse("FIRE", "FireQueryCompliance", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (objFire.SecurityKey.Trim() != strFIRESecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (objFire.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (objFire.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (objFire.QueryStatus.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Query status should not be blank.";
                    intValid = 1;
                }
                else if (objFire.QueryStatus.ToString().Trim() != "5" && objFire.QueryStatus.ToString().Trim() != "6")
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
                                                   "@P_VCH_APPLICATION_UNQ_KEY",objFire.ApplicationNo,
                                                   "@P_INT_SERVICEID",objFire.ServiceId,
                                                   "@P_INT_QUERY_STATUS",objFire.QueryStatus
                                                };

                    string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_FIRE_ALLOTMENT", out param, arr).ToString();

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
                Util.LogRequestResponse("FIRE", "FireQueryCompliance", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "FIRE");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion
    }
}