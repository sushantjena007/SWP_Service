#region
//******************************************************************************************************************
// File Name             :   ForestLicense/ForestLicenseDAL.cs
// Description           :   Call different services for different methods for Integration of Forest Department
// Created by            :   Pranay Kumar
// Created on            :   05-Sept-2017
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
/// Summary description for ForestLicenseDAL
/// </summary>
namespace SWP_Services.DAL
{
    public class ForestLicenseDAL : IForestLicenseDAL
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;
        DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails objUser = new DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails();
        string RetValue;
        object param = new object();

        #region  "Fetch User Profile Details For Tree Felling"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details For Tree Felling
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ForestLicenseUserProfile> GetUserProfilesTF(ForestAuthStatus objUser)
        {
            SqlDataReader reader;            
            List<ForestLicenseUserProfile> list = new List<ForestLicenseUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID,                                             
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_FOREST_LICENSE", arr);
                list = reader.DataReaderMapToList<ForestLicenseUserProfile>(MappingDirection.Auto);

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
        #region "Push User Data For Tree Felling"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Tree Felling
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<ForestPushDataStatus> SWPPushDataTreeF(ForestPushData objDATA)
        {
            ForestPushDataStatus objResponse = new ForestPushDataStatus();
            List<ForestPushDataStatus> lstResponse = new List<ForestPushDataStatus>();
            
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

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_FOREST_LICENSE", out param, objArray).ToString();
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
        #region  "Fetch User Profile Details for Tree Transit"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details for Tree Transit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ForestLicenseUserProfile> GetUserProfilesTT(ForestAuthStatus objUser)
        {
            SqlDataReader reader;
            List<ForestLicenseUserProfile> list = new List<ForestLicenseUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID,                                             
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_FOREST_LICENSE", arr);
                list = reader.DataReaderMapToList<ForestLicenseUserProfile>(MappingDirection.Auto);

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
        #region "Push User Data For Tree Transit"
        /// <summary>
        /// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Tree Transit
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<ForestPushDataStatus> SWPPushDataTreeTransit(ForestPushData objDATA)
        {
            ForestPushDataStatus objResponse = new ForestPushDataStatus();
            List<ForestPushDataStatus> lstResponse = new List<ForestPushDataStatus>();
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

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_FOREST_LICENSE", out param, objArray).ToString();
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
        #region  "Fetch User Profile Details for Felling Tree"
        /// <summary>
        /// Created By Pranay Kumar on 06-Sept-2017 for Fetch User Profile Details for Felling Tree
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ForestLicenseUserProfile> GetUserProfilesFellT(ForestAuthStatus objUser)
        {
            SqlDataReader reader;
            List<ForestLicenseUserProfile> list = new List<ForestLicenseUserProfile>();
            object[] arr = new object[] {    "P_vch_Action",objUser.strAction,
                                             "P_vch_UserID",objUser.strUserID,                                             
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_SERVICE_FOREST_LICENSE", arr);
                list = reader.DataReaderMapToList<ForestLicenseUserProfile>(MappingDirection.Auto);

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
        #region "Push User Data For Felling Tree"
        /// <summary>
        /// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Felling Tree
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<ForestPushDataStatus> SWPPushDataFellT(ForestPushData objDATA)
        {
            ForestPushDataStatus objResponse = new ForestPushDataStatus();
            List<ForestPushDataStatus> lstResponse = new List<ForestPushDataStatus>();
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

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_FOREST_LICENSE", out param, objArray).ToString();
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