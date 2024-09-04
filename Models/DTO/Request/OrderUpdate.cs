using System.ComponentModel.DataAnnotations;

namespace NetCrud2.Models.DTO.Request
{
    public class OrderUpdate
    {
        //[Required(ErrorMessage = "ID is requied")]
        //[StringLength(36, ErrorMessage = "ID length maximum 36 characters")]
        public string Id { get; set; }

        //[Required(ErrorMessage = "CreateDate is requied")]
        public string CreateDate { get; set; }

        //[Required(ErrorMessage = "Status is requied")]
        //[Range(0,5, ErrorMessage = "Order status in range 0-5")]
        public int Status { get; set; }

        //[Required(ErrorMessage = "BuyerId is requied")]
        //[StringLength(36, ErrorMessage = "BuyerId length maximum 36 characters")]
        public string BuyerId { get; set; }

        //[Required(ErrorMessage = "Address is requied")]
        //[StringLength(100, ErrorMessage = "Address length maximum 100 characters")]
        public string Address { get; set; }
    }
}
