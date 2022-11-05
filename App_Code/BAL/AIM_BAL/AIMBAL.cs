using DataAcessLayer.AIMDAL;
using EntityLayer.AIMEntity;

/// <summary>
/// Summary description for AIMBAL
/// </summary>

namespace BusinessLogicLayer.AIM
{
    public class AIMBAL : IAIMBAL
    {
        public AIMStatusResponse UpdateEinPc(AIMEntity objPushData)
        {
            AIMDAL objDal = new AIMDAL();
            return objDal.UpdateEinPc(objPushData);
        }
    }
}