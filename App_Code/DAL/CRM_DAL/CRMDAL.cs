using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer.CRMEntity;
using System.Data.SqlClient;
using SWP_Services.DAL.Data;
using System.Data;
using System.Configuration;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for CRMDAL
/// </summary>

namespace DataAcessLayer.CRMDAL
{
    public class CRMDAL : ICRMDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString());
        string strCRMSecurityKey = ConfigurationManager.AppSettings["CRMSecurityKey"].ToString();

        /// <summary>
        /// Method to get PEAL information against SSO id
        /// Added by Sushant Jena on Dt:20-Aug-2019
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public CRMPealStatusResponse getPEALInfo(CRMEntity objDATA)
        {
            CRMPealStatusResponse objResStatus = new CRMPealStatusResponse();
            List<CRMPealDetails> lstResponse = new List<CRMPealDetails>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---SSO ID :- " + objDATA.strSSOId.Trim() + " Security Key:- " + objDATA.strSecurityKey.Trim();
                Util.LogRequestResponse("CRM", "getPEALInfo", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (objDATA.strSSOId.Trim() == "")
                {
                    objResStatus.intStatus = 1;
                    objResStatus.strStatusMsg = "Invalid SSO Id or SSO id is blank.";
                    intValid = 1;
                }
                else if (objDATA.strSecurityKey.Trim() != strCRMSecurityKey)
                {
                    objResStatus.intStatus = 2;
                    objResStatus.strStatusMsg = "Invalid Security Key.";
                    intValid = 1;
                }

                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_FETCH_CRM_DATA";

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@P_VCH_ACTION", "P");
                    cmd.Parameters.AddWithValue("@P_VCH_SSO_UNIQUE_ID", objDATA.strSSOId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int intValidStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["intValidStatus"]);

                        if (intValidStatus == 3) //// Success
                        {
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                objResStatus.intStatus = 3;
                                objResStatus.strStatusMsg = "Success";

                                foreach (DataRow dr in ds.Tables[1].Rows)
                                {
                                    lstResponse.Add(new CRMPealDetails()
                                    {
                                        strProposalNo = Convert.ToString(dr["vchProposalNo"]),
                                        strCompanyName = Convert.ToString(dr["vchCompName"]),
                                        intApplicationStatus = Convert.ToInt32(dr["intApprovalStatus"]),
                                        strAppliedDate = Convert.ToString(dr["dtmCreatedOn"]),
                                        strApprovalDate = Convert.ToString(dr["dtmUpdatedOn"]),
                                        intQueryStatus = Convert.ToInt32(dr["intQueryStatus"])
                                    });
                                }

                                objResStatus.CRMPealDetails = lstResponse;
                            }
                            else
                            {
                                objResStatus.intStatus = 4;
                                objResStatus.strStatusMsg = "Success";
                            }
                        }
                        else if (intValidStatus == 1)
                        {
                            objResStatus.intStatus = 1;
                            objResStatus.strStatusMsg = "Invalid SSO Id or SSO id is blank.";
                        }
                        else
                        {
                            objResStatus.intStatus = 0;
                            objResStatus.strStatusMsg = "Failed !";
                        }
                    }
                }

                /*-----------------------------------------------------------*/
                ///// Write response log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objResStatus);
                string strOutput = "(Response)---Valid Status :- " + intValid.ToString() + " OutputString:- " + json;
                Util.LogRequestResponse("CRM", "getPEALInfo", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (Exception ex)
            {
                objResStatus.intStatus = 5;
                objResStatus.strStatusMsg = "Exception Occured.";

                Util.LogError(ex, "CRM");
            }

            return objResStatus;
        }

        /// <summary>
        /// Method to get Service Information
        /// Added by Sushant Jena on Dt:21-Aug-2019
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public CRMServiceStatusResponse getServiceInfo(CRMEntity objDATA)
        {
            CRMServiceStatusResponse objResStatus = new CRMServiceStatusResponse();
            List<CRMServiceDetails> lstResponse = new List<CRMServiceDetails>();

            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---SSO ID :- " + objDATA.strSSOId.Trim() + " Security Key:- " + objDATA.strSecurityKey.Trim();
                Util.LogRequestResponse("CRM", "getServiceInfo", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (objDATA.strSSOId.Trim() == "")
                {
                    objResStatus.intStatus = 1;
                    objResStatus.strStatusMsg = "Invalid SSO Id or SSO id is blank.";
                    intValid = 1;
                }
                else if (objDATA.strSecurityKey.Trim() != strCRMSecurityKey)
                {
                    objResStatus.intStatus = 2;
                    objResStatus.strStatusMsg = "Invalid Security Key.";
                    intValid = 1;
                }

                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "USP_FETCH_CRM_DATA";

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@P_VCH_ACTION", "S"); //// For Service
                    cmd.Parameters.AddWithValue("@P_VCH_SSO_UNIQUE_ID", objDATA.strSSOId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int intValidStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["intValidStatus"]);

                        if (intValidStatus == 3) //// Success
                        {
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                objResStatus.intStatus = 3;
                                objResStatus.strStatusMsg = "Success";

                                foreach (DataRow dr in ds.Tables[1].Rows)
                                {
                                    lstResponse.Add(new CRMServiceDetails()
                                    {
                                        strApplicationNo = Convert.ToString(dr["VCH_APPLICATION_UNQ_KEY"]),
                                        intServiceId = Convert.ToInt32(dr["INT_SERVICEID"]),
                                        intApplicationStatus = Convert.ToInt32(dr["INT_STATUS"]),
                                        strAppliedDate = Convert.ToString(dr["DTM_CREATEDON"]),
                                        strApprovalDate = Convert.ToString(dr["DTM_UPDATEDON"]),
                                        intQueryStatus = Convert.ToInt32(dr["intQueryStatus"])
                                    });
                                }


                                objResStatus.CRMServiceDetails = lstResponse;
                            }
                            else
                            {
                                objResStatus.intStatus = 4;
                                objResStatus.strStatusMsg = "Success";
                            }
                        }
                        else if (intValidStatus == 1)
                        {
                            objResStatus.intStatus = 1;
                            objResStatus.strStatusMsg = "Invalid SSO Id or SSO id is blank.";
                        }
                        else
                        {
                            objResStatus.intStatus = 0;
                            objResStatus.strStatusMsg = "Failed !";
                        }
                    }
                }
                /*-----------------------------------------------------------*/
                ///// Write response log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objResStatus);
                string strOutput = "(Response)---Valid Status :- " + intValid.ToString() + " OutputString:- " + json;
                Util.LogRequestResponse("CRM", "getServiceInfo", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (Exception ex)
            {
                objResStatus.intStatus = 5;
                objResStatus.strStatusMsg = "Exception Occured.";

                Util.LogError(ex, "CRM");
            }

            return objResStatus;
        }
    }
}