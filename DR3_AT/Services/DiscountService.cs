namespace DR3_AT.Services;

public class DiscountService
{
    public decimal Calculate10PercentDiscount(decimal originalPrice)
    {
        return originalPrice * 0.9m;
    }
}