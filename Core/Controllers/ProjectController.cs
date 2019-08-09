using Core.APIManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Core.Controllers
{
    public class ProjectController
    {
        private APIclient ApiClient;

        public ProjectController()
        {
            ApiClient = APIclient.Instance;
        }

        public Project Post(Project payLoadProject, string projectEndPoint, out int statusCode)
        {
            string body = JsonConvert.SerializeObject(payLoadProject);
            RestRequest request = ApiClient.Post(projectEndPoint, body);
            IRestResponse response = ApiClient.Execute(request);
            statusCode = (int)response.StatusCode;
            Project project = JsonConvert.DeserializeObject<Project>(response.Content);
            return project;
        }

        public Project Delete(string endPoint, long id, out int statusCode)
        {
            RestRequest request = ApiClient.Delete(endPoint, id);
            IRestResponse response = ApiClient.Execute(request);
            statusCode = (int)response.StatusCode;
            Project project = JsonConvert.DeserializeObject<Project>(response.Content);
            return project;
        }

        public Project Update(Project payLoadProject, string endPoint, long id, out int statusCode)
        {
            string body = JsonConvert.SerializeObject(payLoadProject);
            RestRequest request = ApiClient.Put(endPoint, id, body);
            IRestResponse response = ApiClient.Execute(request);
            statusCode = (int)response.StatusCode;
            Project project = JsonConvert.DeserializeObject<Project>(response.Content);
            return project;
        }
    }
}
