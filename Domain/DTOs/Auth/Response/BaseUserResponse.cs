﻿using Domain.DTOs.Base.Response;
using Domain.Enums;

namespace Domain.DTOs.Auth.Response
{
    public class BaseUserResponse : BaseResponse
    {
        public string? UserName { get; set; }
        public string? PersonId { get; set; }
        public string? UserId { get; set; }
        public AccessLevel UserAccessLevel { get; set; }
        public string? FullName { get; set; }
        public string? NationalNo { get; set; }
    }
}
