using NetCrud2.Models.DTO.Response;

namespace NetCrud2.Service
{
    public interface OrderServiceChild
    {

        FindOrderResponse findOrderByPaymentMethodAndDate(string paymentMethod, DateTime start, DateTime end);
    }
}
