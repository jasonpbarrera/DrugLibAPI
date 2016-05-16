using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestApiClient.Requests
{
    public class JsonRequest
    {

        private bool _resourcesProcessed;
        private string _resourcePath;
        public string ResourcePath {
            get {
                if (_resourcesProcessed)
                    return _resourcePath;

                _resourcesProcessed = true;
                _resourcePath = ProcessPathSegments();
                if (parameters.Any())
                {
                    var helper = new Uri(_resourcePath, UriKind.RelativeOrAbsolute);
                    if (string.IsNullOrEmpty(helper.Query))
                    {
                        _resourcePath += "?" + string.Join("&", parameters.Select(x => x.Key + "=" + x.Value));
                    }
                    else
                    {
                        string query = helper.Query;
                        if (!query.EndsWith("&")) query += "&";
                        query += string.Join("&", parameters.Select(x => x.Key + "=" + x.Value));
                        _resourcePath = helper.PathAndQuery.Substring(ResourcePath.IndexOf("?"));
                        _resourcePath += query;
                    }
                }
                return _resourcePath;
            }
            private set
            {
                _resourcePath = value;
            }
        }
        public HttpMethod Method { get; private set; }
        Dictionary<string, string> segments;
        Dictionary<string, string> parameters;
        Dictionary<string, string> headers;
        List<string> files;
        string jsonBodyData;

        public JsonRequest(string resourcePath, HttpMethod requestMethod)
        {
            ResourcePath = resourcePath;
            Method = requestMethod;
            segments = new Dictionary<string, string>();
            parameters = new Dictionary<string, string>();
            headers = new Dictionary<string, string>();
            files = new List<string>();

        }


        public void AddUrlSegment(string id, string value) => segments.Add(id, value);
        public void AddParameter(string name, string value) => parameters.Add(name, value);
        public void AddHeader(string name, string value) => headers.Add(name, value);
        public void AddFile(string filePath) => files.Add(filePath);
        public void AddJsonBody(string jsonBody) => jsonBodyData = jsonBody;

        string GetSegment(string id)
        {
            return segments.Where(x => x.Key.ToLower() == id.ToLower())
                .Select(x => x.Value).FirstOrDefault();
        }

        public bool ProcessHeaders(HttpRequestHeaders requestHeaders)
        {
            if (headers.Any() && !headers.All(x => requestHeaders.TryAddWithoutValidation(x.Key, x.Value)))
            {
                throw new Exception("Headers could not be added.");
            }
            return true;
        }

        string ProcessPathSegments()
        {
            var matches = Regex.Matches(_resourcePath ?? string.Empty,
                @"\{[a-zA-Z0-9]+\}",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (matches?.Count > 0)
                return _resourcePath;

            string resourcePath = _resourcePath;
            foreach (Match item in matches)
            {
                if (item.Success)
                {
                    var replacement = this.GetSegment(item.Value.Replace("{", "").Replace("}", ""));

                    resourcePath = resourcePath.Substring(0, item.Index) + replacement + resourcePath.Substring(item.Index + item.Length);
                }
            }

            return resourcePath;
        }



        public HttpContent ToContent()
        {
            HttpContent content = null;
            switch (Method.Method.ToLower())
            {
                case "get":
                default:
                    break;

            }

            return content;
        }
    }
}
