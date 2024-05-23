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


        [Required(ErrorMessage = "The category name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The category description is required.")]
        public string Description { get; set; }
    }
}
