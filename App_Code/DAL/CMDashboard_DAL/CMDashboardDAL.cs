using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntityLayer.CMDashboard;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using SWP_Services.DAL.Data;
using System.Globalization;
using System.Text.RegularExpressions;



/// <summary>
/// Summary description for CMDashboardDAL
/// </summary>
namespace DataAcessLayer.CMDashboardDAL
{
    public class CMDashboardDAL : ICMDashboardDAL
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString;

        string strCMdashboardSecurityKey = System.Configuration.ConfigurationManager.AppSettings["CMDashboardSecurityKey"].ToString();

        string RetValue;
        object param = new object();

        #region  "Get Year WiseCompany Registration Count Report"
        /// <summary>
        /// Created By Debiprasanna on 25-Oct-2022 for Get Year Wise Company Registration Count Report
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<clsOutput1> GetYearWiseCompanyRegdReport(CMDashboardEntity objUser)
        {
            SqlDataReader reader;
            List<clsOutput1> list = new List<clsOutput1>();
            object[] arr = new object[] {  "@P_VCH_ACTION_CODE","YWCRR",
                                           "@P_INT_DISTRICT_ID",objUser.DistrictId,
                                           "@P_VCH_FROM_DATE",Convert.ToString(objUser.FromDate),
                                           "@P_VCH_TO_DATE",Convert.ToString(objUser.ToDate)
                                        };
            try
            {
                /*--------------------------------------------------------------------*/
                ///Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;
                DateTime fDate;
                DateTime tDate;

                if (objUser.SecurityKey.Trim() != strCMdashboardSecurityKey)
                {
                    clsOutput1 objent = new clsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid SecurityKey";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.FromDate == "")
                {
                    clsOutput1 objent = new clsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "From date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.ToDate == "")
                {
                    clsOutput1 objent = new clsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "To date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.FromDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate) == false)
                {
                    clsOutput1 objent = new clsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid date from date";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.ToDate, "dd-MMM-yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out tDate)==false)
                {
                    clsOutput1 objent = new clsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid date to date";
                    list.Add(objent);
                    intValid = 1;
                } 
                else if (Convert.ToDateTime(objUser.FromDate) > Convert.ToDateTime(objUser.ToDate))
                {
                    clsOutput1 objent = new clsOutput1();
                    objent.Status = 1;
                    objent.OutMessage = "From date cannot be greater than to date.";
                    list.Add(objent);
                    intValid = 1;
                }

                ///// Write Request log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();

                var json = jsonSerialiser.Serialize(objUser);
                string strOutput = "(Request)---Inputdata:- " + json;

                ///// Write request log for each input .

                Util.LogRequestResponse("CMDashboard", "InputRecord :-", "Input :" + strOutput);

                if (intValid == 0)
                {
                    reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_CM_DASHBOARD_API", arr);
                    clsOutput1 objent1 = new clsOutput1();
                    objent1.Status = 0;
                    objent1.OutMessage = "Success";
                    objent1.YearWiseCompanyRegistered = reader.DataReaderMapToList<YearWiseCompanyRegistered>(MappingDirection.Auto);
                    list.Add(objent1);

                }

                ///// Write response log for each request.
                string strserialize = JsonConvert.SerializeObject(list);
                Util.LogRequestResponse("CMDashboard", "OutputRecord :-", strserialize);
            }
            catch (Exception ex)
            {
                Util.LogError(ex, "CMDashboard");
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion

        #region  "Get Total No. Of Companies Registration Count Report"
        /// <summary>
        /// Created By Debiprasanna on 25-Oct-2022 for Get Total No. Of Companies Registration Count Report
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<clsOutput2> GetTotalNoOfCompaniesRegd(CMDashboardEntity objUser)
        {
            SqlDataReader reader;
            List<clsOutput2> list = new List<clsOutput2>();
            object[] arr = new object[] {  "@P_VCH_ACTION_CODE","TNCRR",
                                           "@P_INT_DISTRICT_ID",objUser.DistrictId,
                                           "@P_VCH_FROM_DATE",Convert.ToString(objUser.FromDate),
                                           "@P_VCH_TO_DATE",Convert.ToString(objUser.ToDate)
                                        };
            try
            {

                /*--------------------------------------------------------------------*/
                ///Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;
                DateTime fDate;
                DateTime tDate;

                if (objUser.SecurityKey.Trim() != strCMdashboardSecurityKey)
                {
                    clsOutput2 objent = new clsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid SecurityKey";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.FromDate == "")
                {
                    clsOutput2 objent = new clsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = " Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.ToDate == "")
                {
                    clsOutput2 objent = new clsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = " Date Should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.FromDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate) == false)
                {
                    clsOutput2 objent = new clsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid date from date";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.ToDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tDate) == false)
                {
                    clsOutput2 objent = new clsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid date to date";
                    list.Add(objent);
                    intValid = 1;

                }
                else if (Convert.ToDateTime(objUser.FromDate) > Convert.ToDateTime(objUser.ToDate))
                {
                    clsOutput2 objent = new clsOutput2();
                    objent.Status = 1;
                    objent.OutMessage = "From date cannot be greater than to date.";
                    list.Add(objent);
                    intValid = 1;
                }


                ///// Write Request log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objUser);
                string strOutput = "(Request)---Inputdata:- " + json;

                ///// Write request log for each input .

                Util.LogRequestResponse("CMDashboard", "InputRecord :-", "Input :" + strOutput);

                if (intValid == 0)
                {
                    reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_CM_DASHBOARD_API", arr);
                    clsOutput2 objent2 = new clsOutput2();
                    objent2.Status = 0;
                    objent2.OutMessage = "Success";
                    objent2.TotalNoOfCompaniesRegistered = reader.DataReaderMapToList<TotalNoOfCompaniesRegistered>(MappingDirection.Auto);
                    list.Add(objent2);

                }

                ///// Write response log for each request.
                string strserialize = JsonConvert.SerializeObject(list);
                Util.LogRequestResponse("CMDashboard", "OutputRecord :-", strserialize);
            }
            catch (Exception ex)
            {

                Util.LogError(ex, "CMDashboard");
            }

            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion

        #region  "Get Sector Wise No. Of  Companies Registration Count Report"
        /// <summary>
        /// Created By Debiprasanna on 25-Oct-2022 for Get Sector Wise No. Of  Companies Registration Count Report
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<clsOutput3> GetSectorWiseNoOfCompany(CMDashboardEntity objUser)
        {
            SqlDataReader reader;
            List<clsOutput3> list = new List<clsOutput3>();
            object[] arr = new object[] {  "@P_VCH_ACTION_CODE","SWNCR",
                                           "@P_INT_DISTRICT_ID",objUser.DistrictId,
                                           "@P_VCH_FROM_DATE",Convert.ToString(objUser.FromDate),
                                           "@P_VCH_TO_DATE",Convert.ToString(objUser.ToDate)
                                        };
            try
            {
                /*--------------------------------------------------------------------*/
                ///Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                DateTime fDate;
                DateTime tDate;

                if (objUser.SecurityKey.Trim() != strCMdashboardSecurityKey)
                {
                    clsOutput3 objent = new clsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid SecurityKey";
                    list.Add(objent);
                    intValid = 1;

                }
                else if (objUser.FromDate == "")
                {
                    clsOutput3 objent = new clsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = " Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (objUser.ToDate == "")
                {
                    clsOutput3 objent = new clsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = " Date should not be blank";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.FromDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate) == false)
                {
                    clsOutput3 objent = new clsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid date from date";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (DateTime.TryParseExact(objUser.ToDate, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tDate) == false)
                {
                    clsOutput3 objent = new clsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = "Invalid date to date";
                    list.Add(objent);
                    intValid = 1;
                }
                else if (Convert.ToDateTime(objUser.FromDate) > Convert.ToDateTime(objUser.ToDate))
                {
                    clsOutput3 objent = new clsOutput3();
                    objent.Status = 1;
                    objent.OutMessage = "From date cannot be greater than to date.";
                    list.Add(objent);
                    intValid = 1;
                }

                ///// Write Request log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objUser);
                string strOutput = "(Request)---Inputdata:- " + json;


                ///// Write request log for each input .
                Util.LogRequestResponse("CMDashboard", "InputRecord :-", "Input :" + strOutput);

                if (intValid == 0)
                {

                    reader = (SqlDataReader)SqlHelper.ExecuteReader(connectionString, "USP_CM_DASHBOARD_API", arr);
                    clsOutput3 objent3 = new clsOutput3();
                    objent3.Status = 0;
                    objent3.OutMessage = "Success";
                    objent3.SectorWiseCompanyRegistered = reader.DataReaderMapToList<SectorWiseCompanyRegistered>(MappingDirection.Auto);
                    list.Add(objent3);

                }

                ///// Write response log for each request.
                string strserialize = JsonConvert.SerializeObject(list);

                Util.LogRequestResponse("CMDashboard", "OutputRecord :-", strserialize);
            }
            catch (Exception ex)
            {
                Util.LogError(ex, "CMDashboard");
            }
            finally
            {
                reader = null;
            }

            return list;

        }
        #endregion
    }
}