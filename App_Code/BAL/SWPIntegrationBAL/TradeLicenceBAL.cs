using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessLayer.SWPIntegrationDAL;

using EntityLayer.SWPIntegration;
namespace BusinessLogicLayer.SWPIntegrationBAL
{
    public class TradeLicenceBAL : ITradeLicenceBAL
    {

        public string SWPPushData(int servicId, string applicationnumber, string Str_Invstrname, int applicationStatus, string userId, string industrycode, int Paymentstatus, string Paymenttransactionid, decimal Dec_PaymentAmnt, string ulbcode)
        {
            DALApplicationDetails objDal = new DALApplicationDetails();
            return objDal.SWPPushDataDAL(servicId, applicationnumber, Str_Invstrname, applicationStatus, userId, industrycode, Paymentstatus, Paymenttransactionid, Dec_PaymentAmnt, ulbcode);

        }


        public List<SWPProfile> GetUserProfile(string proposalid, string userid)
        {
            DALApplicationDetails objDal = new DALApplicationDetails();
            return objDal.ViewInvestorDetails(userid);
        }


        public string getTest(string userid, string swpCode)
        {
            return userid + swpCode;
        }


        public string SWPPushQuery(string ApplicationNumber, int NoOfTime, string Remark, string Key)
        {
            DALApplicationDetails objDal = new DALApplicationDetails();
            return objDal.SWPPushQuery(ApplicationNumber, NoOfTime, Remark, Key);

        }
    }
}
