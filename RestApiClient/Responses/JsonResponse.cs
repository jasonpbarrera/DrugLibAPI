using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiClient.Responses
{
    public class JsonResponse
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public CancellationToken AsyncToken { get; set; }
        public string ResponseBody { get; set; }
        public Dictionary<string, string> ResponseHeaders { get; set; }
    }
}
