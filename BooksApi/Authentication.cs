using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BooksApi.Authentication
{
    public class JWTSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class AuthenticationResponse
    {      
        public string Email { get; set; }      
        public string JWToken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
        public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
