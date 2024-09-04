namespace NetCrud2.Models.DTO.Response
{
    public class OrderResponse
    {
        public string Id { get; set; }
        public string CreateDate { get; set; }
        public string Status { get; set; }
        public string BuyerName { get; set; }
        public string PaymentMethod { get; set; }
        public string Address { get; set; }
    }
}
