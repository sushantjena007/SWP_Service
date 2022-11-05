using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Investor
/// </summary>
namespace EntityLayer.Investor
{
    public class Investor
    {
        public string IndustryName { get; set; }
        public string Email { get; set; }
        public string ContactPersonName { get; set; }
        public string OfficeMobileNo { get; set; }
        public string Address { get; set; }
        public string PAN { get; set; }
        public string UniqueId { get; set; }
        public string UserId { get; set; }
        public string SiteLocation { get; set; }
        public string IndustryCode { get; set; }
        public string Password { get; set; }
    }
    public class InvestorPushDataStatus
    {
        public string StatusMsg { get; set; }
        public int Status { get; set; }
    }
}