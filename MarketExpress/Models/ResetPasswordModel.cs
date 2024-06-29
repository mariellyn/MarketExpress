using System.ComponentModel.DataAnnotations;

namespace MarketExpress.Models
{
    public class ResetPasswordModel
    {

        [Required(ErrorMessage = "Enter Login ")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter e-mail")]
        public string Email { get; set; }
    }
}
