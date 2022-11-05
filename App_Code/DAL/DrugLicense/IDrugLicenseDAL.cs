using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IDrugLicenseDAL
/// </summary>
/// 

namespace SWP_Services.DAL
{
    public interface IDrugLicenseDAL
    {
        List<DrugLicenseUserProfile> GettRetailUserProfileDetails(AuthStatus objUser);
        List<RetailPushDataStatus> SWPPushDataReatail(RetailPushData objDATA);
    }
}