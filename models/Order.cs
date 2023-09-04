using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceApp.models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public long totalCost { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        [JsonIgnore]
        public User user { get; set; }
        [JsonIgnore]
        public List<Products> Products { get; set; }

    }
}
