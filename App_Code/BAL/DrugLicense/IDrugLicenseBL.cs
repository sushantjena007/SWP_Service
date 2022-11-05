using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using SWP_Services.DAL;


/// <summary>
/// Summary description for IDrugLicenseBL
/// </summary>
/// 

namespace SWP_Services.BL
{
    [ServiceContract]
    public interface IDrugLicenseBL
    {
        [OperationContract]
        List<DrugLicenseUserProfile> GettRetailUserProfileDetails(AuthStatus objUser);

        [OperationContract]
        List<RetailPushDataStatus> SWPPushDataReatails(RetailPushData objDATA);

        [OperationContract]
        List<DrugLicenseUserProfile> GettWholeSaleUserProfileDetails(AuthStatus objUser);

        [OperationContract]
        List<RetailPushDataStatus> SWPPushDataWholeSales(RetailPushData objDATA);

        [OperationContract]
        List<DrugLicenseUserProfile> GettManufactureUserProfileDetails(AuthStatus objUser);

        [OperationContract]
        List<RetailPushDataStatus> SWPPushDataManufactures(RetailPushData objDATA);
    }
}