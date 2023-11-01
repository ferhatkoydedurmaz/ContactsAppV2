using ContactsApp.Core.Results;
using Newtonsoft.Json;
using System.Text;

namespace ContactsApp.WebUI.Services;

public class BaseService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<BaseResponse> DoPostRequest<T>(string clientName, string url, T data)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient(clientName);

            string json = JsonConvert.SerializeObject(data);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseResponse>(responseContent);

            return result;
        }
        catch
        {
            return default;
        }
    }

    public async Task<BaseDataResponse<U>> DoPostRequest<U, T>(string clientName, string url, T data)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient(clientName);

            string json = JsonConvert.SerializeObject(data);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDataResponse<U>>(responseContent);

            return result;
        }
        catch
        {
            return default;
        }
    }

    public async Task<BaseDataResponse<T>> DoGetRequest<T>(string clientName, string url)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient(clientName);

            var response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDataResponse<T>>(responseContent);

            return result;
        }
        catch
        {
            return default;
        }


    }

    public async Task<BaseResponse> DoGetRequest(string clientName, string url)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient(clientName);

            var response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseResponse>(responseContent);

            return result;
        }
        catch
        {
            return new BaseResponse(false, "Beklenmedik bir hata oluştu");
        }


    }

    public async Task<BaseResponse> DoDeleteRequest(string clientName, string url)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient(clientName);

            var response = await httpClient.DeleteAsync(url);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseResponse>(responseContent);

            return result;
        }
        catch
        {
            return new BaseResponse(false, "Beklenmedik bir hata oluştu");
        }
    }

    public async Task<BaseResponse> DoPutRequest<T>(string clientName, string url, T data)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient(clientName);

            string json = JsonConvert.SerializeObject(data);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(url, content);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseResponse>(responseContent);

            return result;
        }
        catch
        {
            return new BaseResponse(false, "Beklenmedik bir hata oluştu");
        }
    }
}
