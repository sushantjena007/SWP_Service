#region
//******************************************************************************************************************
// File Name             :   PollutionControl/PollutionControlDAL.cs
// Description           :   Call different services for different methods for Integration of Pollution Control
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
using System.Data.SqlClient;
using SWP_Services.DAL.Data;

/// <summary>
/// Summary description for PollutionControlDAL
/// </summary>
namespace SWP_Services.DAL
{
    public class PollutionControlDAL : IPollutionControlDAL
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;
        DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails objUser = new DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails();
        string RetValue;
        object param = new object();

        #region  "Fetch User Profile Details For Establish Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<PollutionControlUserProfile> GetUserProfilesEUW(PollutionAuthStatus objUser)
        {
            SqlDataReader reader;
            List<PollutionControlUserProfile> list = new List<PollutionControlUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID, 
                                             "P_vch_ProposalID ",objUser.StrProposalID
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_POLLUTION_CONTROL", arr);
                list = reader.DataReaderMapToList<PollutionControlUserProfile>(MappingDirection.Auto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                reader = null;
            }

            return list;
        }
        #endregion
        #region "Push User Data For Establish Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Establish Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<PollutionPushDataStatus> SWPPushDataEUWater(PollutionPushData objDATA)
        {
            PollutionPushDataStatus objResponse = new PollutionPushDataStatus();
            List<PollutionPushDataStatus> lstResponse = new List<PollutionPushDataStatus>();

            try
            {
                object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
                                                   "P_vch_ProposalID",objDATA.strIndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
                                                   "P_SERVICEID",objDATA.intServiceID,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
                                                   "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_INT_ESCALATION_ID",objDATA.strEscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.strULBCode,
                                                   "P_INT_CREATEDBY",objDATA.strUserID
                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_POLLUTION_CONTROL", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.intStatus = 1;
                    objResponse.strStatusMsg = "Success";
                }
                else
                {
                    objResponse.intStatus = 0;
                    objResponse.strStatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
        #endregion

        #region  "Fetch User Profile Details For Establish Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Air Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<PollutionControlUserProfile> GetUserProfilesEUA(PollutionAuthStatus objUser)
        {
            SqlDataReader reader;
            List<PollutionControlUserProfile> list = new List<PollutionControlUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID,  
                                             "P_vch_ProposalID ",objUser.StrProposalID
                                           
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_POLLUTION_CONTROL", arr);
                list = reader.DataReaderMapToList<PollutionControlUserProfile>(MappingDirection.Auto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion
        #region "Push User Data For Establish Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Establish Under Air Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<PollutionPushDataStatus> SWPPushDataEUAir(PollutionPushData objDATA)
        {
            PollutionPushDataStatus objResponse = new PollutionPushDataStatus();
            List<PollutionPushDataStatus> lstResponse = new List<PollutionPushDataStatus>();

            try
            {
                object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
                                                   "P_vch_ProposalID",objDATA.strIndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
                                                   "P_SERVICEID",objDATA.intServiceID,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
                                                   "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_INT_ESCALATION_ID",objDATA.strEscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.strULBCode,
                                                   "P_INT_CREATEDBY",objDATA.strUserID                                                          
                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_POLLUTION_CONTROL", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.intStatus = 1;
                    objResponse.strStatusMsg = "Success";
                }
                else
                {
                    objResponse.intStatus = 0;
                    objResponse.strStatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
        #endregion

        #region  "Fetch User Profile Details For Operate Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Operate Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<PollutionControlUserProfile> GetUserProfilesOUW(PollutionAuthStatus objUser)
        {
            SqlDataReader reader;
            List<PollutionControlUserProfile> list = new List<PollutionControlUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID,  
                                             "P_vch_ProposalID ",objUser.StrProposalID
                                           
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_POLLUTION_CONTROL", arr);
                list = reader.DataReaderMapToList<PollutionControlUserProfile>(MappingDirection.Auto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion
        #region "Push User Data For Operate Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Operate Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<PollutionPushDataStatus> SWPPushDataOUWater(PollutionPushData objDATA)
        {
            PollutionPushDataStatus objResponse = new PollutionPushDataStatus();
            List<PollutionPushDataStatus> lstResponse = new List<PollutionPushDataStatus>();

            try
            {
                object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
                                                   "P_vch_ProposalID",objDATA.strIndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
                                                   "P_SERVICEID",objDATA.intServiceID,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
                                                   "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_INT_ESCALATION_ID",objDATA.strEscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.strULBCode,
                                                   "P_INT_CREATEDBY",objDATA.strUserID                                                          
                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_POLLUTION_CONTROL", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.intStatus = 1;
                    objResponse.strStatusMsg = "Success";
                }
                else
                {
                    objResponse.intStatus = 0;
                    objResponse.strStatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
        #endregion

        #region  "Fetch User Profile Details For Operate Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Operate Under Air Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<PollutionControlUserProfile> GetUserProfilesOUA(PollutionAuthStatus objUser)
        {
            SqlDataReader reader;
            List<PollutionControlUserProfile> list = new List<PollutionControlUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID, 
                                             "P_vch_ProposalID ",objUser.StrProposalID
                                            
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_POLLUTION_CONTROL", arr);
                list = reader.DataReaderMapToList<PollutionControlUserProfile>(MappingDirection.Auto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion
        #region "Push User Data For Operate Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Operate Under Air Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<PollutionPushDataStatus> SWPPushDataOUAir(PollutionPushData objDATA)
        {
            PollutionPushDataStatus objResponse = new PollutionPushDataStatus();
            List<PollutionPushDataStatus> lstResponse = new List<PollutionPushDataStatus>();

            try
            {
                object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
                                                   "P_vch_ProposalID",objDATA.strIndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
                                                   "P_SERVICEID",objDATA.intServiceID,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
                                                   "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_INT_ESCALATION_ID",objDATA.strEscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.strULBCode,
                                                   "P_INT_CREATEDBY",objDATA.strUserID                                                          
                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_POLLUTION_CONTROL", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.intStatus = 1;
                    objResponse.strStatusMsg = "Success";
                }
                else
                {
                    objResponse.intStatus = 0;
                    objResponse.strStatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
        #endregion

        #region  "Fetch User Profile Details For Hazardous Waste Rules"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Hazardous Waste Rules
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<PollutionControlUserProfile> GetUserProfilesHW(PollutionAuthStatus objUser)
        {
            SqlDataReader reader;
            List<PollutionControlUserProfile> list = new List<PollutionControlUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID, 
                                             "P_vch_ProposalID ",objUser.StrProposalID
                                            
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_POLLUTION_CONTROL", arr);
                list = reader.DataReaderMapToList<PollutionControlUserProfile>(MappingDirection.Auto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion
        #region "Push User Data For Hazardous Waste Rules"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Hazardous Waste Rules
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<PollutionPushDataStatus> SWPPushDataHWaste(PollutionPushData objDATA)
        {
            PollutionPushDataStatus objResponse = new PollutionPushDataStatus();
            List<PollutionPushDataStatus> lstResponse = new List<PollutionPushDataStatus>();

            try
            {
                object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
                                                   "P_vch_ProposalID",objDATA.strIndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
                                                   "P_SERVICEID",objDATA.intServiceID,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
                                                   "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_INT_ESCALATION_ID",objDATA.strEscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.strULBCode,
                                                   "P_INT_CREATEDBY",objDATA.strUserID                                                           
                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_POLLUTION_CONTROL", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.intStatus = 1;
                    objResponse.strStatusMsg = "Success";
                }
                else
                {
                    objResponse.intStatus = 0;
                    objResponse.strStatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
        #endregion

        #region  "Fetch User Profile Details For Establish Under Both Water & Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<PollutionControlUserProfile> GetUserProfilesEBWA(PollutionAuthStatus objUser)
        {
            SqlDataReader reader;
            List<PollutionControlUserProfile> list = new List<PollutionControlUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID,
                                             "P_vch_ProposalID ",objUser.StrProposalID
                                             
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_POLLUTION_CONTROL", arr);
                list = reader.DataReaderMapToList<PollutionControlUserProfile>(MappingDirection.Auto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion
        #region "Push User Data For Establish Under Water Act & Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Establish Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<PollutionPushDataStatus> SWPPushDataEBWA(PollutionPushData objDATA)
        {
            PollutionPushDataStatus objResponse = new PollutionPushDataStatus();
            List<PollutionPushDataStatus> lstResponse = new List<PollutionPushDataStatus>();

            try
            {
                object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
                                                   "P_vch_ProposalID",objDATA.strIndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
                                                   "P_SERVICEID",objDATA.intServiceID,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
                                                   "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_INT_ESCALATION_ID",objDATA.strEscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.strULBCode,
                                                   "P_INT_CREATEDBY",objDATA.strUserID                                                           
                                                };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_POLLUTION_CONTROL", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.intStatus = 1;
                    objResponse.strStatusMsg = "Success";
                }
                else
                {
                    objResponse.intStatus = 0;
                    objResponse.strStatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
        #endregion

        #region  "Fetch User Profile Details For Operate Under Both Water & Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<PollutionControlUserProfile> GetUserProfilesOBWA(PollutionAuthStatus objUser)
        {
            SqlDataReader reader;
            List<PollutionControlUserProfile> list = new List<PollutionControlUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID,  
                                             "P_vch_ProposalID ",objUser.StrProposalID                                           
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_POLLUTION_CONTROL", arr);
                list = reader.DataReaderMapToList<PollutionControlUserProfile>(MappingDirection.Auto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion
        #region "Push User Data For Operate Under Water Act & Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Establish Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<PollutionPushDataStatus> SWPPushDataOBWA(PollutionPushData objDATA)
        {
            PollutionPushDataStatus objResponse = new PollutionPushDataStatus();
            List<PollutionPushDataStatus> lstResponse = new List<PollutionPushDataStatus>();

            try
            {
                object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
                                                   "P_vch_ProposalID",objDATA.strIndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
                                                   "P_SERVICEID",objDATA.intServiceID,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
                                                   "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_INT_ESCALATION_ID",objDATA.strEscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.strULBCode,
                                                   "P_INT_CREATEDBY",objDATA.strUserID                                                          
                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_POLLUTION_CONTROL", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.intStatus = 1;
                    objResponse.strStatusMsg = "Success";
                }
                else
                {
                    objResponse.intStatus = 0;
                    objResponse.strStatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
        #endregion

        #region  "Fetch User Profile Details For e-Waste Management"
        /// <summary>
        /// Created By Bhagyashree Das on 25-Nov-2020 for Fetch User Profile Details For e-Waste Management
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<PollutionControlUserProfile> GetUserProfilesWM(PollutionAuthStatus objUser)
        {
            SqlDataReader reader;
            List<PollutionControlUserProfile> list = new List<PollutionControlUserProfile>();
            object[] arr = new object[] { "P_vch_Action","WM",
                                          "P_vch_UserID",objUser.strUserID,   
                                          "P_vch_ProposalID ",objUser.StrProposalID
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_POLLUTION_CONTROL", arr);
                list = reader.DataReaderMapToList<PollutionControlUserProfile>(MappingDirection.Auto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion
        #region "Push User Data For e-Waste Management"
        /// <summary>
        /// Created By Bhagyashree Das on 25-Nov-2020 for Push User Data For e-Waste Management
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<PollutionPushDataStatus> SWPPushDataWM(PollutionPushData objDATA)
        {
            PollutionPushDataStatus objResponse = new PollutionPushDataStatus();
            List<PollutionPushDataStatus> lstResponse = new List<PollutionPushDataStatus>();

            try
            {
                object[] objArray = new object[] { "P_vch_Action", "PWM",
                                                   "P_vch_ProposalID",objDATA.strIndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
                                                   "P_SERVICEID",objDATA.intServiceID,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
                                                   "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_INT_ESCALATION_ID",objDATA.strEscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.strULBCode,
                                                   "P_INT_CREATEDBY",objDATA.strUserID                                                           
                                                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_POLLUTION_CONTROL", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.intStatus = 1;
                    objResponse.strStatusMsg = "Success";
                }
                else
                {
                    objResponse.intStatus = 0;
                    objResponse.strStatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
        #endregion

        #region  "Fetch User Profile Details For Plastic Waste Management"
        /// <summary>
        /// Created By Bhagyashree Das on 25-Nov-2020 for Fetch User Profile Details For Plastic Waste Management
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<PollutionControlUserProfile> GetUserProfilesPM(PollutionAuthStatus objUser)
        {
            SqlDataReader reader;
            List<PollutionControlUserProfile> list = new List<PollutionControlUserProfile>();
            object[] arr = new object[] {  "P_vch_Action","PM",
                                           "P_vch_UserID",objUser.strUserID,    
                                           "P_vch_ProposalID ",objUser.StrProposalID
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_POLLUTION_CONTROL", arr);
                list = reader.DataReaderMapToList<PollutionControlUserProfile>(MappingDirection.Auto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion
        #region "Push User Data For Plastic Waste Management"
        /// <summary>
        /// Created By Bhagyashree Das on 25-Nov-2020 for Push User Data For Plastic Waste Management
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<PollutionPushDataStatus> SWPPushDataPM(PollutionPushData objDATA)
        {
            PollutionPushDataStatus objResponse = new PollutionPushDataStatus();
            List<PollutionPushDataStatus> lstResponse = new List<PollutionPushDataStatus>();

            try
            {
                object[] objArray = new object[] { "P_vch_Action", "PPM",
                                                   "P_vch_ProposalID",objDATA.strIndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.strInvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.strApplicationNumber,
                                                   "P_SERVICEID",objDATA.intServiceID,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.intActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.intActionToBeTakenBy,
                                                   "P_INT_PAYMENT_STATUS",objDATA.intPaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.strPaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.decPaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_INT_ESCALATION_ID",objDATA.strEscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.strULBCode,
                                                   "P_INT_CREATEDBY",objDATA.strUserID                                                          
                                                };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_POLLUTION_CONTROL", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.intStatus = 1;
                    objResponse.strStatusMsg = "Success";
                }
                else
                {
                    objResponse.intStatus = 0;
                    objResponse.strStatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
        #endregion
    }
}