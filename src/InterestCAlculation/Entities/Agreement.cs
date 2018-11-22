using System.ComponentModel.DataAnnotations;

namespace InterestCAlculation.Entities
{
    public enum BaseRateCode
    {
        VILIBOR1m,
        VILIBOR3m,
        VILIBOR6m,
        VILIBOR1y
    }

    public class Agreement
    {      

        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }
        [Required]
        [Display(Name = "Agreement Duration")]
        public int AgreementDuration { get; set; }
        [Required]
        public decimal Margin { get; set; }
        [Required]
        [Display(Name = "Base Rate")]
        public BaseRateCode BaseRateCode { get; set; }
        public decimal BaseRate { get; set; }
        public Customer Customer { get; set; }
    }
}