namespace IdentityFromScratch.Models;

public class EnrolementSignUp
{
    public string ForeName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string CourseId { get; set; }

    public decimal NetPrice { get; set; }

    public decimal VAT { get; set; }
    
    public decimal TotalPrice { get; set; }

    public string CouponCode { get; set; }

    public PaymentProvider PaymentProvider { get; set; }

    public string PaymentId { get; set; }

    public string ReturnUrl { get; set; }

    public string CancelUrl { get; set; } 
}