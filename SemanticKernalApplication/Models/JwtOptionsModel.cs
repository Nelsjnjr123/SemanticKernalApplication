﻿namespace SemanticKernalApplication.WebAPI.Models
{
    public class JwtOptionsModel
    {
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public string SecretKey { get; init; }
    }
}
