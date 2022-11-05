using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer.SWPIntegration;

namespace BusinessLogicLayer.SWPIntegrationBAL
{
     [ServiceContract]
    public interface ITradeLicenceBAL
    {
         [OperationContract]
         [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
          BodyStyle =  WebMessageBodyStyle.WrappedRequest
         )]
         string SWPPushData(int serviceId, string applicationnumber, string Str_Invstrname, int applicationStatus, string userId, string industrycode, int Paymentstatus, string Paymenttransactionid, decimal Dec_PaymentAmnt,string ulbcode);

         [OperationContract]
         [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "getUserProfiles/{proposalid}/{userid}")]
         //UriTemplate = "getUserProfiles/{userid}")]
         // List<SWPProfile> GetUserProfile(string userid);
         List<SWPProfile> GetUserProfile(string proposalid, string userid);

         [OperationContract]
         [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped,
         UriTemplate = "getTest/{userid}/{swpCode}")]
        string getTest(string userid, string swpCode);

         [OperationContract]
         [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedRequest
         )]
         string SWPPushQuery(string ApplicationNumber, int NoOfTime, string Remark, string Key);

    }
}
