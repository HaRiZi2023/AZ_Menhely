using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AZ_Desktop
{
    private readonly HttpClient _httpClient;
   
    public HttpClient()
    {
        _httpClient = new HttpClient();
        _baseUrl = baseUrl;
    }

    public async Task<string> GetResourceAsync(string resource)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{resource}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new Exception($"Failed to fetch resource: {response.ReasonPhrase}");
        }
    }
}
