using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer.NSWSEntity;

/// <summary>
/// Summary description for INSWSDAL
/// </summary>

namespace DataAcessLayer.NSWSDAL
{
    public interface INSWSDAL
    {
        List<clsOutput1> NSWSUserRegistration(NSWSEntity objNsws);        
    }
}