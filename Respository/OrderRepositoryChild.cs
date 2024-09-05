using NetCrud2.Models.DTO.Response;

namespace NetCrud2.Respository
{
    public interface OrderRepositoryChild
    {
        FindOrderResponse findOrderByPaymentMethodAndDate(string paymentMethod, DateTime start, DateTime end);
    }
}
