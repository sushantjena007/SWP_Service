#region
//******************************************************************************************************************
// File Name             :   PollutionControl/IPollutionControlDAL.cs
// Description           :   Call different services for different methods for Integration of Pollution Control
// Created by            :   Pranay Kumar
// Created on            :   08-Sept-2017
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
/// Summary description for IPollutionControlDAL
/// </summary>
namespace SWP_Services.DAL
{
    public interface IPollutionControlDAL
    {
        #region "Fetch User Profile Details For Establish Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<PollutionControlUserProfile> GetUserProfilesEUW(PollutionAuthStatus objUser);
        #endregion
        #region "Push User Data For Establish Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Establish Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        List<PollutionPushDataStatus> SWPPushDataEUWater(PollutionPushData objDATA);
        #endregion

        #region "Fetch User Profile Details For Establish Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Air Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<PollutionControlUserProfile> GetUserProfilesEUA(PollutionAuthStatus objUser);
        #endregion
        #region "Push User Data For Establish Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Establish Under Air Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        List<PollutionPushDataStatus> SWPPushDataEUAir(PollutionPushData objDATA);
        #endregion

        #region "Fetch User Profile Details For Operate Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Operate Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<PollutionControlUserProfile> GetUserProfilesOUW(PollutionAuthStatus objUser);
        #endregion
        #region "Push User Data For Operate Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Operate Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        List<PollutionPushDataStatus> SWPPushDataOUWater(PollutionPushData objDATA);
        #endregion

        #region "Fetch User Profile Details For Operate Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Operate Under Air Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<PollutionControlUserProfile> GetUserProfilesOUA(PollutionAuthStatus objUser);
        #endregion
        #region "Push User Data For Operate Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Operate Under Air Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        List<PollutionPushDataStatus> SWPPushDataOUAir(PollutionPushData objDATA);
        #endregion

        #region "Fetch User Profile Details For Hazardous Waste Rules"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Hazardous Waste Rules
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<PollutionControlUserProfile> GetUserProfilesHW(PollutionAuthStatus objUser);
        #endregion
        #region "Push User Data For Hazardous Waste Rules"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Hazardous Waste Rules
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        List<PollutionPushDataStatus> SWPPushDataHWaste(PollutionPushData objDATA);
        #endregion

        #region  "Fetch User Profile Details For Establish Under Both Water & Air Act"
        List<PollutionControlUserProfile> GetUserProfilesEBWA(PollutionAuthStatus objUser);
        #endregion
        #region "Push User Data For Establish Under Water Act & Air Act"
        List<PollutionPushDataStatus> SWPPushDataEBWA(PollutionPushData objDATA);
        #endregion

        #region  "Fetch User Profile Details For Operate Under Both Water & Air Act"
        List<PollutionControlUserProfile> GetUserProfilesOBWA(PollutionAuthStatus objUser);
        #endregion
        #region "Push User Data For Operate Under Water Act & Air Act"
        List<PollutionPushDataStatus> SWPPushDataOBWA(PollutionPushData objDATA);
        #endregion

        #region  "Fetch User Profile Details For e-Waste Management"
        List<PollutionControlUserProfile> GetUserProfilesWM(PollutionAuthStatus objUser);
        #endregion
        #region "Push User Data For e-Waste Management"
        List<PollutionPushDataStatus> SWPPushDataWM(PollutionPushData objDATA);
        #endregion

        #region  "Fetch User Profile Details For Plastic Waste Management"
        List<PollutionControlUserProfile> GetUserProfilesPM(PollutionAuthStatus objUser);
        #endregion
        #region "Push User Data For Plastic Waste Management"
        List<PollutionPushDataStatus> SWPPushDataPM(PollutionPushData objDATA);
        #endregion
    }
}