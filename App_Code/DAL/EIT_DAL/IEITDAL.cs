using EntityLayer.EITEntity;
using System.Collections.Generic;

/// <summary>
/// Summary description for IEITDAL
/// </summary>
/// 
namespace DataAcessLayer.EITDAL
{
    public interface IEITDAL
    {
        #region "EIT Application Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 22-Jan-2021 for EIT Application Status Update
        /// </summary>
        /// <param name="objEIT"></param>
        /// <returns></returns>
        List<clsOutput> EITApplicationStatusUpdate(EITEntity objEIT);
        #endregion

        #region  "EIT Payment Status Update"
        /// <summary>
        /// Created By MANOJ KUMAR BEHERA on 22-Jan-2021 for EIT Payment Status Update
        /// </summary>
        /// <param name="objEIT"></param>
        /// <returns></returns>
        List<clsOutput> EITPaymentStatusUpdate(EITEntity objEIT);

        #endregion

        #region "EIT Query Status Update"
        ///<summary>
        /// Created By MANOJ KUMAR BEHERA on 22-Jan-2021 for EIT Query Status Update
        /// </summary>
        /// <param name = "objEIT" ></ param >
        /// < returns ></ returns >
        List< clsOutput > EITQueryStatusUpdate(EITEntity objEIT);

        #endregion
    }
}