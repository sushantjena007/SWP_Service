using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NSWSEntity
/// </summary>
namespace EntityLayer.NSWSEntity
{
    public class NSWSEntity
    {
        public NSWSEntity()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string SecurityKey { get; set; }
        public string PAN { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantAddress { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string UnitName { get; set; }
        public int InvestmentLevel { get; set; }
        public string SiteLocation { get; set; }
        public string EinIemType { get; set; }
        public string EinIemNo { get; set; }
        public string EinIemDoc { get; set; }
        public int DistrictCode { get; set; }
        public int BlockCode { get; set; }
        public int SectorCode { get; set; }
        public int SubSectorCode { get; set; }
        public string GSTIN { get; set; }
        public string InvestorSWSId { get; set; }
    }

    public class clsOutput1
    {
        public int Status { get; set; }
        public string SSOId { get; set; }
        public string OutMessage { get; set; }
    }
}