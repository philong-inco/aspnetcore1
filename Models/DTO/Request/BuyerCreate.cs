using System.ComponentModel.DataAnnotations;

namespace NetCrud2.Models.DTO.Request
{
    public class BuyerCreate
    {
        //[Required(ErrorMessage = "Name is requied")]
        //[StringLength(100, ErrorMessage = "Name length maximum 100 character")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "PaymentMethod is requied")]
        //[StringLength(100, ErrorMessage = "PaymentMethod length maximum 100 character")]
        public string PaymentMethod { get; set; }

    }
}
