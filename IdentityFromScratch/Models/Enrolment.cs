namespace IdentityFromScratch.Models;

public class Enrolment
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrolmentDate { get; set; }
    
    public DateTime PaymentDate { get; set; }
    
    public decimal GrossAmount { get; set; }
    
    public decimal NetAmount { get; set; }
    
    public decimal VATAmount { get; set; }
    
    public PaymentProvider PaymentProvider { get; set; }

    public string PaymentProviderPaymentId { get; set; }

    public string PaymentProviderPayerId { get; set; }

    public PaymentStatus PaymentStatus { get; set; }
    
    public Member Member { get; set; }
    
    public Course Course { get; set; }

}