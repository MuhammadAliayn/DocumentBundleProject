using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace InPlace4.Models
{
    class __RestClient
    {
        private Uri __ControllerURL;
        public __RestClient(string ControllerURL)
        {
            __ControllerURL = new Uri(ControllerURL);
        }

        public string PostCallMicroService(string ControllerAction, string JsonRequest, Dictionary<string, string> NameValueParams = null, string JwtToken = null)
        {
            string JsonResponse = string.Empty;
            __mError mError = new __mError(true, "PostCallMicroService - " + ControllerAction + " - ");

            try
            {
                HttpClient client = new HttpClient();
                if (!string.IsNullOrEmpty(JwtToken)) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                client.BaseAddress = __ControllerURL;
                if (string.IsNullOrEmpty(JsonRequest)) JsonRequest = "{}";
                Dictionary<string, string> NameValue = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonRequest);
                HttpContent content = new FormUrlEncodedContent(NameValue);
                if (NameValueParams != null)
                {
                    ControllerAction += "?";
                    foreach (KeyValuePair<string, string> Param in NameValueParams)
                    {
                        ControllerAction += Param.Key + "=" + Param.Value + "&";
                    }
                    ControllerAction = ControllerAction.Substring(0, ControllerAction.Length - 1);
                }
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response = client.PostAsync(ControllerAction, content).Result;

                if (response.IsSuccessStatusCode) JsonResponse = response.Content.ReadAsStringAsync().Result.Replace("}{", ",");
                else
                {
                    mError.Message += "HTTP StatusCode: " + response.StatusCode.ToString();
                    JsonResponse = JsonConvert.SerializeObject(mError);
                }
            }
            catch (Exception e)
            {
                mError.Message += e.Message;
                JsonResponse = JsonConvert.SerializeObject(mError);
            }

            return JsonResponse;
        }

        internal object PostCallMicroService(string v1, string v2, Dictionary<string, string> @params, object p)
        {
            throw new NotImplementedException();
        }

        public string GetCallMicroService(string ControllerAction, string JsonRequest, string JwtToken = null)
        {
            string JsonResponse = string.Empty;
            __mError mError = new __mError(true, "GetCallMicroService - " + ControllerAction + " - ");

            try
            {
                HttpClient client = new HttpClient();
                if (!string.IsNullOrEmpty(JwtToken)) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                client.BaseAddress = __ControllerURL;
                if (string.IsNullOrEmpty(JsonRequest)) JsonRequest = "{}";
                Dictionary<string, string> NameValue = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonRequest);
                string Params = "?";
                foreach (KeyValuePair<string, string> NameValuePair in NameValue) Params += NameValuePair.Key + "=" + NameValuePair.Value + "&";
                Params = Params.Substring(0, Params.Length - 1);
                HttpResponseMessage response = client.GetAsync(ControllerAction + Params).Result;

                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode) JsonResponse = response.Content.ReadAsStringAsync().Result.Replace("}{", ",");
                else
                {
                    mError.Message += "HTTP StatusCode: " + response.StatusCode.ToString();
                    JsonResponse = JsonConvert.SerializeObject(mError);
                }
            }
            catch (Exception e)
            {
                mError.Message += e.Message;
                JsonResponse = JsonConvert.SerializeObject(mError);
            }

            return JsonResponse;
        }
    }
}