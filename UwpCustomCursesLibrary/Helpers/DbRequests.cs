using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UwpCustomCursesLibrary.Models;

namespace UwpCustomCursesLibrary.Helpers
{
    public static class DbRequests
    {
        private static readonly HttpClient Client = new HttpClient();
        public static readonly string WebApiUrl = "https://localhost:5001/db/Users/";

        public static async Task<string> GetUserByUserName(string username)
        {
            var response = await Request(HttpMethod.Get, WebApiUrl, username);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> CreateNewUser(UserDto newUser)
        {
            var jsonUser = JsonSerialization<UserDto>.CreateModel(newUser);
            var response = await Request(HttpMethod.Post, WebApiUrl, jsonUser);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> UpdateUser(UserDto updatedUser)
        {
            var jsonUser = JsonSerialization<UserDto>.CreateModel(updatedUser);
            var response = await Request(HttpMethod.Put, WebApiUrl, jsonUser);
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> DeleteUser(string id)
        {
            var response = await Request(HttpMethod.Get, WebApiUrl, id);
            return await response.Content.ReadAsStringAsync();
        }
        private static async Task<HttpResponseMessage> Request(HttpMethod method, string url, string content = null, Dictionary<string, string> pHeaders = null)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
            };
            if (pHeaders == null)
                pHeaders = new Dictionary<string, string>();
            foreach (var head in pHeaders)
            {
                httpRequestMessage.Headers.Add(head.Key, head.Value);
            }
            switch (method.Method)
            {
                case "GET":
                    httpRequestMessage.RequestUri = new Uri($"{url}name={content}");
                    break;
                case "POST":
                case "PUT":
                case "DELETE":
                    httpRequestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
                    break;
            }

            return await Client.SendAsync(httpRequestMessage);
        }
    }
}
