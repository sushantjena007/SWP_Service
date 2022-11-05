using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

/// <summary>
/// Summary description for IBPASBL
/// </summary>
namespace SWP_Services.BL
{
    [ServiceContract]
    public interface IBPASBL
    {
        #region "BPAS PayMent Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS PayMent Status Update
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "BPASPayMentUpdate")]
        List<BPASPushDataStatus> BPASPayMentUpdate(BPASPaymentStatus objUser);
        #endregion

        #region "BPAS Application Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS Application Status Update
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "BPASApplicationStatusUpdate")]
        List<BPASPushDataStatus> BPASApplicationStatusUpdate(BPASPushData objDATA);
        #endregion

        #region "BPAS Application UNIQUE GENERATE"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS Application UNIQUE GENERATE
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "BPASApplicationUniqueKey")]
        List<BPASApplicationunique> BPASApplicationUniqueKey(BPASPushData objDATA);
        #endregion

        #region "BPAS Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS Status Update
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "BPASStatusUpdate")]
        List<BPASPushDataStatus> BPASStatusUpdate(BPASApplicationStatus objUser);
        #endregion

    }
}