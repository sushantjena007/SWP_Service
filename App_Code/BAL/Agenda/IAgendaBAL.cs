using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EntityLayer.Agenda;
using System.ServiceModel.Web;
namespace BusinessLogicLayer.Agenda
{
    [ServiceContract]
    public interface  IAgendaBAL
    {
         [OperationContract]
         [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddAgenda")]
        string AddAgenda(int Status, string vchProposalNo, string Remark, string URL, string RecomendLand);
         [OperationContract]
         [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAgendaDet")]
         List<AgendaDet> GetAgendaDet(AgendaDet objLand);
         [OperationContract]
         [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddAgendaDetails")]
         string AddAgendaDetails(int Status, string vchProposalNo, string Remark, string URL);
    }
}
