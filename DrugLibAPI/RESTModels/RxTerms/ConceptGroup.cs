using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.RxTerms
{
    public class ConceptGroup
    {
        public MinimumConceptGroup MinConceptGroup { get; set; }
    }

    public class MinimumConceptGroup
    {
        public MinimumConcept[] minConcept { get; set; }
    }
}
