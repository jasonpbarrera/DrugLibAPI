using RestApiClient.Requests;
using RestApiClient.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiClient
{
    public class JsonClient : IDisposable
    {

        HttpClient _rest;


        public Uri BaseUri { get; private set; }

        public JsonClient(Uri baseUrl)
        {
            BaseUri = baseUrl;
            _rest = new HttpClient();
            _rest.BaseAddress = baseUrl;
        }
        public JsonClient(string baseUrl)
            : this(new Uri(baseUrl))
        {
        }

        public TJsonModel Deserialize<TJsonModel>(JsonResponse response)
            where TJsonModel : class, new()
        {
            return Newtonsoft.Json.JsonConvert
                .DeserializeObject<TJsonModel>(response.ResponseBody);
        }

        public JsonResponse Execute<TJsonModel>(JsonRequest request, out TJsonModel model)
            where TJsonModel : class, new()
        {
            model = null;
            var result = Execute(request);


            model = Deserialize<TJsonModel>(result);
            return result;
        }
        public JsonResponse Execute(JsonRequest request)
        {
            var task = ExecuteAsync(request);
            task.Wait();

            return task.Result;
        }

        public async Task<TJsonModel> ExecuteAsync<TJsonModel>(JsonRequest request)
            where TJsonModel : class, new()
        {
            var result = await ExecuteAsync(request);
            return Deserialize<TJsonModel>(result);
        }

        public async Task<JsonResponse> ExecuteAsync(JsonRequest request)
        {
            var cancelToken = new CancellationToken(false);
            
            Task<HttpResponseMessage> responseTask;

            request.ProcessHeaders(_rest.DefaultRequestHeaders);

            switch (request.Method.Method.ToLower())
            {
                case "post":
                    responseTask = _rest.GetAsync(request.ResourcePath, HttpCompletionOption.ResponseContentRead, cancelToken);
                    break;

                case "put":
                    responseTask = _rest.GetAsync(request.ResourcePath, HttpCompletionOption.ResponseContentRead, cancelToken);
                    break;

                case "delete":
                    responseTask = _rest.GetAsync(request.ResourcePath, HttpCompletionOption.ResponseContentRead, cancelToken);
                    break;

                case "get":
                default:
                    responseTask = _rest.GetAsync(request.ResourcePath, HttpCompletionOption.ResponseContentRead, cancelToken);
                    break;
            }

            var response = await responseTask;
            return new JsonResponse
            {
                AsyncToken = cancelToken,
                StatusCode = (int)response.StatusCode,
                IsSuccess = response.IsSuccessStatusCode,
                ResponseHeaders = response.Content.Headers
                    .ToDictionary(x=>x.Key, x => string.Join("; ", x.Value)),
                ResponseBody = await response.Content.ReadAsStringAsync()
            };

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _rest.Dispose();
                    _rest = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Client() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
