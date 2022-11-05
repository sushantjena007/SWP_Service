using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CMDashboard
/// </summary>
namespace EntityLayer.CMDashboard
{
	public class CMDashboardEntity
	{
		public string SecurityKey { get; set; }
		public string FromDate { get; set; }
		public string ToDate { get; set; }
		public int DistrictId { get; set; }
	}

	
	public class YearWiseCompanyRegistered
	{
		public string RegistrationYear { get; set; }
		public int NoOfRegistrationInYear { get; set; }
			
	}

	public class clsOutput1
	{
		public int Status { get; set; }
		public string OutMessage { get; set; }
		public List<YearWiseCompanyRegistered> YearWiseCompanyRegistered { get; set; }
	}


	public class TotalNoOfCompaniesRegistered
	{
		public int TotalCompanyRegistered { get; set; }
		
	}

	public class clsOutput2
	{
		public int Status { get; set; }
		public string OutMessage { get; set; }
		public List<TotalNoOfCompaniesRegistered> TotalNoOfCompaniesRegistered { get; set; }
	}

	public class SectorWiseCompanyRegistered
	{
		public string SectorName { get; set; }
		public int SectorId { get; set; }
		public int NoOfRegistration { get; set; }
				
	}

	public class clsOutput3
	{
		public int Status { get; set; }
		public string OutMessage { get; set; }
		public List<SectorWiseCompanyRegistered> SectorWiseCompanyRegistered { get; set; }
	}
}
