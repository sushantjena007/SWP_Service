#region
//******************************************************************************************************************
// File Name             :   PollutionControl/PollutionControlBL.cs
// Description           :   Call different services and service contract for different methods for Integration of Pollution Control
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
using SWP_Services.DAL;
using System.ServiceModel.Web;

/// <summary>
/// Summary description for PollutionControlBL
/// </summary>
namespace SWP_Services.BL
{
    public class PollutionControlBL : IPollutionControlBL
    {
        PollutionControlDAL obj = new PollutionControlDAL();

        #region "Fetch User Profile Details For Establish Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesEUW")]
        public List<PollutionControlUserProfile> GetUserProfilesEUW(PollutionAuthStatus objUser)
        {
            return obj.GetUserProfilesEUW(objUser);
        }
        #endregion
        #region "Push User Data For Establish Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Establish Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataEUW")]
        public List<PollutionPushDataStatus> SWPPushDataEUWater(PollutionPushData objDATA)
        {
            return obj.SWPPushDataEUWater(objDATA);
        }
        #endregion

        #region "Fetch User Profile Details For Establish Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Air Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesEUA")]
        public List<PollutionControlUserProfile> GetUserProfilesEUA(PollutionAuthStatus objUser)
        {
            return obj.GetUserProfilesEUA(objUser);
        }
        #endregion
        #region "Push User Data For Establish Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Establish Under Air Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataEUA")]
        public List<PollutionPushDataStatus> SWPPushDataEUAir(PollutionPushData objDATA)
        {
            return obj.SWPPushDataEUAir(objDATA);
        }
        #endregion

        #region "Fetch User Profile Details For Operate Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Operate Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesOUW")]
        public List<PollutionControlUserProfile> GetUserProfilesOUW(PollutionAuthStatus objUser)
        {
            return obj.GetUserProfilesOUW(objUser);
        }
        #endregion
        #region "Push User Data For Operate Under Water Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Operate Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataOUW")]
        public List<PollutionPushDataStatus> SWPPushDataOUWater(PollutionPushData objDATA)
        {
            return obj.SWPPushDataOUWater(objDATA);
        }
        #endregion

        #region "Fetch User Profile Details For Operate Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Operate Under Air Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesOUA")]
        public List<PollutionControlUserProfile> GetUserProfilesOUA(PollutionAuthStatus objUser)
        {
            return obj.GetUserProfilesOUA(objUser);
        }
        #endregion
        #region "Push User Data For Operate Under Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Operate Under Air Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataOUA")]
        public List<PollutionPushDataStatus> SWPPushDataOUAir(PollutionPushData objDATA)
        {
            return obj.SWPPushDataOUAir(objDATA);
        }
        #endregion

        #region "Fetch User Profile Details For Hazardous Waste Rules"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Hazardous Waste Rules
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesHW")]
        public List<PollutionControlUserProfile> GetUserProfilesHW(PollutionAuthStatus objUser)
        {
            return obj.GetUserProfilesHW(objUser);
        }
        #endregion
        #region "Push User Data For Hazardous Waste Rules"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Push User Data For Hazardous Waste Rules
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataHW")]
        public List<PollutionPushDataStatus> SWPPushDataHWaste(PollutionPushData objDATA)
        {
            return obj.SWPPushDataHWaste(objDATA);
        }
        #endregion

        #region "Fetch User Profile Details For Establish Under Both Water & Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesEBWA")]
        public List<PollutionControlUserProfile> GetUserProfilesEBWA(PollutionAuthStatus objUser)
        {
            return obj.GetUserProfilesEBWA(objUser);
        }
        #endregion
        #region "Push User Data For Establish Under Both Water & Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Establish Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataEBWA")]
        public List<PollutionPushDataStatus> SWPPushDataEBWA(PollutionPushData objDATA)
        {
            return obj.SWPPushDataEBWA(objDATA);
        }
        #endregion

        #region "Fetch User Profile Details For Operate Under Both Water & Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 08-Sept-2017 for Fetch User Profile Details For Establish Under Water Act
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesOBWA")]
        public List<PollutionControlUserProfile> GetUserProfilesOBWA(PollutionAuthStatus objUser)
        {
            return obj.GetUserProfilesOBWA(objUser);
        }
        #endregion
        #region "Push User Data For Operate Under Both Water & Air Act"
        /// <summary>
        /// Created By Pranay Kumar on 05-Sept-2017 for Push User Data For Establish Under Water Act
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataOBWA")]
        public List<PollutionPushDataStatus> SWPPushDataOBWA(PollutionPushData objDATA)
        {
            return obj.SWPPushDataOBWA(objDATA);
        }
        #endregion

        #region  "Fetch User Profile Details For e-Waste Management"
        /// <summary>
        /// Created By Bhagyashree Das on 25-Nov-2020 for Fetch User Profile Details For e-Waste Management
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesWM")]
        public List<PollutionControlUserProfile> GetUserProfilesWM(PollutionAuthStatus objUser)
        {
            return obj.GetUserProfilesWM(objUser);
        }
        #endregion
        #region "Push User Data For e-Waste Management"
        /// <summary>
        /// Created By Bhagyashree Das on 25-Nov-2020 for Push User Data For e-Waste Management
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataWM")]
        public List<PollutionPushDataStatus> SWPPushDataWM(PollutionPushData objDATA)
        {
            return obj.SWPPushDataWM(objDATA);
        }
        #endregion

        #region  "Fetch User Profile Details For Plastic Waste Management"
        /// <summary>
        /// Created By Bhagyashree Das on 25-Nov-2020 for Fetch User Profile Details For Plastic Waste Management
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getUserProfilesPM")]
        public List<PollutionControlUserProfile> GetUserProfilesPM(PollutionAuthStatus objUser)
        {
            return obj.GetUserProfilesPM(objUser);
        }
        #endregion
        #region "Push User Data For Plastic Waste Management"
        /// <summary>
        /// Created By Bhagyashree Das on 25-Nov-2020 for Push User Data For Plastic Waste Management
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushDataPM")]
        public List<PollutionPushDataStatus> SWPPushDataPM(PollutionPushData objDATA)
        {
            return obj.SWPPushDataPM(objDATA);
        }
        #endregion
    }
}