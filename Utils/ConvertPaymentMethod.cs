using NetCrud2.Common;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Response;

namespace NetCrud2.Utils
{
    public class ConvertPaymentMethod
    {
        public static string StringArrToIntArr(string str)
        {
            string[] strArr = string.Join(",", str.Distinct().ToArray())
                .Split(",").Select(x => x.Trim().ToLower()).ToArray();

            if (strArr.Length > 3 || strArr.Length < 1)
                throw new Exception("Payment Method required: Min 1 and Max 3");
            string[] result = new string[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                switch (strArr[i])
                {
                    case "cash":
                        PaymentMethodEnum paymentMethodEnum1 = PaymentMethodEnum.CASH;
                        result[i] = ((int) paymentMethodEnum1).ToString();
                        break;
                    case "bank_deposit":
                        PaymentMethodEnum paymentMethodEnum2 = PaymentMethodEnum.BANK_DEPOSIT;
                        result[i] = ((int)paymentMethodEnum2).ToString();
                        break;
                    case "creditcard":
                        PaymentMethodEnum paymentMethodEnum3 = PaymentMethodEnum.CREDITCARD;
                        result[i] = ((int)paymentMethodEnum3).ToString();
                        break;
                    default:
                        throw new Exception("Invalid PaymentMethod, not exist this payment");
                        break;

                } 
                    
            }
            
            return string.Join(",", result);
        }

        public static string intArrToStringArr(string str)
        {
            string[] strArr = str.Split(",").Select(x => x.Trim()).ToArray();
            string[] result = new String[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                PaymentMethodEnum payment = (PaymentMethodEnum)(int.Parse(strArr[i]));
                switch (payment)
                {
                    case PaymentMethodEnum.CASH:
                        result[i] = "CASH";
                        break;
                    case PaymentMethodEnum.CREDITCARD:
                        result[i] = "CREDITCARD";
                        break;
                    case PaymentMethodEnum.BANK_DEPOSIT:
                        result[i] = "BANK_DEPOSIT";
                        break;
                    default:
                        throw new Exception("Not exist this paymentMethod");
                        break;
                }
            }

            return string.Join(",", result);
        }

        public static int convertStatusAndPaymentMethodToStatusOrder(int payment, int status)
        {
            int statusConverted = -1;
            PaymentMethodEnum temp = (PaymentMethodEnum)payment;
            switch (temp)
            {
                case PaymentMethodEnum.CASH:
                    if (status == 1)
                        statusConverted = (int) PaymentMethodEnum.ORDER_STATUS_CASH_ACTIVE;
                    statusConverted = (int)PaymentMethodEnum.ORDER_STATUS_CASH_INACTIVE;
                    break;
                case PaymentMethodEnum.CREDITCARD:
                    if (status == 1)
                        statusConverted = (int)PaymentMethodEnum.ORDER_STATUS_CREDITCARD_ACTIVE;
                    statusConverted = (int)PaymentMethodEnum.ORDER_STATUS_CREDITCARD_INACTIVE;
                    break;
                case PaymentMethodEnum.BANK_DEPOSIT:
                    if (status == 1)
                        statusConverted = (int)PaymentMethodEnum.ORDER_STATUS_BANK_DEPOSIT_ACTIVE;
                    statusConverted = (int)PaymentMethodEnum.ORDER_STATUS_BANK_DEPOSIT_INACTIVE;
                    break;
                default:
                    throw new Exception("Have not payment method");
            }

            return statusConverted;
        }

        public static OrderResponse convertStatusOrderToOrderResponse(OrderResponse response, int statusEntity)
        {
            PaymentMethodEnum temp = (PaymentMethodEnum)statusEntity;
            switch (temp)
            {
                case PaymentMethodEnum.ORDER_STATUS_CREDITCARD_INACTIVE:
                    response.Status = "INACTIVE";
                    response.PaymentMethod = "CREDITCARD";
                    break;
                case PaymentMethodEnum.ORDER_STATUS_CREDITCARD_ACTIVE:
                    response.Status = "ACTIVE";
                    response.PaymentMethod = "CREDITCARD";
                    break;
                case PaymentMethodEnum.ORDER_STATUS_CASH_ACTIVE:
                    response.Status = "ACTIVE";
                    response.PaymentMethod = "CASH";
                    break;
                case PaymentMethodEnum.ORDER_STATUS_CASH_INACTIVE:
                    response.Status = "INACTIVE";
                    response.PaymentMethod = "CASH";
                    break;
                case PaymentMethodEnum.ORDER_STATUS_BANK_DEPOSIT_ACTIVE:
                    response.Status = "ACTIVE";
                    response.PaymentMethod = "BANK_DEPOSIT";
                    break;
                case PaymentMethodEnum.ORDER_STATUS_BANK_DEPOSIT_INACTIVE:
                    response.Status = "INACTIVE";
                    response.PaymentMethod = "BANK_DEPOSIT";
                    break;
                default:
                    throw new Exception("Have not status order valid");
            }
            return response;
        }

        public static int[] convertPaymentMethodStrToStatusOrder(string paymentMethod)
        {
            switch(paymentMethod.Trim().ToLower())
            {
                case "cash":
                    return new int[] { 10, 11 };
                    break;
                case "bank_deposit":
                    return new int[] { 12, 13 };
                    break;
                case "creditcard":
                    return new int[] { 14, 15 };
                    break;
                default:
                    throw new Exception("Have not this payment method");
            }    
        }

    }
}
