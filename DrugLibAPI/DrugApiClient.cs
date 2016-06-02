using DrugLibAPI.RESTModels.RxNorm;
using DrugLibAPI.RESTModels.RxTerms;
using RestApiClient;
using RestApiClient.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DrugLibAPI
{
    public partial class DrugApiClient
    {

        private async static Task<TModel> CallApi<TModel>(string baseUri, string resource, HttpMethod method = null)
            where TModel : class, new()
        {
            if (method == null)
                method = HttpMethod.Get;

            using (var client = new JsonClient(baseUri))
            {
                return await client.ExecuteAsync<TModel>(new JsonRequest(resource, method));
            }
        }


        #region RxTerms

        public const string RxTermsBaseUri = "https://rxnav.nlm.nih.gov/REST/RxTerms";

        public async static Task<string> GetNameFromRxCUI(string rxcui)
        {
            string resource = $"/rxcui/{rxcui}/name.json";
            return (await CallApi<DisplayGroup>(RxTermsBaseUri, resource, HttpMethod.Get)).displayName;
        }

        public async static Task<RxtermsProperties> GetAllInfoFromRxCUI(string rxcui)
        {
            string resource = $"/rxcui/{rxcui}/allinfo.json";
            return await CallApi<RxtermsProperties>(RxTermsBaseUri, resource, HttpMethod.Get);
        }

        public async static Task<MinimumConcept[]> GetAllRxConcepts()
        {
            string resource = "/REST/RxTerms/allconcepts.json";
            return (await CallApi<ConceptGroup>(RxTermsBaseUri, resource, HttpMethod.Get))
                .MinConceptGroup.minConcept;
        }

        #endregion

        #region RxNorm

        public const string RxNormBaseUri = "https://rxnav.nlm.nih.gov/REST";

        public async static Task<NdcStatusInfo> GetNdcStatus(string ndc, bool includeHistory = false)
        {
            return await GetNdcStatus(ndc, null, null, includeHistory);
        }
        public async static Task<NdcStatusInfo> GetNdcStatus(string ndc, DateTime? startDate, DateTime? endDate, bool includeHistory = false)
        {
            string resource = $"/ndcstatus.json?ndc={ndc}&history={(includeHistory ? 1 : 0)}";
            if (startDate.HasValue && endDate.HasValue && endDate > startDate)
                resource += $"&start={startDate.Value:yyyyMM}&end={endDate.Value:yyyyMM}";

            return await CallApi<NdcStatusInfo>(RxNormBaseUri, resource);
        }

        #endregion
    }
}
