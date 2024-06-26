﻿using MarketExpress.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MarketExpress.Models
{
    public class UserPasswordModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter username")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Login")]

        public string Login { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "The email is not valid !")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Enter user profile ")]
        public ProfileEnum? Profile { get; set; }




    }
}
