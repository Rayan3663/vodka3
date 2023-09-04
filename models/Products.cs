using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EcommerceApp.models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string url { get; set; }
        [Required]
        public string itemName { get; set; }
        public string description { get; set; }
        [Required]
        public long Cost { get; set; }
        [JsonIgnore]
        public List<Order>  orders { get; set; }
    }
}
