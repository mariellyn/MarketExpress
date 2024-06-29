using MarketExpress.Enums;
using MarketExpress.Helper;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MarketExpress.Models
{
    public class UserModel
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

        [Required(ErrorMessage = "Enter Password")]

        public string PasswordProfile { get; set; }

        public DateTime DateRegistration { get; set; }

        public DateTime? DateChanged { get; set; }

        public bool PasswordValid(string password)
        {
            return PasswordProfile == password.GenerateHash();
        }

        public void SetPasswordHash()
        {
            PasswordProfile = PasswordProfile.GenerateHash();
        }


        public void SetNewPassword(String newPassword)
        {
            PasswordProfile = newPassword.GenerateHash();
        }

        public string GenerateNewPassword()
        {
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            PasswordProfile = newPassword.GenerateHash();
            return newPassword;
        }
    }
}
