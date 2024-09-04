using System.ComponentModel.DataAnnotations;

namespace NetCrud2.Models.DTO.Request
{
    public class BuyerUpdate
    {
        //[Required(ErrorMessage = "ID is requied")]
        //[StringLength(36, ErrorMessage = "ID length maximum 36 characters")]
        public string Id { get; set; }
        //[Required(ErrorMessage = "Name is requied")]
        //[StringLength(100, ErrorMessage = "Name length maximum 100 characters")]

        public string Name { get; set; }
        //[Required(ErrorMessage = "Name is requied")]
        //[StringLength(100, ErrorMessage = "Payment Method length maximum 100 characters")]
        public string PaymentMethod { get; set; }
    }
}
