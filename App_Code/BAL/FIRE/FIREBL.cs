using DataAcessLayer.FIREDAL;
using EntityLayer.FIREEntity;
using System.Collections.Generic;

/// <summary>
/// Summary description for FIREBL
/// </summary>
/// 
namespace BusinessLogicLayer.Fire
{
    public class FIREBL : IFIREBL
    {
        FIREDAL objFireDal = new FIREDAL();

        public List<clsOutput> FireApplicationStatusUpdate(FIREEntity objFire)
        {
            return objFireDal.FireApplicationStatusUpdate(objFire);
        }

        public List<clsOutput> FirePaymentUpdate(FIREEntity objFire)
        {
            return objFireDal.FirePaymentUpdate(objFire);
        }

        public List<clsOutput> FireQueryCompliance(FIREEntity objFire)
        {
            return objFireDal.FireQueryCompliance(objFire);
        }
    }
}