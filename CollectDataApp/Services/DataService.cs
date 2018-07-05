using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CollectDataApp.Entities;
using Newtonsoft.Json;

namespace CollectDataApp.Services
{
    class DataService
    {
        private readonly HttpClient _client;

        public DataService()
        {
            _client = new HttpClient();
        }

        private async Task<List<T>> GetDataCollectionByEndpointAsync<T>(string endpoint) where T : class
        {
            List<T> data;

            using (HttpResponseMessage response = await _client.GetAsync(Settings.DataSource.Url + endpoint))
            {
                string result = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<T>>(result);
            }

            return data;
        }

        private async Task<List<User>> GetUsersAsync()
        {
            return await GetDataCollectionByEndpointAsync<User>(Settings.DataSource.Endpoints.Users);
        }

        private async Task<List<Post>> GetPostsAsync()
        {
            return await GetDataCollectionByEndpointAsync<Post>(Settings.DataSource.Endpoints.Posts);
        }

        private async Task<List<Comment>> GetCommentsAsync()
        {
            return await GetDataCollectionByEndpointAsync<Comment>(Settings.DataSource.Endpoints.Comments);
        }

        private async Task<List<ToDo>> GetToDosAsync()
        {
            return await GetDataCollectionByEndpointAsync<ToDo>(Settings.DataSource.Endpoints.ToDos);
        }
        private async Task<List<Address>> GetAddressesAsync()
        {
            return await GetDataCollectionByEndpointAsync<Address>(Settings.DataSource.Endpoints.Addresses);
        }

    }
}
