using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Interfaces;

namespace App.Generators
{
    public class CustomerGenerator : ICustomerGenerator
    {
        #region Properties
        protected internal string Firstname { get; set; }
        protected internal string Surname { get; set; }
        protected internal string Email { get; set; }
        protected internal DateTime DateOfBirth { get; set; }
        #endregion

        public CustomerGenerator()
        {
            
        }
        public CustomerGenerator(CustomerGenerator generator)
        {
            DateOfBirth = generator.DateOfBirth;
            Email = generator.Email;
            Firstname = generator.Firstname;
            Surname = generator.Surname;
        }

        public CompanyCustomerGenerator AddCompany(int companyId, ICompanyRepository repository)
        {
            if (repository == null)
                throw new ArgumentException("Company repository is null");

            Company company;
            if (!repository.Get(companyId, out company))
                throw new ArgumentException("Problem with company id");

            return new CompanyCustomerGenerator(this, company);
        }

        public virtual Customer Generate()
        {
            return new Customer(Firstname, Surname, Email, DateOfBirth);
        }
    }
}
