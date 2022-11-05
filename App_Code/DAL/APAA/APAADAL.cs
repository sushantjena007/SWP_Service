using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EntityLayer.APAA;
using System.Data;

/// <summary>
/// Summary description for APAADAL
/// </summary>
/// 
namespace DataAcessLayer.APAA
{

    public class APAADAL
    {
        public APAADAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        string str_Retvalue = "";
        string str_Retvalue2 = "";
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString());
        SqlCommand cmd = new SqlCommand();
        #region Apply Water Allotment
        public List<retMessage> ApplyWaterAllotment(APAAEntity objApaa)
        {

            conn.Open();
            cmd = new SqlCommand();
            clsOutput obj = new clsOutput();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_APAA_WATERALLOTMENT";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_ACTION", "A");
                cmd.Parameters.AddWithValue("@P_VCH_APPLICATION_UNQ_KEY",objApaa.VCH_APPLICATION_UNQ_KEY);
                cmd.Parameters.AddWithValue("@P_VCH_PROPOSALID", objApaa.VCH_PROPOSALID);
                cmd.Parameters.AddWithValue("@P_INT_SERVICEID", objApaa.INT_SERVICEID);
                cmd.Parameters.AddWithValue("@P_VCH_INVESTOR_NAME",objApaa.VCH_INVESTOR_NAME);
                cmd.Parameters.AddWithValue("@P_INT_STATUS",objApaa.INT_STATUS);
                cmd.Parameters.AddWithValue("@P_INT_PAYMENT_STATUS",objApaa.INT_PAYMENT_STATUS);

                cmd.Parameters.AddWithValue("@P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO", objApaa.VCH_PAYMENT_ACKNOWLEDGEMENT_NO);
                cmd.Parameters.AddWithValue("@P_VCH_CHALLAN_NO", objApaa.VCH_CHALLAN_NO);
                cmd.Parameters.AddWithValue("@P_NUM_PAYMENT_AMOUNT", objApaa.NUM_PAYMENT_AMOUNT);
                cmd.Parameters.AddWithValue("@P_VCH_CERTIFICATE_FILENAME", objApaa.VCH_CERTIFICATE_FILENAME);

                //cmd.Parameters.AddWithValue("@P_VCH_REMARK", objApaa.VCH_REMARK);
                cmd.Parameters.AddWithValue("@P_intApprovalLevel", objApaa.intApprovalLevel);
                cmd.Parameters.AddWithValue("@P_intQueryStatus", objApaa.intQueryStatus);

                cmd.Parameters.AddWithValue("@P_VCHOUT", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUT"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@P_VCHOUTMSG", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUTMSG"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                str_Retvalue = cmd.Parameters["@P_VCHOUT"].Value.ToString();
                str_Retvalue2 = cmd.Parameters["@P_VCHOUTMSG"].Value.ToString();
                obj.Status = str_Retvalue;
                obj.OutMessage = str_Retvalue2;
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };

            }            
            catch (Exception ex)
            {
                obj.Status = "0";
                obj.OutMessage = "ERROR";
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                str_Retvalue = string.Empty;
                str_Retvalue2 = string.Empty;
            }
        }
        #endregion

        #region QUERY RAISED
        public List<retMessage> QueryRaised(APAAEntity objApaa)
        {

            conn.Open();
            cmd = new SqlCommand();
            clsOutput obj = new clsOutput();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_APAA_WATERALLOTMENT";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_ACTION", "B");
                cmd.Parameters.AddWithValue("@P_INTDISTRICTID", objApaa.INTDISTRICTID);
                cmd.Parameters.AddWithValue("@P_DTM_RAISE_QUERY", objApaa.DTM_RAISE_QUERY);
                cmd.Parameters.AddWithValue("@P_INT_CONFIG_QUERY_TIMES", objApaa.INT_CONFIG_QUERY_TIMES);
                cmd.Parameters.AddWithValue("@P_INT_CURRENT_QUERY_TIMES", objApaa.INT_CURRENT_QUERY_TIMES);
                cmd.Parameters.AddWithValue("@P_VCH_APPLICATION_UNQ_KEY", objApaa.VCH_APPLICATION_UNQ_KEY);
                cmd.Parameters.AddWithValue("@P_VCHOUT", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUT"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@P_VCHOUTMSG", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUTMSG"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                str_Retvalue = cmd.Parameters["@P_VCHOUT"].Value.ToString();
                str_Retvalue2 = cmd.Parameters["@P_VCHOUTMSG"].Value.ToString();
                obj.Status = str_Retvalue;
                obj.OutMessage = str_Retvalue2;
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };
            }
            catch (Exception ex)
            {
                obj.Status = "0";
                obj.OutMessage = "ERROR";
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                str_Retvalue = string.Empty;
                str_Retvalue2 = string.Empty;
            }
            
        }
        #endregion

        #region QUERY RESPONSE
        public List<retMessage> QueryResponse(APAAEntity objApaa)
        {

            conn.Open();
            cmd = new SqlCommand();
            clsOutput obj = new clsOutput();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_APAA_WATERALLOTMENT";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_ACTION", "C");
                cmd.Parameters.AddWithValue("@P_INTDISTRICTID", objApaa.INTDISTRICTID);
                cmd.Parameters.AddWithValue("@P_DTM_RAISE_QUERY", objApaa.DTM_RAISE_QUERY);
                cmd.Parameters.AddWithValue("@P_VCH_APPLICATION_UNQ_KEY", objApaa.VCH_APPLICATION_UNQ_KEY);
                cmd.Parameters.AddWithValue("@P_VCHOUT", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUT"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@P_VCHOUTMSG", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUTMSG"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                str_Retvalue = cmd.Parameters["@P_VCHOUT"].Value.ToString();
                str_Retvalue2 = cmd.Parameters["@P_VCHOUTMSG"].Value.ToString();
                obj.Status = str_Retvalue;
                obj.OutMessage = str_Retvalue2;
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };
            }
            catch (Exception ex)
            {
                obj.Status = "0";
                obj.OutMessage = "ERROR";
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                str_Retvalue = string.Empty;
                str_Retvalue2 = string.Empty;
            }
        }
        #endregion

        #region Update Status       
        public List<retMessage> UpdateStatus(APAAEntity objApaa)
        {
            conn.Open();
            cmd = new SqlCommand();
            clsOutput obj = new clsOutput();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_APAA_WATERALLOTMENT";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_ACTION", "D");
                cmd.Parameters.AddWithValue("@P_INT_STATUS", objApaa.INT_STATUS);
                cmd.Parameters.AddWithValue("@P_VCH_APPLICATION_UNQ_KEY", objApaa.VCH_APPLICATION_UNQ_KEY);
                cmd.Parameters.AddWithValue("@P_VCHOUT", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUT"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@P_VCHOUTMSG", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUTMSG"].Direction = ParameterDirection.Output;


                cmd.ExecuteNonQuery();
                str_Retvalue = cmd.Parameters["@P_VCHOUT"].Value.ToString();
                str_Retvalue2 = cmd.Parameters["@P_VCHOUTMSG"].Value.ToString();
                obj.Status = str_Retvalue;
                obj.OutMessage = str_Retvalue2;
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };
            }
            catch (Exception ex)
            {
                obj.Status = "0";
                obj.OutMessage = "ERROR";
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                str_Retvalue = string.Empty;
                str_Retvalue2 = string.Empty;
            }
        }
        #endregion

        #region ISSUED
        public List<retMessage> IssueCertificate(APAAEntity objApaa)
        {
            conn.Open();
            cmd = new SqlCommand();
            clsOutput obj = new clsOutput();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_APAA_WATERALLOTMENT";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_ACTION", "E");
                cmd.Parameters.AddWithValue("@P_VCH_CERTIFICATE_FILENAME", objApaa.VCH_CERTIFICATE_FILENAME);
                cmd.Parameters.AddWithValue("@P_VCH_APPLICATION_UNQ_KEY", objApaa.VCH_APPLICATION_UNQ_KEY);
                cmd.Parameters.AddWithValue("@P_VCHOUT", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUT"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@P_VCHOUTMSG", SqlDbType.VarChar);
                cmd.Parameters["@P_VCHOUTMSG"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                str_Retvalue = cmd.Parameters["@P_VCHOUT"].Value.ToString();
                str_Retvalue2 = cmd.Parameters["@P_VCHOUTMSG"].Value.ToString();
                obj.Status = str_Retvalue;
                obj.OutMessage = str_Retvalue2;
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };
            }
            catch (Exception ex)
            {
                obj.Status = "0";
                obj.OutMessage = "ERROR";
                retMessage objret = new retMessage();
                objret.objOutParam = new List<clsOutput> { obj };
                return new List<retMessage> { objret };
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                str_Retvalue = string.Empty;
                str_Retvalue2 = string.Empty;
            }
        }
        #endregion
    }
}