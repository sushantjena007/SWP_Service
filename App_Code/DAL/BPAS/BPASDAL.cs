using SWP_Services.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BPASControlDAL
/// </summary>

namespace SWP_Services.DAL
{
    public class BPASDAL : IBPASDAL
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;
        DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails objUser = new DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails();
        string RetValue;
        object param = new object();


        #region  "BPAS PayMent Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS PayMent Status Update
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<BPASPushDataStatus> BPASPayMentUpdate(BPASPaymentStatus objUser)
        {
            BPASPushDataStatus objResponse = new BPASPushDataStatus();
            List<BPASPushDataStatus> lstResponse = new List<BPASPushDataStatus>();
            try
            {
                object[] arr = new object[] {  "P_vch_Action",objUser.strAction,
                                               "P_vch_UserID",objUser.strUniqueID,
                                               "P_SERVICEID",objUser.intServiceid,
                                               "P_INT_PAYMENT_STATUS",objUser.intpaymentstatus,
                                               "P_NUM_PAYMENT_AMOUNT",objUser.decpaymentamount,                                               
                                        };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_BPAS", out param, arr).ToString();
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

        #region "BPAS Application Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS Application Status Update
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<BPASPushDataStatus> BPASApplicationStatusUpdate(BPASPushData objDATA)
        {
            BPASPushDataStatus objResponse = new BPASPushDataStatus();
            List<BPASPushDataStatus> lstResponse = new List<BPASPushDataStatus>();            
            try
            {
                object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
                                                   "P_vch_UserID",objDATA.strUniqueID,
                                                   "P_SERVICEID",objDATA.intServiceid,
                                                   "P_INT_STATUS",objDATA.intApplicationStatus,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.strCertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.strReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.strRemark,
                                                   "P_VCH_APPLICATION_NO",objDATA.strApplicationNumber
                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_BPAS", out param, objArray).ToString();           


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

        #region "BPAS Application UNIQUE GENERATE"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS Application UNIQUE GENERATE
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>

        public List<BPASApplicationunique> BPASApplicationUniqueKey(BPASPushData objDATA)
        {
            BPASApplicationunique objResponse = new BPASApplicationunique();
            List<BPASApplicationunique> lstResponse = new List<BPASApplicationunique>();
            try
            {
                object[] objArray = new object[] { "P_vch_Action", objDATA.strAction,
                                                   "P_vch_UserID",objDATA.strUniqueID,
                                                   "P_SERVICEID",objDATA.intServiceid,
                                                   "P_VCH_USERNAME",objDATA.strUserName
                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_BPAS", out param, objArray).ToString();
                if (param.ToString() !="")
                {
                    objResponse.strUniqueID = param.ToString();
                }
                else
                {
                    objResponse.strUniqueID = "";
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

        #region "BPAS Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS Status Update
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<BPASPushDataStatus> BPASStatusUpdate(BPASApplicationStatus objUser)
        {
            BPASPushDataStatus objResponse = new BPASPushDataStatus();
            List<BPASPushDataStatus> lstResponse = new List<BPASPushDataStatus>();
            try
            {
                object[] objArray = new object[] { "P_vch_Action", objUser.strAction,
                                                   "P_vch_UserID",objUser.strUniqueID,
                                                   "P_SERVICEID",objUser.intServiceid,
                                                   "P_NUM_PAYMENT_AMOUNT",objUser.decpaymentamount,

                 };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_SERVICE_BPAS", out param, objArray).ToString();
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