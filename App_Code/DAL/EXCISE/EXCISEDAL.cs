using EntityLayer.EXCISEEntity;
using SWP_Services.DAL.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for EXCISEDAL
/// </summary>
/// 
namespace DataAcessLayer.EXCISEDAL
{
    public class EXCISEDAL : IEXCISEDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString();
        string RetValue;
        object param = new object();
        string strEXCISESecurityKey = ConfigurationManager.AppSettings["EXCISESecurityKey"].ToString();

        #region Application Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for EXCISE application status update.
        /// </summary>
        /// <param name="objExcise"></param>
        /// <returns></returns>
        public List<clsOutput> ExciseApplicationStatusUpdate(EXCISEEntity objExcise)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();
            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + objExcise.ApplicationNo.Trim() + " Security Key:- " + objExcise.SecurityKey.Trim();
                Util.LogRequestResponse("EXCISE", "ExciseApplicationStatusUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (objExcise.SecurityKey.Trim() != strEXCISESecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (objExcise.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (objExcise.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (objExcise.Status.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Status should not be blank.";
                    intValid = 1;
                }
                else if (objExcise.Remarks.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Remarks should not be blank.";
                    intValid = 1;
                }
                
                //if (objExcise.Status.ToString().Trim() == "3") //// Rejected
                //{
                //    if (objExcise.ReferenceDocFileLink.Trim() == "")
                //    {
                //        objResponse.Status = 1;
                //        objResponse.OutMessage = "Reference document link should not be blank.";
                //        intValid = 1;
                //    }
                //}

                //if (objExcise.Status.ToString().Trim() == "2") //// Approved
                //{
                //    if (objExcise.ApprovalDocFileLink.Trim() == "")
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
                                                       "@P_VCH_APPLICATION_UNQ_KEY",objExcise.ApplicationNo,
                                                       "@P_INT_SERVICEID",objExcise.ServiceId,
                                                       "@P_INT_STATUS",objExcise.Status,
                                                       "@P_VCH_CERTIFICATE_FILENAME",objExcise.ApprovalDocFileLink,
                                                       "@P_VCH_REMARK",objExcise.Remarks,
                                                       "@P_VCH_REFERENCE_DOC_NAME",objExcise.ReferenceDocFileLink
                                                    };

                    string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_EXCISE_ALLOTMENT", out param, objArray).ToString();

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
                Util.LogRequestResponse("EXCISE", "ExciseApplicationStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "EXCISE");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion

        #region Payment Status Update

        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2019 for EXCISE payment status update.
        /// </summary>
        /// <param name="objExcise"></param>
        /// <returns></returns>
        public List<clsOutput> ExcisePaymentStatusUpdate(EXCISEEntity objExcise)
        {
            clsOutput objResponse = new clsOutput();
            List<clsOutput> lstResponse = new List<clsOutput>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Application No :- " + objExcise.ApplicationNo.Trim() + " Security Key:- " + objExcise.SecurityKey.Trim();
                Util.LogRequestResponse("EXCISE", "ExcisePaymentStatusUpdate", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/

                int intValid = 0;

                #region Validation

                if (objExcise.SecurityKey.Trim() != strEXCISESecurityKey)
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid security key.";
                    intValid = 1;
                }
                else if (objExcise.ApplicationNo.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Application number should not be blank.";
                    intValid = 1;
                }
                else if (objExcise.ServiceId.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Service id should not be blank.";
                    intValid = 1;
                }
                else if (objExcise.PaymentStatus.ToString().Trim() != "1")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Invalid payment status.";
                    intValid = 1;
                }
                else if (objExcise.PaymentAmount.ToString().Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Payment amount should not be blank.";
                    intValid = 1;
                }
                else if (objExcise.BankTransId.Trim() == "")
                {
                    objResponse.Status = 1;
                    objResponse.OutMessage = "Bank transction id should not be blank.";
                    intValid = 1;
                }
                else if (objExcise.ChallanNo.Trim() == "")
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
                                                  "@P_VCH_APPLICATION_UNQ_KEY",objExcise.ApplicationNo,
                                                  "@P_INT_SERVICEID",objExcise.ServiceId,
                                                  "@P_INT_PAYMENT_STATUS",objExcise.PaymentStatus,
                                                  "@P_NUM_PAYMENT_AMOUNT",objExcise.PaymentAmount,
                                                  "@P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objExcise.BankTransId,
                                                  "@P_VCH_CHALLAN_NO",objExcise.ChallanNo
                                                };

                    string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_EXCISE_ALLOTMENT", out param, arr).ToString();

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
                Util.LogRequestResponse("EXCISE", "ExcisePaymentStatusUpdate", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (SqlException ex)
            {
                objResponse.Status = 3;
                objResponse.OutMessage = ex.Message;
                Util.LogError(ex, "EXCISE");
            }

            lstResponse.Add(objResponse);
            return lstResponse;
        }

        #endregion

        //#region  Query Status Update

        ///// <summary>
        ///// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for EXCISE query status update.
        ///// </summary>
        ///// <param name="objExcise"></param>
        ///// <returns></returns>
        //public List<clsOutput> ExciseQueryStatusUpdate(EXCISEEntity objExcise)
        //{
        //    clsOutput objResponse = new clsOutput();
        //    List<clsOutput> lstResponse = new List<clsOutput>();

        //    try
        //    {
        //        ///// Write request log for each request.
        //        string strInput = "(Request)---Application No :- " + objExcise.ApplicationNo.Trim() + " Security Key:- " + objExcise.SecurityKey.Trim();
        //        Util.LogRequestResponse("EXCISE", "ExciseQueryStatusUpdate", strInput);

        //        /*--------------------------------------------------------------------*/
        //        ////// Validation Section
        //        /*--------------------------------------------------------------------*/
        //        int intValid = 0;

        //        #region Validation

        //        if (objExcise.SecurityKey.Trim() != strEXCISESecurityKey)
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Invalid security key.";
        //            intValid = 1;
        //        }
        //        else if (objExcise.ApplicationNo.Trim() == "")
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Application number should not be blank.";
        //            intValid = 1;
        //        }
        //        else if (objExcise.ServiceId.ToString().Trim() == "")
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Service id should not be blank.";
        //            intValid = 1;
        //        }
        //        else if (objExcise.QueryStatus.ToString().Trim() == "")
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Query status should not be blank.";
        //            intValid = 1;
        //        }
        //        else if (objExcise.QueryStatus.ToString().Trim() != "5" && objExcise.QueryStatus.ToString().Trim() != "6")
        //        {
        //            objResponse.Status = 1;
        //            objResponse.OutMessage = "Invalid query status.";
        //            intValid = 1;
        //        }

        //        #endregion

        //        /*--------------------------------------------------------------------*/

        //        if (intValid == 0)
        //        {
        //            object[] arr = new object[] {  "@P_VCH_ACTION","QU",
        //                                           "@P_VCH_APPLICATION_UNQ_KEY",objExcise.ApplicationNo,
        //                                           "@P_INT_SERVICEID",objExcise.ServiceId,
        //                                           "@P_INT_QUERY_STATUS",objExcise.QueryStatus
        //                                        };

        //            string RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_EXCISE_ALLOTMENT", out param, arr).ToString();

        //            if (param.ToString() == "1")
        //            {
        //                objResponse.Status = 2;
        //                objResponse.OutMessage = "Success";
        //            }
        //            else if (param.ToString() == "4")
        //            {
        //                objResponse.Status = 4;
        //                objResponse.OutMessage = "Invalid Application Number.";
        //            }
        //            else if (param.ToString() == "5")
        //            {
        //                objResponse.Status = 5;
        //                objResponse.OutMessage = "Invalid Service Id.";
        //            }
        //            else
        //            {
        //                objResponse.Status = 0;
        //                objResponse.OutMessage = "Some Error Occured.Please Contact Administrator.";
        //            }
        //        }

        //        /*-----------------------------------------------------------*/
        //        ///// Write response log for each request.
        //        JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
        //        var json = jsonSerialiser.Serialize(objResponse);
        //        string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
        //        Util.LogRequestResponse("EXCISE", "ExciseQueryStatusUpdate", strOutput);
        //        /*-----------------------------------------------------------*/
        //    }
        //    catch (SqlException ex)
        //    {
        //        objResponse.Status = 3;
        //        objResponse.OutMessage = ex.Message;
        //        Util.LogError(ex, "EXCISE");
        //    }

        //    lstResponse.Add(objResponse);
        //    return lstResponse;
        //}

        //#endregion
    }
}