using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Models
{
    public class Category 
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        public string Name { get; set; }
        ////Relationships
        public List<CarProduct> CarProducts { get; set; }
    }
}
