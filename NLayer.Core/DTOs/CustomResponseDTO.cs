﻿using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDTO<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CustomResponseDTO<T> Success(int statusCode, T data)
        {
            return new CustomResponseDTO<T> { Data = data, StatusCode = statusCode, Errors = null };
        }

        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode };
        }

        public static CustomResponseDTO<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDTO<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
