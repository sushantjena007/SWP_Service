using EntityLayer.PAReSHRAM_Entity;
using SWP_Services.DAL.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for PAReSHRAMDAL
/// </summary>
namespace DataAcessLayer.PAReSHRAMDAL
{
    public class PAReSHRAMDAL : IPAReSHRAMDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString();
        string RetValue;
        object param = new object();
        string strPAReSHRAMSecurityKey = ConfigurationManager.AppSettings["PAReSHRAMSecurityKey"].ToString();


        #region Payment Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 13-JAN-2021 for (F&B AND LABOUR) payment status update through PAReSHRAM Portal.
        /// </summary>
        /// <param name="objFire"></param>
        /// <returns></returns>
        public List<clsOutput> PSMPaymentStatusUpdate(PAReSHRAM_Entity ObjParam)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + ObjParam.ApplicationNo.Trim() + " Security Key:- " + ObjParam.SecurityKey.Trim();
                Util.LogRequestResponse("PAReSHRAM", "PSMPaymentStatusUpdate", strInput);

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
                else if (ObjParam.SecurityKey.Trim() != strPAReSHRAMSecurityKey)
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
                else if (ObjParam.PaymentStatus.ToString().Trim() != "1")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid payment status.";
                    intValid = 1;
                }
                else if (ObjParam.PaymentAmount.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Payment amount should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.BankTransId.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Bank transction id should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.ChallanNo.Trim() == "")
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
                                                  "@P_VCH_APPLICATION_UNQ_KEY",ObjParam.ApplicationNo,
                                                  "@P_INT_SERVICEID",ObjParam.ServiceId,
                                                  "@P_INT_PAYMENT_STATUS",ObjParam.PaymentStatus,
                                                  "@P_NUM_PAYMENT_AMOUNT",ObjParam.PaymentAmount,
                                                  "@P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",ObjParam.BankTransId,
                                                  "@P_VCH_CHALLAN_NO",ObjParam.ChallanNo
                                                };

                    RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_PAReSHRAM_ALLOTMENT", out param, arr).ToString();

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
                Util.LogRequestResponse("PAReSHRAM", "PSMPaymentStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "PAReSHRAM");
            }
            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion

        #region Application Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 13-JAN-2021 for (F&B AND LABOUR) application status update through PAReSHRAM Portal.
        /// </summary>
        /// <param name="objFire"></param>
        /// <returns></returns>
        public List<clsOutput> PSMApplicationStatusUpdate(PAReSHRAM_Entity ObjParam)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();
            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + ObjParam.ApplicationNo.Trim() + " Security Key:- " + ObjParam.SecurityKey.Trim();
                Util.LogRequestResponse("PAReSHRAM", "PSMApplicationStatusUpdate", strInput);

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
                else if (ObjParam.SecurityKey.Trim() != strPAReSHRAMSecurityKey)
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

                if (ObjParam.Status.ToString().Trim() == "3") //// Rejected
                {
                    if (ObjParam.ReferenceDocFileLink.Trim() == "")
                    {
                        objResponse.Status = 1;
                        objResponse.OutMessage = "Reference document link should not be blank.";
                        intValid = 1;
                    }
                }

                if (ObjParam.Status.ToString().Trim() == "2") //// Approved
                {
                    if (ObjParam.ApprovalDocFileLink.Trim() == "")
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
                                                       "@P_VCH_APPLICATION_UNQ_KEY",ObjParam.ApplicationNo,
                                                       "@P_INT_SERVICEID",ObjParam.ServiceId,
                                                       "@P_INT_STATUS",ObjParam.Status,
                                                       "@P_VCH_CERTIFICATE_FILENAME",ObjParam.ApprovalDocFileLink,
                                                       "@P_VCH_REMARK",ObjParam.Remarks,
                                                       "@P_VCH_REFERENCE_DOC_NAME",ObjParam.ReferenceDocFileLink
                                                    };

                    RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_PAReSHRAM_ALLOTMENT", out param, objArray).ToString();

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
                Util.LogRequestResponse("PAReSHRAM", "PSMApplicationStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "PAReSHRAM");
            }
            lstResponse.Add(objResponse);
            return lstResponse;
        }


        #endregion

        #region  Query Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 13-JAN-2021 for (F&B AND LABOUR) Query raise update through PAReSHRAM Portal.
        /// </summary>
        /// <param name="objFire"></param>
        /// <returns></returns>
        public List<clsOutput> PSMQueryStatusUpdate(PAReSHRAM_Entity ObjParam)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + ObjParam.ApplicationNo.Trim() + " Security Key:- " + ObjParam.SecurityKey.Trim();
                Util.LogRequestResponse("PAReSHRAM", "PSMQueryStatusUpdate", strInput);

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
                else if (ObjParam.SecurityKey.Trim() != strPAReSHRAMSecurityKey)
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
                else if (ObjParam.QueryStatus.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Query status should not be blank.";
                    intValid = 1;
                }
                else if (ObjParam.QueryStatus.ToString().Trim() != "5" && ObjParam.QueryStatus.ToString().Trim() != "6")
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
                                                   "@P_VCH_APPLICATION_UNQ_KEY",ObjParam.ApplicationNo,
                                                   "@P_INT_SERVICEID",ObjParam.ServiceId,
                                                   "@P_INT_QUERY_STATUS",ObjParam.QueryStatus
                                                };

                    RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_PAReSHRAM_ALLOTMENT", out param, arr).ToString();

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
                Util.LogRequestResponse("PAReSHRAM", "PSMQueryStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "PAReSHRAM");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion
    }
}