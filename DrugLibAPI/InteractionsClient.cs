using DrugLibAPI.RESTModels.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI
{
    public partial class DrugApiClient
    {

        public const string BaseInteractionsUrl = "https://rxnav.nlm.nih.gov/REST/interaction";



        public async static Task<Interactions> FindInteractions(string rxCUI)
        {
            string resource = $"/interaction.json?rxcui={rxCUI}";
            return await CallApi<Interactions>(BaseInteractionsUrl, resource);
        }

        public async static Task<InteractionsList> ListInteractions(IEnumerable<string> rxCUIsList)
        {
            string resource = $"/list.json?rxcuis={string.Join("+", rxCUIsList)}";
            return await CallApi<InteractionsList>(BaseInteractionsUrl, resource);
        }

    }
}
