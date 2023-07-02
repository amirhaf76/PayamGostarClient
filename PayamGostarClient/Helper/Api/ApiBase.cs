using Newtonsoft.Json;
using PayamGostarClient.Helper.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PayamGostarClient.Helper.Api
{
    public class ApiBase : ClientApiIntraction
    {
        public ApiBase()
        {
        }

        public static ApiBase CreateApiBase(ClientApiIntraction clientApiIntraction)
        {
            var apiBase = new ApiBase();

            apiBase.DomainUrl = clientApiIntraction.DomainUrl;
            apiBase.ClientId = clientApiIntraction.ClientId;
            apiBase.DeviceId = clientApiIntraction.DeviceId;
            apiBase.JwtToken = clientApiIntraction.JwtToken;
            apiBase.BasicParam = clientApiIntraction.BasicParam;

            return apiBase;
        }

        public async Task<HttpResponseMessage> PostApiAsync<TRequestBody>(Uri uri, TRequestBody requestBody)
            where TRequestBody : HttpContent
        {
            using (var client = CreateHttpClient())
            {
                return await client.PostAsync(uri, requestBody);
            }
        }

        public async Task<HttpResponseMessage> PostApiAsync(Uri uri, FormUrlEncodedContent formUrlEncoded)
        {
            using (var client = CreateHttpClient())
            {
                return await client.PostAsync(uri, formUrlEncoded);
            }
        }

        public async Task<HttpResponseMessage> DeleteApiAsync(Uri uri)
        {
            using (var client = CreateHttpClient())
            {
                return await client.DeleteAsync(uri);
            }
        }

        public async Task<HttpResponseMessage> GetApiAsync(Uri uri)
        {
            using (var client = CreateHttpClient())
            {
                return await client.GetAsync(uri);
            }
        }

        public async Task<HttpResponseMessage> PutApiAsync<TRequestBody>(Uri uri, TRequestBody requestBody)
            where TRequestBody : HttpContent
        {
            using (var client = CreateHttpClient())
            {
                return await client.PutAsync(uri, requestBody);
            }
        }

        public static async Task<T> CallApi<T>(Func<Task<HttpResponseMessage>> prepareAndCallApi)
        {
            return await CallApi(
                prepareAndCallApi,
                async response => JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()),
                response => { throw new Exception(response.ToString()); }
                );
        }

        public static async Task<T> CallApi<T>(
            Func<Task<HttpResponseMessage>> prepareAndCallApi,
            Func<HttpResponseMessage, Task<T>> ResponseHandler)
        {
            return await CallApi(
                prepareAndCallApi,
                ResponseHandler,
                response => { throw new Exception(response.ToString()); }
                );
        }

        public static async Task<T> CallApi<T>(
            Func<Task<HttpResponseMessage>> prepareAndCallApi,
            Func<HttpResponseMessage, Task<T>> responseHandler,
            Action<HttpResponseMessage> exceptionHandler
            )
        {
            HttpResponseMessage response = await prepareAndCallApi();

            if (response.IsSuccessStatusCode)
            {
                return await responseHandler(response);
            }

            exceptionHandler(response);

            return default;
        }
    }
}
