using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.RxTerms
{
    /*
    * https://rxnav.nlm.nih.gov/REST/RxTerms/rxcui/{rxcui:198440}/name.json
    */
    public class DisplayGroup
    {
        public string rxcui { get; set; }
        public string displayName { get; set; }
    }
}
