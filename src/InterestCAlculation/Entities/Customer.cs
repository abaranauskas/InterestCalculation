using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCAlculation.Entities
{
    public class Customer
    {
        public Customer()
        {
            Agreements = new List<Agreement>();
        }

        public int Id { get; set; }

        [Required, MaxLength(11)]
        [Display(Name = "Personal number")]
        public string PersonalId { get; set; }

        [Required, MaxLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public List<Agreement> Agreements { get; set; }
    }
}
