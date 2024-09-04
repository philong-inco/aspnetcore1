using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCrud2.Models
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public string Address { get; set; }
        public string BuyerId { get; set; }
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
