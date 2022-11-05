using EntityLayer.FIREEntity;
using System.Collections.Generic;

/// <summary>
/// Summary description for IFIREDAL
/// </summary>
/// 
namespace DataAcessLayer.FIREDAL
{
    public interface IFIREDAL
    {
        #region "FIRE Application Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for FIRE Application Status Update
        /// </summary>
        /// <param name="objFire"></param>
        /// <returns></returns>
        List<clsOutput> FireApplicationStatusUpdate(FIREEntity objFire);
        #endregion

        #region  "FIRE Payment Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for FIRE Payment Status Update
        /// </summary>
        /// <param name="objFire"></param>
        /// <returns></returns>
        List<clsOutput> FirePaymentUpdate(FIREEntity objFire);

        #endregion

        #region "FIRE Query Compliance Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for FIRE Query Compliance Status Update
        /// </summary>
        /// <param name="objFire"></param>
        /// <returns></returns>
        List<clsOutput> FireQueryCompliance(FIREEntity objFire);

        #endregion
    }
}