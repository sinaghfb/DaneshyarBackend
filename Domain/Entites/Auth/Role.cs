﻿using Domain.Entites.Base;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites.Auth
{
    public class Role:BaseEntity
    {
        public Role()
        {
            TheUsers = new List<User>();
        }
        [Required]
        public string? FarsiTitle { get; set; }
        [Required]
        public string? EnglishTitle { get; set; }
        [Required]
        public AccessLevel UserAccessLevel { get; set; }
        public List<User> TheUsers { get; set; }
    }
}
