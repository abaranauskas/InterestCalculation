using InterestCAlculation.Entities;
using InterestCAlculation.Service;
using InterestCAlculation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCAlculation.Controllers
{
    public class HomeController : Controller
    {
        private IBaseRateRepository _baseRateReposirory;
        private ICustomerData _customerData;

        public HomeController(IBaseRateRepository baseRateReposirory,
            ICustomerData customerData)
        {
            _baseRateReposirory = baseRateReposirory;
            _customerData = customerData;
        }

        public IActionResult Index()
        {
            BaseRateCode code = BaseRateCode.VILIBOR1m;

            var rate = _baseRateReposirory.GetRate(code).Result;

            return View(rate);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AgreementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newAgreement = new Agreement();
                newAgreement.Amount = model.Amount;
                newAgreement.AgreementDuration = model.AgreementDuration;
                newAgreement.BaseRateCode = model.BaseRateCode;
                newAgreement.Margin = model.Margin;
                newAgreement.BaseRate = _baseRateReposirory.GetRate(model.BaseRateCode).Result;

                var customer = _customerData.GetAllCustomers().FirstOrDefault(c => c.PersonalId == model.Customer.PersonalId);

                if (customer == null)
                {
                    var newCustomer = new Customer();
                    newCustomer.FirstName = model.Customer.FirstName;
                    newCustomer.LastName = model.Customer.LastName;
                    newCustomer.PersonalId = model.Customer.PersonalId;
                    newCustomer.Agreements.Add(newAgreement);
                    newCustomer = _customerData.Add(newCustomer);
                    _customerData.Save();

                    return RedirectToAction("AgreementDetails", new { id = newCustomer.Agreements.Max(a=>a.Id) });
                }

                customer.Agreements.Add(newAgreement);
                _customerData.Save();

                return RedirectToAction("AgreementDetails", new { id = customer.Agreements.Max(a => a.Id) });
            }

            return View();
        }

        public IActionResult AgreementDetails(int agreementId)
        {
            var agreement = _customerData.GetAllAgreements().Where(a => a.Id == agreementId);

            return View(agreement);
        }
    }
}
