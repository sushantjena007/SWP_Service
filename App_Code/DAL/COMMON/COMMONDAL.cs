using EntityLayer.COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonDAL
/// </summary>
namespace DataAcessLayer.COMMON
{
    public class COMMONDAL
    {
        public COMMONDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        string str_Retvalue = "";       
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString());
        SqlCommand cmd = new SqlCommand();
        List<ApiReturnMessage> OutPut = new List<ApiReturnMessage>();
        ApiReturnMessage obj = new ApiReturnMessage();
        List<ReturnMessage> OutPut1 = new List<ReturnMessage>();
        ReturnMessage obj1 = new ReturnMessage();

        #region PUSH COMMON DATA
        public List<ReturnMessage> PushApplicationData(COMMONEntity objcommon)
        {
            conn.Open();
            cmd = new SqlCommand();            
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_COMMON_Service";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_VCHACTION", "Save");
                cmd.Parameters.AddWithValue("@INT_APPLICATIONID", 0);
                cmd.Parameters.AddWithValue("@INT_DEPARTMENTID", 0);
                cmd.Parameters.AddWithValue("@INT_SERVICEID", objcommon.INT_SERVICEID);
                cmd.Parameters.AddWithValue("@VCH_INVESTORNAME",objcommon.VCH_INVESTORNAME);
                cmd.Parameters.AddWithValue("@VCH_INVESTOREMAIL", objcommon.VCH_INVESTOREMAIL);
                cmd.Parameters.AddWithValue("@VCH_INVESTORPHONE", objcommon.VCH_INVESTORPHONE);
                cmd.Parameters.AddWithValue("@VCH_INVESTORPAN", objcommon.VCH_INVESTORPAN);
                cmd.Parameters.AddWithValue("@VCH_INVESTORUSERID",objcommon.VCH_INVESTORUSERID);
                cmd.Parameters.AddWithValue("@INT_PAYMENTSTATUS", objcommon.INT_PAYMENTSTATUS);
                cmd.Parameters.AddWithValue("@DEC_PAYMENTAMOUNT", objcommon.DEC_PAYMENTAMOUNT);
                cmd.Parameters.AddWithValue("@INT_DEMANDSTATUS", objcommon.INT_DEMANDSTATUS);
                cmd.Parameters.AddWithValue("@DEC_DEMANDAMOUNT", objcommon.DEC_DEMANDAMOUNT);
                cmd.Parameters.AddWithValue("@VCH_CHALLANNO", objcommon.VCH_CHALLANNO);
                cmd.Parameters.AddWithValue("@VCH_BANKTRANID", objcommon.VCH_BANKTRANID);
                cmd.Parameters.AddWithValue("@VCH_REMARK", objcommon.VCH_REMARK);
                cmd.Parameters.AddWithValue("@INT_APPLICATIONSTATUS", objcommon.INT_APPLICATIONSTATUS);
                cmd.Parameters.AddWithValue("@VCH_CERTIFICATE", objcommon.VCH_CERTIFICATE);
                cmd.Parameters.AddWithValue("@P_VCHOUT", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUT"].Direction = ParameterDirection.Output;               
                cmd.ExecuteNonQuery();
                str_Retvalue = cmd.Parameters["@P_VCHOUT"].Value.ToString();             
                obj1.INT_APPLICATIONID =Convert.ToInt32(str_Retvalue);
                obj1.Response ="SUCCESS" ;
                OutPut1.Add(obj1);              
            }
            catch (Exception ex)
            {
                obj1.INT_APPLICATIONID = 0;
                obj1.Response = ex.Message.ToString();
                OutPut1.Add(obj1);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                str_Retvalue = string.Empty;               
            }
            return OutPut1;
        }
        #endregion
        #region UPDATE PAYMENT STATUS
        public List<ApiReturnMessage> PayMentStatusUpdate(COMMONEntity objcommon)
        {
            conn.Open();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_COMMON_Service";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_VCHACTION", "PMU");
                cmd.Parameters.AddWithValue("@INT_APPLICATIONID", objcommon.INT_APPLICATIONID);
                cmd.Parameters.AddWithValue("@VCH_CHALLANNO", objcommon.VCH_CHALLANNO);
                cmd.Parameters.AddWithValue("@VCH_BANKTRANID", objcommon.VCH_BANKTRANID);
                cmd.Parameters.AddWithValue("@INT_PAYMENTSTATUS", objcommon.INT_PAYMENTSTATUS);                             
                cmd.Parameters.AddWithValue("@P_VCHOUT", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUT"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                str_Retvalue = cmd.Parameters["@P_VCHOUT"].Value.ToString();
                obj.status = 1;
                obj.Response = "SUCCESS";
                OutPut.Add(obj);
            }
            catch (Exception ex)
            {
                obj.status = 0;
                obj.Response = ex.Message.ToString();
                OutPut.Add(obj);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                str_Retvalue = string.Empty;
            }
            return OutPut;
        }
        #endregion
        #region DEMAND PAYMENT STATUS
        public List<ApiReturnMessage> DemandStatusUpdate(COMMONEntity objcommon)
        {
            conn.Open();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_COMMON_Service";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_VCHACTION", "DMU");
                cmd.Parameters.AddWithValue("@INT_APPLICATIONID", objcommon.INT_APPLICATIONID);
                cmd.Parameters.AddWithValue("@VCH_CHALLANNO", objcommon.VCH_CHALLANNO);
                cmd.Parameters.AddWithValue("@VCH_BANKTRANID", objcommon.VCH_BANKTRANID);
                cmd.Parameters.AddWithValue("@INT_DEMANDSTATUS", objcommon.INT_DEMANDSTATUS);                               
                cmd.Parameters.AddWithValue("@P_VCHOUT", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUT"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                str_Retvalue = cmd.Parameters["@P_VCHOUT"].Value.ToString();
                obj.status = Convert.ToInt32(1);
                obj.Response = "SUCCESS";
                OutPut.Add(obj);
            }
            catch (Exception ex)
            {
                obj.status = 0;
                obj.Response = ex.Message.ToString();
                OutPut.Add(obj);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                str_Retvalue = string.Empty;
            }
            return OutPut;
        }
        #endregion
        #region Application Status Update
        public List<ApiReturnMessage> ApplicationStatusUpdate(COMMONEntity objcommon)
        {
            conn.Open();
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_COMMON_Service";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_VCHACTION", "APU");
                cmd.Parameters.AddWithValue("@INT_APPLICATIONID", objcommon.INT_APPLICATIONID);               
                cmd.Parameters.AddWithValue("@VCH_REMARK", objcommon.VCH_REMARK);
                cmd.Parameters.AddWithValue("@INT_APPLICATIONSTATUS", objcommon.INT_APPLICATIONSTATUS);
                cmd.Parameters.AddWithValue("@VCH_CERTIFICATE", objcommon.VCH_CERTIFICATE);
                cmd.Parameters.AddWithValue("@P_VCHOUT", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUT"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                str_Retvalue = cmd.Parameters["@P_VCHOUT"].Value.ToString();
                obj.status = Convert.ToInt32(1);
                obj.Response = "SUCCESS";
                OutPut.Add(obj);
            }
            catch (Exception ex)
            {
                obj.status = 0;
                obj.Response = ex.Message.ToString();
                OutPut.Add(obj);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                str_Retvalue = string.Empty;
            }
            return OutPut;
        }
        #endregion
    }
}