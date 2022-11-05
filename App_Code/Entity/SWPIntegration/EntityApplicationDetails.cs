using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.SWPIntegration
{
  public  class EntityApplicationDetails
    {
        public int INT_ID { get; set; }
        public string VCH_PROPOSALID { get; set; }
        public string VCH_INVESTOR_NAME { get; set; }
        public string VCH_APPLICATION_UNQ_KEY { get; set; }
        public int INT_SERVICEID { get; set; }
        public object DTM_CREATEDON { get; set; }
        public int INT_STATUS { get; set; }
        public int INT_DELETED_FLAG { get; set; }
        public int INT_ACTION_TAKEN_BY { get; set; }
        public int INT_ACTION_TOBE_TAKEN_BY { get; set; }
        public int INT_PAYMENT_STATUS { get; set; }
        public double NUM_PAYMENT_AMOUNT { get; set; }
        public string VCH_CERTIFICATE_FILENAME { get; set; }
        public string VCH_REFERENCE_DOC_NAME { get; set; }
        public string VCH_REMARK { get; set; }
        public int INT_ESCALATION_LEVELID { get; set; }
        public int INT_ULB_ID { get; set; }

    }
}
