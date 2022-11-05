using System;
using System.Configuration;
using EntityLayer.AIMEntity;
using System.Web.Script.Serialization;
using SWP_Services.DAL.Data;
using DWHServiceReference;

/// <summary>
/// Summary description for AIMDAL
/// </summary>

namespace DataAcessLayer.AIMDAL
{
    public class AIMDAL : IAIMDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString();
        string strAIMSecurityKey = ConfigurationManager.AppSettings["AIMSecurityKey"].ToString();
        object param = new object();

        /// <summary>
        /// Method to Update EIN/PC details obtained from AIM
        /// Added by Sushant Jena on Dt:16-Sep-2019.
        /// This method is only useful for MSME units
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public AIMStatusResponse UpdateEinPc(AIMEntity objDATA)
        {
            AIMStatusResponse objResStatus = new AIMStatusResponse();
            try
            {
                ///// Write request log for each request.
                string strInput = "(Request)---Unique ID :- " + objDATA.strUniqueId.Trim() + " Security Key:- " + objDATA.strSecurityKey.Trim();
                Util.LogRequestResponse("AIM", "UpdateEinPc", strInput);

                /*--------------------------------------------------------------------*/
                ////// Validation Section
                /*--------------------------------------------------------------------*/
                int intValid = 0;

                #region Validation

                if (objDATA.strUniqueId.Trim() == "")
                {
                    objResStatus.intStatus = 1;
                    objResStatus.strStatusMsg = "Unique id should not be blank.";
                    intValid = 1;
                }
                else if (objDATA.strSecurityKey.Trim() != strAIMSecurityKey)
                {
                    objResStatus.intStatus = 2;
                    objResStatus.strStatusMsg = "Invalid Security Key.";
                    intValid = 1;
                }
                else if (objDATA.strEinPcNo.Trim() == "")
                {
                    objResStatus.intStatus = 1;
                    objResStatus.strStatusMsg = "EIN/PC number should not be blank.";
                    intValid = 1;
                }
                else if (objDATA.strEinPcType.Trim() == "")
                {
                    objResStatus.intStatus = 1;
                    objResStatus.strStatusMsg = "EIN/PC type should not be blank.";
                    intValid = 1;
                }
                else if (objDATA.strEinPcType.Trim() != "EIN" && objDATA.strEinPcType.Trim() != "PC")
                {
                    objResStatus.intStatus = 1;
                    objResStatus.strStatusMsg = "EIN/PC type name is not correct.";
                    intValid = 1;
                }
                //else if (objDATA.strEinPcDoc.Trim() == "")
                //{
                //    objResStatus.intStatus = 1;
                //    objResStatus.strStatusMsg = "EIN/PC document file should not be blank.";
                //    intValid = 1;
                //}

                #endregion

                /*--------------------------------------------------------------------*/

                if (intValid == 0)
                {
                    object[] objArray = new object[] {
                                                        "@P_VCH_ACTION", "UE",
                                                        "@P_VCH_UNIQUE_ID",objDATA.strUniqueId,
                                                        "@P_VCH_EIN_IEM",objDATA.strEinPcNo,
                                                        "@P_VCH_LICENCE_NO_TYPE",objDATA.strEinPcType
                                                     };

                    string Str_RetValue = SqlHelper.ExecuteNonQuery(connectionString, "USP_CHECK_PAN_EXIST", out param, objArray).ToString();
                    if (param.ToString() == "5")
                    {
                        objResStatus.intStatus = 5;
                        objResStatus.strStatusMsg = "Invalid Unique Id.";
                    }
                    else if (param.ToString() == "6")
                    {
                        objResStatus.intStatus = 6;
                        objResStatus.strStatusMsg = "This unit has already EIN/PC.";
                    }
                    else if (param.ToString() == "9")
                    {
                        objResStatus.intStatus = 9;
                        objResStatus.strStatusMsg = "Duplicate EIN/PC Number.";
                    }
                    else if (param.ToString() == "7")
                    {
                        objResStatus.intStatus = 7;
                        objResStatus.strStatusMsg = "Success.";

                        /*-----------------------------------------------------------------*/
                        ///// Insertion Process for DWH
                        /*-----------------------------------------------------------------*/
                        /////// Service Initialization (Push data to Data Warehouse)                         
                        DWHServiceHostClient objSrvRef = new DWHServiceHostClient();
                        EINModel objEnt = new EINModel
                        {
                            ///// Assign value to property  
                            ///// intRequestType = 2 Means it will only update document Name
                            ///// intRequestType = 1 Means it will only update EIN No and EIN Type
                            intRequestType = 1,
                            strLicenseNumber = objDATA.strEinPcNo,
                            strLicenseType = objDATA.strEinPcType,
                            strUniqueId = objDATA.strUniqueId
                        };

                        /////// Generate Encryption Key (Security key to access Data Warehouse service methods)
                        string strEncryptionKey = ConfigurationManager.AppSettings["DWHEncryptionKey"];
                        string strSecurityKey = objSrvRef.KeyEncryption(strEncryptionKey);

                        /////// DML Opertion (To Data Warehouse)
                        string strReturnVal = objSrvRef.EinUpdate(objEnt, strSecurityKey);
                    }
                    else if (param.ToString() == "8")
                    {
                        objResStatus.intStatus = 8;
                        objResStatus.strStatusMsg = "Error Occured.";
                    }
                    else
                    {
                        objResStatus.intStatus = 0;
                        objResStatus.strStatusMsg = param.ToString();
                    }
                }

                /*-----------------------------------------------------------*/
                ///// Write response log for each request.
                JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(objResStatus);
                string strOutput = "(Response)--- Status :- " + intValid.ToString() + " OutputString:- " + json;
                Util.LogRequestResponse("AIM", "UpdateEinPc", strOutput);
                /*-----------------------------------------------------------*/
            }
            catch (Exception ex)
            {
                objResStatus.intStatus = 10;
                objResStatus.strStatusMsg = "Exception Occured.";

                Util.LogError(ex, "AIM");
            }

            return objResStatus;
        }
    }
}