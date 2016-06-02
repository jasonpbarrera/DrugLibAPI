using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugLibAPI.RESTModels.DailyMed;

namespace DrugLibAPI
{
    public partial class DrugApiClient
    {

        public const string BaseDailyMedUrl = "https://dailymed.nlm.nih.gov";
        public enum DrugNameType
        {
            Branded,
            Generic,
            Both
        }
        public async static Task<DrugNames> GetDrugNames(string drugNameFilter = null, DrugNameType drugTypeFilter = DrugNameType.Both, string manufacturerFilter = null, int pageNumber = 1, int pageSize = 100)
        {

            string resourceUrl = "/dailymed/services/v2/drugnames.json";

            string options = "?name_type=";

            switch (drugTypeFilter)
            {
                case DrugNameType.Branded:
                    options += "b";
                    break;
                case DrugNameType.Generic:
                    options += "g";
                    break;
                case DrugNameType.Both:
                default:
                    options += "both";
                    break;
            }
            options += "&";

            if (!string.IsNullOrEmpty(drugNameFilter))
                options += $"drug_name={drugNameFilter}&";

            if (!string.IsNullOrEmpty(manufacturerFilter))
                options += $"manufacturer={manufacturerFilter}&";

            options += $"page={pageNumber}&pagesize={pageSize}";

            resourceUrl += options;

            return await CallApi<DrugNames>(BaseDailyMedUrl, resourceUrl);
        }
        
        public async static Task<DrugNames> GetAllDrugNames()
        {
            var drugs = new DrugNames()
            {
                metadata = new Metadata(),
                data = new Datum[0]
            };

            DrugNames result = null;

            do
            {

                Console.WriteLine($"Loading records...");
                result = await GetDrugNames(pageNumber: 
                    (drugs.metadata.next_page == null || drugs.metadata.next_page == "null" || drugs.metadata.next_page == "0") ? 1 : Convert.ToInt32(drugs.metadata.next_page));

                drugs.metadata = result.metadata;
                drugs.data = drugs.data.Concat(result.data).ToArray();


                Console.WriteLine($"Loaded {drugs.data.Length} records.");

                await Task.Run(()=>
                {
                    foreach (var item in result.data)
                    {
                        Console.WriteLine($"Drug: {item.drug_name} ({item.name_type})");
                    }
                });

            } while (result != null && result.metadata.total_elements > drugs.data.Length);

            return drugs;
        }

        public async static Task<NDCs> GetNDCRecords(int page = 1, int pagesize = 100)
        {
            string resource = $"/dailymed/services/v2/ndcs.json?pagesize={pagesize}&page={page}";
            return await CallApi<NDCs>(BaseDailyMedUrl, resource);
        }

        public async static Task<NDCs> GetAllNDCRecords()
        {
            var ndcs = new NDCs
            {
                data = new NDCs.NdcDatum[0],
                metadata = new Metadata()
            };

            NDCs result = null;

            do
            {
                Console.WriteLine($"Loading records...");
                result = await GetNDCRecords(page: (ndcs.metadata.next_page == null || ndcs.metadata.next_page == "null" || ndcs.metadata.next_page == "0") ? 1 : Convert.ToInt32(ndcs.metadata.next_page));

                ndcs.metadata = result.metadata;
                ndcs.data = ndcs.data.Concat(result.data).ToArray();


                Console.WriteLine($"Loaded {ndcs.data.Length} records.");

                await Task.Run(() =>
                {
                    foreach (var item in result.data)
                    {
                        Console.WriteLine($"NDC: {item.ndc}");
                    }
                });
            } while (result != null && result.metadata.total_elements > ndcs.data.Length);

            return ndcs;
        }

    }
}
