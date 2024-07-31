using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RentACar.Application.CustomExceptions;
using RentACar.Application.ResponseModels;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http.Json;

namespace RentACar.Client.Utils
{
    public static class HttpClientExtension
    {
        public async static Task<TResult> PostGetServiceResponseAsync<TResult, TValue>(this HttpClient Client, String Url, TValue Value, string token, bool ThrowSuccessException = false)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            var cont = JsonConvert.SerializeObject(Value, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            request.Content = new StringContent(cont, null, "application/json");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            var httpRes = await Client.SendAsync(request);
            //Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            //var httpRes = await Client.PostAsJsonAsync(Url, Value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<ServiceResponse<TResult>>();

                return !res.Success && ThrowSuccessException ? throw new ApiException(res.Message) : res.Value;
            }

            throw new HttpException(httpRes.StatusCode.ToString());
        }
        public async static Task<TResult> PostGetServiceResponseNullTokenAsync<TResult, TValue>(this HttpClient Client, String Url, TValue Value, bool ThrowSuccessException = false)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            var cont = JsonConvert.SerializeObject(Value, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            request.Content = new StringContent(cont, null, "application/json");
            var httpRes = await Client.SendAsync(request);
            //Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            //var httpRes = await Client.PostAsJsonAsync(Url, Value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<ServiceResponse<TResult>>();

                return !res.Success && ThrowSuccessException ? throw new ApiException(res.Message) : res.Value;
            }

            throw new HttpException(httpRes.StatusCode.ToString());
        }

        public async static Task<BaseResponse> PostGetBaseResponseAsync<TValue>(this HttpClient Client, String Url, TValue Value, string token, bool ThrowSuccessException = false)
        {
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            var httpRes = await Client.PostAsJsonAsync(Url, Value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<BaseResponse>();

                return !res.Success && ThrowSuccessException ? throw new ApiException(res.Message) : res;
            }

            throw new HttpException(httpRes.StatusCode.ToString());
        }


        public async static Task<T> GetServiceResponseAsync<T>(this HttpClient Client, String Url, string token, bool ThrowSuccessException = false)
        {
            
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            var httpRes = await Client.GetFromJsonAsync<ServiceResponse<T>>(Url);
            return !httpRes.Success && ThrowSuccessException ? throw new ApiException(httpRes.Message) : httpRes.Value;
        }
        public async static Task<T> GetServiceResponseNullTokenAsync<T>(this HttpClient Client, String Url, bool ThrowSuccessException = false)
        {

            var httpRes = await Client.GetFromJsonAsync<ServiceResponse<T>>(Url);
            return !httpRes.Success && ThrowSuccessException ? throw new ApiException(httpRes.Message) : httpRes.Value;
        }
    }
}
