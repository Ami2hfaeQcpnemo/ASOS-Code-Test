using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Generators
{
    public class CompanyCustomerGenerator : CustomerGenerator
    {
        protected internal Company Company { get; set; }

        protected internal CompanyCustomerGenerator(CompanyCustomerGenerator generator) :
            this(generator, generator.Company)
        {
        }

        public CompanyCustomerGenerator(CustomerGenerator generator, Company company)
            : base(generator)
        {
            if (company == null)
                throw new ArgumentException("Company is null");

            Company = company;
        }
        
        public override Customer Generate()
        {
            return new Customer(Firstname, Surname, Email, DateOfBirth, Company);
        }
    }
}
