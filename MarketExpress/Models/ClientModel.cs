using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketExpress.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Write the customer's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Write email")]
        [EmailAddress(ErrorMessage = "The email is not valid !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Write Phone")]
        [Phone(ErrorMessage = "The email is not valid !")]
        public string Phone { get; set; }

        public string BirthDate { get; set; }

       
        public string Adress { get; set; }

        public string Locality { get; set; }

        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Write NIF")]
       
        public string NIF { get; set; }

        [Required(ErrorMessage = "Write customer number ")]
        public string CustumerNumber { get; set; }


    }
}
