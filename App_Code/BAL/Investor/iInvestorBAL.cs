using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer.Investor;
using SWP_Services.DAL;

/// <summary>
/// Summary description for iInvestorBAL
/// </summary>
namespace BusinessLogicLayer.Investor
{
    [ServiceContract]
    public interface iInvestorBAL
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SWPPushInvestorData")]
        List<EntityLayer.Investor.InvestorPushDataStatus> SWPPushInvestorData(EntityLayer.Investor.Investor objPushData);
    }
}