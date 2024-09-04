using NetCrud2.Models;
using System.Linq.Expressions;

namespace NetCrud2.Utils
{
    public class UtilExpression
    {
        public static Expression<Func<Buyer, bool>> checkConditionalBuyer(Expression<Func<Buyer, bool>> filter, string column, string value)
        {
            switch (column.ToLower())
            {
                case "id":
                    filter = x => x.Id.ToString().Equals(value.ToLower());
                    break;
                case "name":
                    filter = x => x.Name.ToLower().Contains(value.ToLower());
                    break;
                case "paymentmethod":
                    filter = x => x.PaymentMethod.ToLower().Contains(value.ToLower());
                    break;
                default:
                    filter = null;
                    break;
            }
            return filter;
        }

        public static Expression<Func<Order, bool>> checkConditionalOrder(Expression<Func<Order, bool>> filter, string column, string value)
        {
            switch (column.ToLower())
            {
                case "id":
                    filter = x => x.Id.ToString().Equals(value.ToLower());
                    break;
                case "status":
                    filter = x => x.Status.ToString().Equals(value.ToLower());
                    break;
                case "address":
                    filter = x => x.Address.ToLower().Contains(value.ToLower());
                    break;
                case "buyerid":
                    filter = x => x.BuyerId.ToLower().Contains(value.ToLower());
                    break;
                default:
                    filter = null;
                    break;
            }
            return filter;
        }

        public static Expression<Func<OrderItem, bool>> checkConditionalOrderItem(Expression<Func<OrderItem, bool>> filter, string column, string value)
        {
            switch (column.ToLower())
            {
                case "id":
                    filter = x => x.Id.ToString().Equals(value.ToLower());
                    break;
                case "units":
                    filter = x => x.Units.ToLower().Contains(value.ToLower());
                    break;
                case "unitsprice":
                    filter = x => x.UnitsPrice.ToLower().Contains(value.ToLower());
                    break;
                case "orderid":
                    filter = x => x.OrderId.ToLower().Contains(value.ToLower());
                    break;
                case "productid":
                    filter = x => x.ProductId.ToLower().Contains(value.ToLower());
                    break;
                default:
                    filter = null;
                    break;
            }
            return filter;
        }
    }
}
