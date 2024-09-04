using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCrud2.Models
{
    public class Buyer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PaymentMethod { get; set; }
        public Buyer()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
