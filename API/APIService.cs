using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.API
{
    public abstract class APIService : IAPIService
    {
        private string? _url { get; set; }
        private readonly HttpClient _httpClient;

        protected APIService(string? url, HttpClient httpClient) 
        {
            _url = url;
            _httpClient = httpClient;
        }

        public async Task<TResponse> GetApiResponse<TResponse>(string optionalParamas = "") 
        {
            try
            {
                if (!string.IsNullOrEmpty(optionalParamas))
                {
                    _url += optionalParamas;
                }
                var response = await _httpClient.GetStringAsync(_url);
                var results = JsonConvert.DeserializeObject<TResponse>(response);
                if (results == null) return Activator.CreateInstance<TResponse>();
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
    }
}
