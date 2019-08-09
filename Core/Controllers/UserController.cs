using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.APIManager;
using RestSharp;
using Newtonsoft.Json;

namespace Core.Controllers
{
    public class UserController
    {
        private APIclient ApiClient;

        public UserController()
        {
            ApiClient = APIclient.Instance;
        }

        public User GetUser(string endPoint, out int statusCode)
        {
            RestRequest request = ApiClient.Get(endPoint);
            IRestResponse response = ApiClient.Execute(request);
            statusCode = (int)response.StatusCode;
            User user = JsonConvert.DeserializeObject<User>(response.Content);
            return user;
        }
    }
}
