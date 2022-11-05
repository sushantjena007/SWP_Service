
using System.Configuration;
using System;
namespace SWP_Services.DAL.Data
{
    /// <summary>
    /// Get the Connectionstring name
    /// </summary>
    /// <auther>Manas Bej</auther>
    public class DataBaseHelper
    {
        /// <summary>
        /// Get : the connection string name
        /// </summary>
        public static string ConnectionString 
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["ActiveConnection"].ToString();
                }
                catch (Exception)
                {
                    throw new Exception("ActiveConnection not found in appSettings section");
                }
            }
        }
    }
}