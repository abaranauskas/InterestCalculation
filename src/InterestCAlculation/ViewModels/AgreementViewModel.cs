using InterestCAlculation.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCAlculation.ViewModels
{
    public class AgreementViewModel
    {
        public decimal Amount { get; set; }
        [Required]       
        public int AgreementDuration { get; set; }
        [Required]
        public decimal Margin { get; set; }
        [Required]        
        public BaseRateCode BaseRateCode { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}
