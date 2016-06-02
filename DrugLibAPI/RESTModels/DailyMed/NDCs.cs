using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.DailyMed
{
    public class NDCs
    {

      
        public Metadata metadata { get; set; }
        public NdcDatum[] data { get; set; }
        


        public class NdcDatum
        {
            public string ndc { get; set; }
        }

    }
}
