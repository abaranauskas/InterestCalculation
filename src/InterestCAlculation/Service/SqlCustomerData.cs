using InterestCAlculation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCAlculation.Service
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Agreement> GetAllAgreements();
        Customer GetById(int personalId);
        Customer Add(Customer newCustomer);
        void Save();
    }

    public class SqlCustomerData : ICustomerData
    {
        private InterestCalculationDbContext _context;

        public SqlCustomerData(InterestCalculationDbContext context)
        {
            _context = context;
        }

        public Customer Add(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            return newCustomer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public IEnumerable<Agreement> GetAllAgreements()
        {
            return _context.Agreements.ToList();
        }

        public Customer GetById(int personalId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
