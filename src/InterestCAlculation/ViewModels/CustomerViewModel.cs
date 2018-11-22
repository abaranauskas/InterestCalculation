using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCAlculation.ViewModels
{
    public class CustomerViewModel
    {
        [Required, MaxLength(11)]       
        public string PersonalId { get; set; }

        [Required, MaxLength(25)]        
        public string FirstName { get; set; }

        [Required, MaxLength(25)]        
        public string LastName { get; set; }
    }
}
