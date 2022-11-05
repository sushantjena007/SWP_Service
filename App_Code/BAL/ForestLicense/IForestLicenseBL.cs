#region
//******************************************************************************************************************
// File Name             :   ForestLicense/IForestLicenseBL.cs
// Description           :   Call different services and service contract for different methods for Integration of Forest Department
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
using System.ServiceModel;
using SWP_Services.DAL;

/// <summary>
/// Summary description for IForestLicenseBL
/// </summary>
namespace SWP_Services.BL
{
    [ServiceContract]
    public interface IForestLicenseBL
    {
        #region "Fetch User Profile Details For Tree Felling"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details For Tree Felling
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [OperationContract]
        List<ForestLicenseUserProfile> GetUserProfilesTF(ForestAuthStatus objUser);
        #endregion
        #region "Push User Data For Tree Felling"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Tree Felling
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [OperationContract]
        List<ForestPushDataStatus> SWPPushDataTreeF(ForestPushData objDATA);
        #endregion
        #region "Fetch User Profile Details for Tree Transit"
        /// <summary>
        /// Created By Pranay Kumar on 06-Sept-2017 for Fetch User Profile Details for Tree Transit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [OperationContract]
        List<ForestLicenseUserProfile> GetUserProfilesTT(ForestAuthStatus objUser);
        #endregion
        #region "Push User Data For Tree Transit"
        /// <summary>
        /// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Tree Transit
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [OperationContract]
        List<ForestPushDataStatus> SWPPushDataTreeTransit(ForestPushData objDATA);
        #endregion
        #region "Fetch User Profile Details for Felling Tree"
        /// <summary>
        /// Created By Pranay Kumar on 06-Sept-2017 for Fetch User Profile Details for Felling Tree
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [OperationContract]
        List<ForestLicenseUserProfile> GetUserProfilesFellT(ForestAuthStatus objUser);
        #endregion
        #region "Push User Data For Felling Tree"
        /// <summary>
        /// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Felling Tree
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [OperationContract]
        List<ForestPushDataStatus> SWPPushDataFellT(ForestPushData objDATA);
        #endregion
    }
}