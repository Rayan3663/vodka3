using EcommerceApp.models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Dtos
{
    public class sellerDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
