using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCrud2.Models
{
    public class OrderItem
    {
        public string Id { get; set; }
        public string Units { get; set; }
        [MaxLength(255)]
        public string UnitsPrice { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public OrderItem()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
