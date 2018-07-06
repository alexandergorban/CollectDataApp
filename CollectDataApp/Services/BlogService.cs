using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CollectDataApp.Entities;
using CollectDataApp.Interfaces;
using Newtonsoft.Json;

namespace CollectDataApp.Services
{
    class BlogService
    {
        private readonly HttpClient _client;

        public BlogService(HttpClient client)
        {
            _client = client;
        }

        private async Task<List<T>> GetDataCollectionByEndpointAsync<T>(string endpoint) where T : IEndpoint
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

        private async Task<List<Address>> GetAddressesAsync()
        {
            return await GetDataCollectionByEndpointAsync<Address>(Settings.DataSource.Endpoints.Addresses);
        }

        private async Task<List<ToDo>> GetToDosAsync()
        {
            return await GetDataCollectionByEndpointAsync<ToDo>(Settings.DataSource.Endpoints.ToDos);
        }

        public async Task<List<User>> GetComplexlyFilledUsers()
        {
            List<User> users = await GetUsersAsync();
            List<Post> posts = await GetPostsAsync();
            List<Comment> comments = await GetCommentsAsync();
            List<Address> addresses = await GetAddressesAsync();
            List<ToDo> todos = await GetToDosAsync();

            posts = (from post in posts
                join comment in comments on post.Id equals comment.PostId into userCommentsGroup
                select new Post()
                {
                    Id = post.Id,
                    UserId = post.UserId,
                    CreatedAt = post.CreatedAt,
                    Title = post.Title,
                    Body = post.Body,
                    Likes = post.Likes,
                    Comments = userCommentsGroup.ToList(),
                }).ToList();

            users = (from user in users
                join post in posts on user.Id equals post.UserId into userPostsGroup
                join todo in todos on user.Id equals todo.UserId into userToDosGroup
                join comment in comments on user.Id equals comment.UserId into userCommentsGroup
                join address in addresses on user.Id equals address.UserId
                select new User()
                {
                    Id = user.Id,
                    CreatedAt = user.CreatedAt,
                    Name = user.Name,
                    Avatar = user.Avatar,
                    Email = user.Email,
                    Address = address,
                    Posts = userPostsGroup.ToList(),
                    Comments = userCommentsGroup.ToList(),
                    ToDos = userToDosGroup.ToList()
                }).ToList();

            return users;
        }
    }
}
