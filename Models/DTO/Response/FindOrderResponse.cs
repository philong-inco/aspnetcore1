using System.ComponentModel.DataAnnotations.Schema;

namespace NetCrud2.Models.DTO.Response
{
    public class FindOrderResponse
    {
        [Column("o_order_count")]
        public int countOrderId { get; set; }
        [Column("o_buyer_count")]
        public int countBuyerUsedPaymentMethod { get; set; }
        [Column("o_total_payment")]
        public decimal moneyTotal { get; set; }
        [Column("o_max_payment_buyer")]
        public string buyerUsedMax { get; set; }
        [Column("o_min_payment_buyer")]
        public string buyerUsedMin { get; set; }
    }
}
