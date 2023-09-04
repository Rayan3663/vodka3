using EcommerceApp.models;

namespace EcommerceApp.Dtos
{
    public class orderDto
    {
        public string address { get; set; }
        public long totalCost { get; set; }
        public string status { get; set; }
        //public User user { get; set; }
        public List<productDto> Products { get; set; }
    }
}
