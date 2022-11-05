using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWP_Services.DAL;
using System.ServiceModel.Web;

/// <summary>
/// Summary description for DrugLicenseBL
/// </summary>

namespace SWP_Services.BL
{
    public class DrugLicenseBL : IDrugLicenseBL
    {
        DrugLicenseDAL obj = new DrugLicenseDAL();
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesRetail")]
        public List<DrugLicenseUserProfile> GettRetailUserProfileDetails(AuthStatus objUser)
        {
            return obj.GettRetailUserProfileDetails(objUser);
        }
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataRetail")]
        public List<RetailPushDataStatus> SWPPushDataReatails(RetailPushData objDATA)
        {
            return obj.SWPPushDataReatail(objDATA);
        }
  
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesWholesale")]
        public List<DrugLicenseUserProfile> GettWholeSaleUserProfileDetails(AuthStatus objUser)
        {
            return obj.GettRetailUserProfileDetails(objUser);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataWholesale")]
        public List<RetailPushDataStatus> SWPPushDataWholeSales(RetailPushData objDATA)
        {
            return obj.SWPPushDataReatail(objDATA);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesManufactur")]
        public List<DrugLicenseUserProfile> GettManufactureUserProfileDetails(AuthStatus objUser)
        {
            return obj.GettRetailUserProfileDetails(objUser);
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataManufactur")]
        public List<RetailPushDataStatus> SWPPushDataManufactures(RetailPushData objDATA)
        {
            return obj.SWPPushDataReatail(objDATA);
        }

    }
}