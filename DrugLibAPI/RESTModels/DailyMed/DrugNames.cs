using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.DailyMed
{
    public class DrugNames
    {

        public Metadata metadata { get; set; }
        public Datum[] data { get; set; }
       

    }
        public class Metadata
        {
            public int elements_per_page { get; set; }
            public string next_page_url { get; set; }
            public int total_pages { get; set; }
            public int total_elements { get; set; }
            public string current_url { get; set; }
            public string next_page { get; set; }
            public string previous_page { get; set; }
            public string previous_page_url { get; set; }
            public int current_page { get; set; }
        }

        public class Datum
        {
            public string name_type { get; set; }
            public string drug_name { get; set; }
        }
}
