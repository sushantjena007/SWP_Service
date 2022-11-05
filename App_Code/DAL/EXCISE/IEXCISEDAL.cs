using EntityLayer.EXCISEEntity;
using System.Collections.Generic;

/// <summary>
/// Summary description for IEXCISEDAL
/// </summary>
/// 
namespace DataAcessLayer.EXCISEDAL
{
    public interface IEXCISEDAL
    {
        #region "EXCISE Application Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for EXCISE Application Status Update
        /// </summary>
        /// <param name="objExcise"></param>
        /// <returns></returns>
        List<clsOutput> ExciseApplicationStatusUpdate(EXCISEEntity objExcise);
        #endregion

        #region  "EXCISE Payment Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for EXCISE Payment Status Update
        /// </summary>
        /// <param name="objExcise"></param>
        /// <returns></returns>
        List<clsOutput> ExcisePaymentStatusUpdate(EXCISEEntity objExcise);

        #endregion

        #region "EXCISE Query Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 24-NOV-2020 for EXCISE Query Status Update
        /// </summary>
        /// <param name="objExcise"></param>
        /// <returns></returns>
        //List<clsOutput> ExciseQueryStatusUpdate(EXCISEEntity objExcise);

        #endregion
    }
}