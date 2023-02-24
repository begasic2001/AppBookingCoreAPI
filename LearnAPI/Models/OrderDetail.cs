using System.ComponentModel.DataAnnotations;

namespace LearnAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public string Id { get; set; }
        public int quantity { get; set; }
        public double SinglePrice { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
