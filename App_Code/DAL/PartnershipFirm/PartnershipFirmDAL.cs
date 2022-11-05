using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntityLayer.PartnershipFirmEntity;
using SWP_Services.DAL.Data;

using System.Data;

/// <summary>
/// Summary description for PartnershipFirmDAL
/// </summary>

namespace DataAcessLayer.PartnershipFirmDAL
{

    public class PartnershipFirmDAL : IPartnershipFirmDAL
    {
        string Str_RetValue = "";
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;
        object param = new object();

        public List<PartnershipFirmUserProfile> ViewInvestorDetails(EntityLayer.PartnershipFirmEntity.AuthStatus objAuthStatus)
        {
            SqlDataReader reader;
            List<PartnershipFirmUserProfile> list = new List<PartnershipFirmUserProfile>();
            object[] arr = new object[] {    "P_Action",objAuthStatus.Action,
                                             "P_UserID",objAuthStatus.UserID
                                        };
            try
            {

                reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "Usp_GetUserProfilePF", arr);

                list = reader.DataReaderMapToList<PartnershipFirmUserProfile>(MappingDirection.Auto);


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

        public List<PartnershipFirmPushDataStatus> SWPPushDataPartnershipFirm(PartnershipFirmPushData objDATA)
        {
            PartnershipFirmPushDataStatus objResponse = new PartnershipFirmPushDataStatus();
            List<PartnershipFirmPushDataStatus> lstResponse = new List<PartnershipFirmPushDataStatus>();
            DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails objUser = new DataAcessLayer.SWPIntegrationDAL.DALApplicationDetails();
            try
            {
                object[] objArray = new object[] { "P_Action", objDATA.Action,
                                                   "P_ProposalID",objDATA.IndustryCode,
                                                   "P_VCH_INVESTOR_NAME",objDATA.InvstorName,
                                                   "P_VCH_APPLICATION_UNQ_KEY",objDATA.ApplicationNumber,
                                                   "P_SERVICEID",objDATA.ServiceID,
                                                   "P_INT_STATUS",objDATA.ApplicationStatus,
                                                   "P_INT_ACTION_TAKEN_BY",objDATA.ActionTakenBy,
                                                   "P_INT_ACTION_TOBE_TAKEN_BY",objDATA.ActionToBeTakenBy,
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

                Str_RetValue = SqlHelper.ExecuteNonQuery(connectionString, "Usp_GetUserProfilePF", out param, objArray).ToString();
                if (param.ToString() == "1")
                {
                    objResponse.Status = 1;
                    objResponse.StatusMsg = "Sucess";
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