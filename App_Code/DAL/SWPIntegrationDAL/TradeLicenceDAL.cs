using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EntityLayer.SWPIntegration;

using System.Data;
namespace DataAcessLayer.SWPIntegrationDAL
{
    public class DALApplicationDetails
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AdminAppConnectionProd"].ToString());
        string Str_RetValue = "";
        public string SWPPushDataDAL(int serviceId, string applicationnumber, string Str_Invstrname, int applicationStatus, string userId, string industrycode, int Paymentstatus, string Paymenttransactionid, decimal Dec_PaymentAmnt, string ulbcode)
        {
            
            SqlCommand cmd = new SqlCommand();
            try
            {

                cmd.Connection = conn;
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_ApplicationDetailsInsertUpdate_Integration";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_CHAR_ACTION", "I");
                cmd.Parameters.AddWithValue("@P_VCH_PROPOSALID", industrycode);
                cmd.Parameters.AddWithValue("@P_VCH_INVESTOR_NAME", Str_Invstrname);
                cmd.Parameters.AddWithValue("@P_VCH_APPLICATION_UNQ_KEY", applicationnumber);
                cmd.Parameters.AddWithValue("@P_SERVICEID", serviceId);
                cmd.Parameters.AddWithValue("@P_INT_STATUS", applicationStatus);
                cmd.Parameters.AddWithValue("@P_INT_ACTION_TAKEN_BY", 0);
                cmd.Parameters.AddWithValue("@P_INT_ACTION_TOBE_TAKEN_BY", 0);
                cmd.Parameters.AddWithValue("@P_INT_PAYMENT_STATUS", Paymentstatus);
                cmd.Parameters.AddWithValue("@P_VCH_PAYMENT_ACKNOWLEDGEMENT_NO", Paymenttransactionid);
                cmd.Parameters.AddWithValue("@P_NUM_PAYMENT_AMOUNT", Dec_PaymentAmnt);
                cmd.Parameters.AddWithValue("@P_VCH_CERTIFICATE_FILENAME", null);
                cmd.Parameters.AddWithValue("@P_VCH_REFERENCE_DOC_NAME ", null);
                cmd.Parameters.AddWithValue("@P_VCH_REMARK", 0);
                cmd.Parameters.AddWithValue("@P_INT_ESCALATION_ID", 0);
                cmd.Parameters.AddWithValue("@P_VCH_ULB_CODE", ulbcode);
                cmd.Parameters.AddWithValue("@P_INT_CREATEDBY", userId);
                //cmd.ExecuteNonQuery();
                // Str_RetValue = cmd.ExecuteNonQuery().ToString();
                cmd.Parameters.AddWithValue("@P_OUT_MSG", SqlDbType.VarChar);
                cmd.Parameters["@P_OUT_MSG"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Str_RetValue = cmd.Parameters["@P_OUT_MSG"].Value.ToString();

            }
            catch (NullReferenceException ex) { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally { cmd = null; conn.Close(); }
            return Str_RetValue;
        }


        public List<SWPProfile> ViewInvestorDetails(string userid)
        {

            List<SWPProfile> list = new List<SWPProfile>();
            SWPProfile objInvestor = new SWPProfile();

            SqlDataReader sqlReader = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Usp_GetUserProfile";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_UserId", userid);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                sqlReader = cmd.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        //objInvestor.proposalid = "1";
                        objInvestor.Investor_Name = sqlReader["VCH_INV_NAME"].ToString();
                        objInvestor.Unit_name = sqlReader["Unit_Name"].ToString();
                        objInvestor.Investor_MobileNo = Convert.ToDouble(sqlReader["VCH_OFF_MOBILE"]);
                        objInvestor.UnitMobileNo = Convert.ToDouble(sqlReader["Unit_MobileNo"]);
                        objInvestor.Investor_Addrss = sqlReader["VCH_ADDRESS"].ToString();
                        objInvestor.Unit_Address = sqlReader["Unit_Address"].ToString();
                        objInvestor.UnitEmailId = sqlReader["Unit_EmailId"].ToString();
                        objInvestor.Investor_EmailId = sqlReader["VCH_EMAIL"].ToString();
                        //objInvestor.promoter_FirstName = "Deepak";
                        //objInvestor.promoter_MiddleName = "Kumar";
                        //objInvestor.promoter_LastName="Das";
                        //objInvestor.comm_address = "Bhubaneswar";
                        //objInvestor.comm_address = "Bhubaneswar";
                        list.Add(objInvestor);
                    }
                }
                sqlReader.Close();
                return list;
               
            }

            catch (NullReferenceException ex) { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally { cmd = null; conn.Close(); }
        }

        #region GetUserID
        /// <summary>
        /// Prasun Kali on 29/8/2017
        /// </summary>
        /// <param name="Str_USrName"></param>
        /// <returns></returns>
        public int Int_GetUserID(string Str_USrName)
        {
            int Int_UserID = 0;
            
            SqlCommand cmd = new SqlCommand();
            SqlDataReader sqlReader = null;

            try
            {
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_GetUserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_VCH_UserName", Str_USrName);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                sqlReader = cmd.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {

                        Int_UserID = Convert.ToInt32(sqlReader["INT_INVESTOR_ID"]);

                    }
                   
                }
                sqlReader.Close();
            }
            catch (NullReferenceException ex) { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally { cmd = null; }
            return Int_UserID;
        }
        #endregion

        public string SWPPushQuery(string ApplicationNumber, int NoOfTime, string Remark, string key)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "USP_PUSHQUERY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_VCH_APPLICATION_NO", ApplicationNumber);
                cmd.Parameters.AddWithValue("@P_INT_NO_OF_TIME", NoOfTime);
                cmd.Parameters.AddWithValue("@P_VCH_REMARK", Remark);
                cmd.Parameters.AddWithValue("@P_VCH_KEY", key);

                cmd.Parameters.AddWithValue("@P_VCH_Output", SqlDbType.VarChar);
                cmd.Parameters["@P_VCH_Output"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Str_RetValue = cmd.Parameters["@P_VCH_Output"].Value.ToString();
            }
            catch (NullReferenceException ex) { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally { cmd = null; conn.Close(); }
            return Str_RetValue;
        }

    }
}
