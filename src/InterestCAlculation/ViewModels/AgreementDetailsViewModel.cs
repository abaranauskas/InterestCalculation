using InterestCAlculation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCAlculation.ViewModels
{
    public class AgreementDetailsViewModel
    {
        public Customer Customer { get; set; }
        public Agreement Agreement { get; set; }
    }
}
