using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketExpress.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name category")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter description category")]
        public string Description { get; set; } 
    }
}
