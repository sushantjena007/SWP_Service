using SWP_Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

/// <summary>
/// Summary description for BPASBL
/// </summary>
/// 

namespace SWP_Services.BL
{
    public class BPASBL : IBPASBL
    {
        BPASDAL obj = new BPASDAL();

        #region "BPAS PayMent Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS PayMent Status Update
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>      
        public List<BPASPushDataStatus> BPASPayMentUpdate(BPASPaymentStatus objUser)
        {
            return obj.BPASPayMentUpdate(objUser);
        }
        #endregion

        #region "BPAS Application Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS Application Status Update
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>      
        public List<BPASPushDataStatus> BPASApplicationStatusUpdate(BPASPushData objDATA)
        {
            return obj.BPASApplicationStatusUpdate(objDATA);
        }
        #endregion

        #region "BPAS Application UNIQUE GENERATE"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS Application UNIQUE GENERATE
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<BPASApplicationunique> BPASApplicationUniqueKey(BPASPushData objDATA)
        {
            return obj.BPASApplicationUniqueKey(objDATA);
        }

        #endregion

        #region "BPAS Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-JULY-2019 for BPAS Status Update
        /// </summary>
        /// <param name="objDATA"></param>
        /// <returns></returns>
        public List<BPASPushDataStatus> BPASStatusUpdate(BPASApplicationStatus objUser)
        {
            return obj.BPASStatusUpdate(objUser);
        }
        #endregion
    }
}