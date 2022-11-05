#region
//******************************************************************************************************************
// File Name             :   ForestLicense/IForestLicenseDAL.cs
// Description           :   Call different services for different methods for Integration of Forest Department
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

/// <summary>
/// Summary description for IForestLicenseDAL
/// </summary>
namespace SWP_Services.DAL
{
    public interface IForestLicenseDAL
    {
        #region "Fetch User Profile Details For Tree Felling"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details For Tree Felling
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<ForestLicenseUserProfile> GetUserProfilesTF(ForestAuthStatus objUser);
        #endregion
        #region "Push User Data For Tree Felling"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Tree Felling
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        List<ForestPushDataStatus> SWPPushDataTreeF(ForestPushData objDATA);
        #endregion
        #region "Fetch User Profile Details for Tree Transit"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details for Tree Transit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<ForestLicenseUserProfile> GetUserProfilesTT(ForestAuthStatus objUser);
        #endregion
        #region "Push User Data For Tree Transit"
        /// <summary>
        /// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Tree Transit
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        List<ForestPushDataStatus> SWPPushDataTreeTransit(ForestPushData objDATA);
        #endregion
        #region "Fetch User Profile Details for Felling Tree"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Fetch User Profile Details for Tree Transit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<ForestLicenseUserProfile> GetUserProfilesFellT(ForestAuthStatus objUser);
        #endregion
        #region "Push User Data For Felling Tree"
        /// <summary>
        /// Created By Pranay Kumar on 06-Sept-2017 for Push User Data For Felling Tree
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        List<ForestPushDataStatus> SWPPushDataFellT(ForestPushData objDATA);
        #endregion
    }
}