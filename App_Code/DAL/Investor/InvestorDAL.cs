using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntityLayer.Investor;
using SWP_Services.DAL.Data;
using System.Data;

/// <summary>
/// Summary description for InvestorDAL
/// </summary>
namespace DataAcessLayer.InvestorDAL
{
    public class InvestorDAL : IinvestorDAL
    {
        string Str_RetValue = "";
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;
        object param = new object();
        public List<InvestorPushDataStatus> SWPPushInvestorData(Investor objDATA)
        {
            InvestorPushDataStatus objResponse = new InvestorPushDataStatus();
            List<InvestorPushDataStatus> lstResponse = new List<InvestorPushDataStatus>();
            try
            {
                object[] objArray = new object[] { "@PvchAction", "A",
                                                   "@PIndustryName",objDATA.IndustryName,
                                                   "@PEmail",objDATA.Email,
                                                   "@PContactPersonName",objDATA.ContactPersonName,
                                                   "@POfficeMobileNo",objDATA.OfficeMobileNo,
                                                   "@PAddress",objDATA.Address,
                                                   "@PPAN",objDATA.PAN,
                                                   "@PUniqueId",objDATA.UniqueId,
                                                   "@PUserId",objDATA.UserId,
                                                   "@PSiteLocationAddress",objDATA.SiteLocation,
                                                   "@PindustryCode", objDATA.IndustryCode,
                                                   "@PPassword", objDATA.Password
                                               
                 };
                Str_RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_INVESTOR_INTEGRATION_UPDTAE", out param, objArray).ToString();
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