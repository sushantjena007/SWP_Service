using DataAcessLayer.EXCISEDAL;
using EntityLayer.EXCISEEntity;
using System.Collections.Generic;


/// <summary>
/// Summary description for FIREBL
/// </summary>
/// 
namespace BusinessLogicLayer.Excise
{
    public class EXCISEBL : IEXCISEBL
    {
        EXCISEDAL objExciseDal = new EXCISEDAL();

        public List<clsOutput> ExciseApplicationStatusUpdate(EXCISEEntity objExcise)
        {
            return objExciseDal.ExciseApplicationStatusUpdate(objExcise);
        }

        public List<clsOutput> ExcisePaymentStatusUpdate(EXCISEEntity objExcise)
        {
            return objExciseDal.ExcisePaymentStatusUpdate(objExcise);
        }

        //public List<clsOutput> ExciseQueryStatusUpdate(EXCISEEntity objExcise)
        //{
        //    return objExciseDal.ExciseQueryStatusUpdate(objExcise);
        //}  
    }
}