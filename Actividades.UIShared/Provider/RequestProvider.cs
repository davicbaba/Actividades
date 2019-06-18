using Actividades.UIShared.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Actividades.UIShared.Provider
{
    public class RequestProvider
    {
   

        public RequestProvider()
        {
        }

        public async Task<RequestResult> RequestDelete(string endPoint)
        {
            HttpClient httpClient = GetHttpClient();

            HttpResponseMessage resp = await httpClient.DeleteAsync(endPoint);

            httpClient.Dispose();

            return await GetQueryResult(resp);
        }

        public async Task<RequestResult> RequestDelete<TInput>(TInput datos, string endPoint)
        {
            HttpClient httpClient = GetHttpClient();

            string json = JsonConvert.SerializeObject(datos);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, endPoint);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage resp = await httpClient.SendAsync(request);
            string content = resp.StatusCode == HttpStatusCode.BadRequest ? await resp.Content.ReadAsStringAsync() : "";
            httpClient.Dispose();

            return await GetQueryResult(resp);
        }


        public async Task<RequestResult> RequestGet(string endPoint)
        {
            HttpClient httpClient = GetHttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(endPoint);

            httpClient.Dispose();

            bool readAsString = response.IsSuccessStatusCode;

            return await GetQueryResult(response, readAsString);
        }

        public async Task<RequestResult> RequestPost<TDatos>(List<TDatos> datos, string endPoint)
        {
            HttpClient httpClient = GetHttpClient();

            string json = JsonConvert.SerializeObject(datos);

            HttpResponseMessage response = await httpClient.PostAsync(endPoint, new StringContent(json, Encoding.UTF8, "application/json"));

            httpClient.Dispose();

            return await GetQueryResult(response, true);
        }

        public async Task<RequestResult> RequestPost<TDatos>(TDatos datos, string endPoint)
        {
            HttpClient httpClient = GetHttpClient();

            string json = JsonConvert.SerializeObject(datos);

            HttpResponseMessage response = await httpClient.PostAsync(endPoint, new StringContent(json, Encoding.UTF8, "application/json"));

            httpClient.Dispose();

            return await GetQueryResult(response, true);
        }

        public async Task<RequestResult> RequestPut<TDatos>(List<TDatos> datos, string endPoint)
        {
            HttpClient httpClient = GetHttpClient();

            string json = JsonConvert.SerializeObject(datos);

            HttpResponseMessage response = await httpClient.PutAsync(endPoint, new StringContent(json, Encoding.UTF8, "application/json"));

            httpClient.Dispose();

            return await GetQueryResult(response);
        }


        public async Task<RequestResult> RequestPut<TDatos>(TDatos datos, string endPoint)
        {
            HttpClient httpClient = GetHttpClient();

            string json = JsonConvert.SerializeObject(datos);

            HttpResponseMessage response = await httpClient.PutAsync(endPoint, new StringContent(json, Encoding.UTF8, "application/json"));

            httpClient.Dispose();

            return await GetQueryResult(response);
        }

        private HttpClient GetHttpClient(int timeOutMinutes = 30)
        {
            HttpClient client = new HttpClient();

            client.Timeout = TimeSpan.FromMinutes(timeOutMinutes);

            client.DefaultRequestHeaders.Clear();

            return client;
        }

        private async Task<RequestResult> GetQueryResult(HttpResponseMessage httpResponseMessage, bool readAsString = false)
        {
            string response = null;

            if (readAsString && httpResponseMessage.IsSuccessStatusCode)
                response = await httpResponseMessage.Content.ReadAsStringAsync();

            return new RequestResult()
            {
                JsonResponse = response,
                StatusCode = httpResponseMessage.StatusCode,
                IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode
            };
        }
    }
}
