using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer.CMDashboard;

/// <summary>
/// Summary description for ICMDashboardDAL
/// </summary>
namespace DataAcessLayer.CMDashboardDAL
{
    public interface ICMDashboardDAL
    {
        #region  "Get Year WiseCompany Registration Count Report"

        List<clsOutput1> GetYearWiseCompanyRegdReport(CMDashboardEntity objUser);

        #endregion

        #region  "Get Total No. Of Companies Registration Count Report"

        List<clsOutput2> GetTotalNoOfCompaniesRegd(CMDashboardEntity objUser);

        #endregion

        #region  "Get Sector Wise No. Of  Companies Registration Count Report"

        List<clsOutput3> GetSectorWiseNoOfCompany(CMDashboardEntity objUser);

        #endregion
    }
}