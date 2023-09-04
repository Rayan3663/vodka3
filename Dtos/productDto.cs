using EcommerceApp.models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Dtos
{
    public class productDto
    {
        [Required]
        public string url { get; set; }
        [Required]
        public string itemName { get; set; }
        public string description { get; set; }
        [Required]
        public long Cost { get; set; }
    }
}
