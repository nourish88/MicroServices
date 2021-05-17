using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]// responseun bodysinde gönderme ama bana kodlamada lazım. Zaten responseun bodysinde var 200 400 falan
        public int StatusCode { get; private set; }
        [JsonIgnore]//sadece yazılım içinde kullancam body de olmayacak. 
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; set; }

        //Static Favtory Metodlar
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true };
        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                Data = default(T),
                IsSuccessful = false
            };
        }
        public static Response<T> Fail(string errors, int statusCode)
        {
            return new Response<T>
            {
                Errors = new List<string> { errors },
                StatusCode = statusCode,
                Data = default(T),
                IsSuccessful = false
            };
        }
    }
}
