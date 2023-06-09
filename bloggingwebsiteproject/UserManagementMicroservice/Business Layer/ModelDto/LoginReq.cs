﻿using System.ComponentModel.DataAnnotations;

namespace bloggingwebsiteproject.UserManagementManagement.Business_Layer.ModelDto
{
    public class LoginReq
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

    }
}
