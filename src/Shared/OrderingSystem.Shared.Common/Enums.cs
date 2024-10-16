namespace OrderingSystem.Shared.Common
{
    public enum OrderStatus : short
    {
        Pending = 1,
        Shipped = 2,
        Delivered = 3,
        Cancelled = 4
    }

    // Enum for Payment Status
    public enum PaymentStatus : short
    {
        Unknown = 0,
        Pending = 1,
        Completed = 2,
        Failed = 3
    }

    public enum UserType : short
    {
        Unknown = 0,
        Customer = 1,
        Admin = 2
    }
}