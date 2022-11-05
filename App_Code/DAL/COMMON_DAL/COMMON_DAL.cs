using EntityLayer.COMMON_Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for COMMON_DAL
/// </summary>
/// 
namespace DataAcessLayer.COMMON_DAL
{
    public class COMMON_DAL
    {
        string str_Retvalue = "";
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString());
        SqlCommand cmd = new SqlCommand();
        List<ApiReturnMessage> OutPut = new List<ApiReturnMessage>();
        ApiReturnMessage obj = new ApiReturnMessage();
        List<ReturnMessage> OutPut1 = new List<ReturnMessage>();
        ReturnMessage obj1 = new ReturnMessage();

        public COMMON_DAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Application Status Update

        public List<ApiReturnMessage> ApplicationStatusUpdate(List<CommonEntity> objcommon)
        {
            /*--------------------------------------------------------------------*/
            ///Write response log for each request.
            /*--------------------------------------------------------------------*/
            string xmldata = ConvertObjectToXMLString(objcommon);
            Util.LogRequestResponse("Common", "ApplicationStatusUpdate", xmldata);

            /*--------------------------------------------------------------------*/

            conn.Open();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_ApplicationMasterUpdate";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@P_CHAR_ACTION", "U");
                cmd.Parameters.AddWithValue("@XMLDATA", ConvertObjectToXMLString(objcommon));
                cmd.Parameters.AddWithValue("@P_OUT_MSG", SqlDbType.VarChar);

                cmd.Parameters["@P_OUT_MSG"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                str_Retvalue = cmd.Parameters["@P_OUT_MSG"].Value.ToString();

                if (str_Retvalue == "1")
                {
                    obj.status = Convert.ToInt32(1);
                    obj.Response = "SUCCESS";
                    OutPut.Add(obj);
                }
                else if (str_Retvalue == "2")
                {
                    string xmldata2 = ConvertObjectToXMLString(objcommon);
                    Util.LogRequestResponse("Common", "ApplicationStatusUpdate", xmldata2);

                    obj.status = Convert.ToInt32(2);
                    obj.Response = "FAILURE";
                    OutPut.Add(obj);
                }
            }
            catch (Exception ex)
            {
                // obj.status = 0;
                // obj.Response = ex.Message.ToString();
                // OutPut.Add(obj);

                obj.status = 3;
                obj.Response = "Some Error Occured,Please try again.";
                OutPut.Add(obj);

                Util.LogError(ex, "Common");
            }

            return OutPut;
        }
        static string ConvertObjectToXMLString(object classObject)
        {
            string xmlString = null;
            XmlSerializer xmlSerializer = new XmlSerializer(classObject.GetType());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, classObject);
                memoryStream.Position = 0;
                xmlString = new StreamReader(memoryStream).ReadToEnd();
            }
            return xmlString;
        }

        #endregion
    }
}