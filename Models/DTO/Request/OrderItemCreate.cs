using System.ComponentModel.DataAnnotations;

namespace NetCrud2.Models.DTO.Request
{
    public class OrderItemCreate
    {
        //[Required(ErrorMessage = "Units is requied")]
        public string Units { get; set; }

        //[Required(ErrorMessage = "UnitPrice is requied")]
        public string UnitPrice { get; set; }
        //[Required(ErrorMessage = "OrderId is requied")]
        //[StringLength(36, ErrorMessage = "OrderId length maximum 36 characters")]
        public string OrderId { get; set; }
        public string ProductId { get; set; }
    }
}
