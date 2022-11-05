using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessLayer.InvestorDAL;
using EntityLayer.Investor;

/// <summary>
/// Summary description for InvestorBAL
/// </summary>
namespace BusinessLogicLayer.Investor
{
    public class InvestorBAL : iInvestorBAL
    {

        public List<InvestorPushDataStatus> SWPPushInvestorData(EntityLayer.Investor.Investor objPushData)
        {
            InvestorDAL objDal = new InvestorDAL();
            return objDal.SWPPushInvestorData(objPushData);
        }
    }
}