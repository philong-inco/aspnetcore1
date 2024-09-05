using System.ComponentModel.DataAnnotations;

namespace NetCrud2.Models.DTO.Request
{
    public class OrderCreate
    {
        //[Required(ErrorMessage = "CreateDate is requied")]
        public string CreateDate { get; set; }
        public int Status {  get; set; }

        public string PaymentMethod { get; set; }
        //[Required(ErrorMessage = "BuyerId is requied")]
        //[StringLength(36, ErrorMessage = "BuyerId length maximum 36 characters")]
        public string BuyerId { get; set; }
        //[Required(ErrorMessage = "Address is requied")]
        //[StringLength(100, ErrorMessage = "Address Method length maximum 100 characters")]
        public string Address { get; set; }
    }
}
