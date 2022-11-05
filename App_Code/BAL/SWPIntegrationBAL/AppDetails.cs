using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.SWPIntegrationBAL
{
    public class AppDetails:IAppDetails
    {
        public string getTest(string userid, string swpCode)
        {
            return userid + swpCode;
        }
    }
}
