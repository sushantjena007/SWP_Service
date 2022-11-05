using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer.Investor;

/// <summary>
/// Summary description for IinvestorDAL
/// </summary>
namespace DataAcessLayer.InvestorDAL
{
	public interface IinvestorDAL
	{
        List<InvestorPushDataStatus> SWPPushInvestorData(Investor objDATA);
	}
}