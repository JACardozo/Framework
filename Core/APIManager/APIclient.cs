using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Settings;

namespace Core.APIManager
{
    public class APIclient
    {
        SettingsData Data = SettingsManager.Instance().Data;
        private string RootPath = "/api";
        private RestClient Client;
        private RestRequest Request;

        private static APIclient instance;

        public static APIclient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new APIclient();
                }
                return instance;
            }
        }

        private APIclient()
        {
            Client = new RestClient();
            Client.BaseUrl = new Uri(Data.UrlBase);
            Client.Authenticator = new HttpBasicAuthenticator(Data.UserName, Data.Password);
        }

        private void BuildBaseRequest(string endPoint)
        {
            string url = RootPath + endPoint;
            Request.Resource = url;
        }

        public RestRequest Get(string endPoint)
        {
            Request = new RestRequest(Method.GET);
            BuildBaseRequest(endPoint);
            return Request;
        }

        public RestRequest Post(string endPoint, string body)
        {
            Request = new RestRequest(Method.POST);
            BuildBaseRequest(endPoint);
            Request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            Request.RequestFormat = DataFormat.Json;
            return Request;
        }

        public RestRequest Put(string endPoint, long id, string body)
        {
            Request = new RestRequest(Method.PUT);
            BuildBaseRequest(endPoint);
            Request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            Request.AddParameter("id", id, ParameterType.UrlSegment);
            return Request;
        }

        public RestRequest Delete(string endPoint, long id)
        {
            Request = new RestRequest(Method.DELETE);
            BuildBaseRequest(endPoint);
            Request.AddParameter("id", id, ParameterType.UrlSegment);
            return Request;
        }

        public IRestResponse Execute(RestRequest request)
        {
            IRestResponse response = Client.Execute(request);
            return response;
        }
    }
}
