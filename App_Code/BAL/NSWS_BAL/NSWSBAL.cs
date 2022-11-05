using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcessLayer.NSWSDAL;
using EntityLayer.NSWSEntity;

/// <summary>
/// Summary description for NSWSBAL
/// </summary>
/// 
namespace BusinessLogicLayer.NSWS
{
    public class NSWSBAL : INSWSBAL
    {
        NSWSDAL objNswsDal = new NSWSDAL();

        public List<clsOutput1> NSWSUserRegistration(NSWSEntity objNsws)
        {
            return objNswsDal.NSWSUserRegistration(objNsws);
        }      
    }
}