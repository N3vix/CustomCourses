using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Certificates;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using UwpCustomCursesLibrary.Models;
using HttpMethod = Windows.Web.Http.HttpMethod;
using HttpRequestMessage = Windows.Web.Http.HttpRequestMessage;
using HttpResponseMessage = Windows.Web.Http.HttpResponseMessage;
using UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding;

namespace UwpCustomCursesLibrary.Helpers
{
    public static class DbRequests
    {
        private static readonly Windows.Web.Http.HttpClient Client = new Windows.Web.Http.HttpClient(
            new HttpBaseProtocolFilter(){IgnorableServerCertificateErrors =
            {
                ChainValidationResult.Expired,
                ChainValidationResult.Untrusted,
                ChainValidationResult.InvalidName,
                ChainValidationResult.RevocationFailure,
                ChainValidationResult.RevocationInformationMissing,
                ChainValidationResult.WrongUsage,
                ChainValidationResult.IncompleteChain,
            }});
        public static readonly string WebApiUrlUsers = "https://localhost:5001/db/Users/";
        public static readonly string WebApiUrlCourses = "https://localhost:5001/db/Courses/";

        #region Users

        public static async Task<string> GetUserByUserName(string username)
        {
            var response = await Request(Windows.Web.Http.HttpMethod.Get, WebApiUrlUsers, username);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> CreateNewUser(UserDto newUser)
        {
            var jsonUser = JsonSerialization<UserDto>.CreateModel(newUser);
            var response = await Request(Windows.Web.Http.HttpMethod.Post, WebApiUrlUsers, jsonUser);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> UpdateUser(UserDto updatedUser)
        {
            var jsonUser = JsonSerialization<UserDto>.CreateModel(updatedUser);
            var response = await Request(Windows.Web.Http.HttpMethod.Put, WebApiUrlUsers, jsonUser);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> DeleteUser(string id)
        {
            var response = await Request(Windows.Web.Http.HttpMethod.Get, WebApiUrlUsers, id);
            return await response.Content.ReadAsStringAsync();
        }

        #endregion

        #region Courses

        public static async Task<string> GetAllCourses()
        {
            var response = await Request(Windows.Web.Http.HttpMethod.Get, WebApiUrlCourses);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> GetCourseByUserName(string courseName)
        {
            var response = await Request(Windows.Web.Http.HttpMethod.Get, WebApiUrlCourses, courseName);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> CreateNewCourse(Course newCourse)
        {
            var jsonUser = JsonSerialization<Course>.CreateModel(newCourse);
            var response = await Request(Windows.Web.Http.HttpMethod.Post, WebApiUrlCourses, jsonUser);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> UpdateCourse(Course updatedCourse)
        {
            var jsonUser = JsonSerialization<Course>.CreateModel(updatedCourse);
            var response = await Request(Windows.Web.Http.HttpMethod.Put, WebApiUrlCourses, jsonUser);
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> DeleteCourse(string id)
        {
            var response = await Request(HttpMethod.Get, WebApiUrlCourses, id);
            return await response.Content.ReadAsStringAsync();
        }

        #endregion

        private static async Task<HttpResponseMessage> Request(Windows.Web.Http.HttpMethod method, string url, string content = null, Dictionary<string, string> pHeaders = null)
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
                    httpRequestMessage.RequestUri =
                        content == null ?
                        new Uri(url) :
                        new Uri($"{url}name={content}");
                    break;
                case "POST":
                case "PUT":
                case "DELETE":
                    httpRequestMessage.Content = new HttpStringContent(content, UnicodeEncoding.Utf8, "application/json");
                    break;
            }

            return await Client.SendRequestAsync(httpRequestMessage);
        }
    }
}
