using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI.RESTModels.Interactions
{
    public class InteractionsList
    {

        public string nlmDisclaimer { get; set; }
        public Userinput userInput { get; set; }
        public Fullinteractiontypegroup[] fullInteractionTypeGroup { get; set; }
        

        public class Userinput
        {
            public string[] sources { get; set; }
            public string[] rxcuis { get; set; }
        }

        public class Fullinteractiontypegroup
        {
            public string sourceDisclaimer { get; set; }
            public string sourceName { get; set; }
            public Fullinteractiontype[] fullInteractionType { get; set; }
        }

        public class Fullinteractiontype
        {
            public string comment { get; set; }
            public Minconcept[] minConcept { get; set; }
            public Interactionpair[] interactionPair { get; set; }
        }

        public class Minconcept
        {
            public string rxcui { get; set; }
            public string name { get; set; }
            public string tty { get; set; }
        }

        public class Interactionpair
        {
            public Interactionconcept[] interactionConcept { get; set; }
            public string description { get; set; }
        }

        public class Interactionconcept
        {
            public Minconceptitem minConceptItem { get; set; }
            public Sourceconceptitem sourceConceptItem { get; set; }
        }

        public class Minconceptitem
        {
            public string rxcui { get; set; }
            public string name { get; set; }
            public string tty { get; set; }
        }

        public class Sourceconceptitem
        {
            public string id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }


    }
}
