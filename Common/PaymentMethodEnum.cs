namespace NetCrud2.Common
{
    public enum PaymentMethodEnum
    {
        // For PaymentMethod
        CASH = 1,
        BANK_DEPOSIT = 2,
        CREDITCARD = 3,

        // For OrderStatus
        ORDER_STATUS_CASH_ACTIVE = 10,
        ORDER_STATUS_CASH_INACTIVE = 11,

        ORDER_STATUS_BANK_DEPOSIT_ACTIVE = 12,
        ORDER_STATUS_BANK_DEPOSIT_INACTIVE = 13,

        ORDER_STATUS_CREDITCARD_ACTIVE = 14,
        ORDER_STATUS_CREDITCARD_INACTIVE = 15

    }
}
