using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SWP_Services.DAL.Data;

/// <summary>
/// Summary description for DrugLicenseDAL
/// </summary>

namespace SWP_Services.DAL
{
    public class DrugLicenseDAL : IDrugLicenseDAL
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;
        string RetValue;
        object param = new object();

        public List<DrugLicenseUserProfile> GettRetailUserProfileDetails(AuthStatus objUser)
        {
            SqlDataReader reader;
            List<DrugLicenseUserProfile> list = new List<DrugLicenseUserProfile>();
            object[] arr = new object[] {    "P_Action",objUser.Action,
                                             "P_UserID",objUser.UserID
                                        };
            try
            {
                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_DRUG_LICENSE", arr);
                list = reader.DataReaderMapToList<DrugLicenseUserProfile>(MappingDirection.Auto);
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

        public List<RetailPushDataStatus> SWPPushDataReatail(RetailPushData objDATA)
        {
            RetailPushDataStatus objResponse = new RetailPushDataStatus();
            List<RetailPushDataStatus> lstResponse = new List<RetailPushDataStatus>();
            DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails objUser = new DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails();
            try
            {
                object[] objArray = new object[] { "P_Action", objDATA.Action,
                                                   "P_ProposalID",objDATA.ProposalID,
                                                   "P_VCH_INVESTOR_NAME",objDATA.InvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.ApplicationNumber,
                                                   "P_SERVICEID",objDATA.ServiceID,
                                                   "P_INT_STATUS",objDATA.ApplicationStatus,
                                                   "P_INT_PAYMENT_STATUS",objDATA.PaymentStatus,
                                                   "P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO",objDATA.PaymentTransactionID,
                                                   "P_NUM_PAYMENT_AMOUNT", objDATA.PaymentAmount,
                                                   "P_VCH_CERTIFICATE_FILENAME",objDATA.CertificateName,
                                                   "P_VCH_REFERENCE_DOC_NAME",objDATA.ReferenceDocName,
                                                   "P_VCH_REMARK",objDATA.Remark,
                                                   "P_INT_ESCALATION_ID",objDATA.EscalationID,
                                                   "P_VCH_ULB_CODE",objDATA.ULBCode,
                                                   "P_INT_CREATEDBY",objDATA.UserID                   
                                                };

                RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_DRUG_LICENSE", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.Status = 1;
                    objResponse.StatusMsg = "Success";
                }
                else
                {
                    objResponse.Status = 0;
                    objResponse.StatusMsg = "Fail";
                }
                lstResponse.Add(objResponse);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return lstResponse;
        }
    }
}