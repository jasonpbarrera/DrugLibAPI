using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.RxNorm
{
    public class NdcStatusInfo
    {
        public Ndcstatus NdcStatus { get; set; }
    }

    public class Ndcstatus
    {
        public string Status { get; set; }
        public string Comment { get; set; }
        public NdcHistory[] NdcHistory { get; set; }
    }

    public class NdcHistory
    {
        public string ActiveRxcui { get; set; }
        public string OriginalRxcui { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

}
