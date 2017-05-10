using System;
using App.Generators;

namespace App
{
    public class CustomerService
    {
        public bool AddCustomer(string firstName, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            var customer = new CustomerGenerator
            {
                Firstname = firstName,
                Surname = surname,
                Email = email,
                DateOfBirth = dateOfBirth
            }
            .AddCompany(companyId, new CompanyRepository())
            .Generate();
            
            
            /*
             Onur: This logic has to be out from this method
             */

            if (customer.Company.Name == "VeryImportantClient")
            {
                // Skip credit check
                customer.HasCreditLimit = false;
            }
            else if (customer.Company.Name == "ImportantClient")
            {
                // Do credit check and double credit limit
                customer.HasCreditLimit = true;
                using (var customerCreditService = new CustomerCreditServiceClient())
                {
                    var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                    creditLimit = creditLimit*2;
                    customer.CreditLimit = creditLimit;
                }
            }
            else
            {
                // Do credit check
                customer.HasCreditLimit = true;
                using (var customerCreditService = new CustomerCreditServiceClient())
                {
                    var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                    customer.CreditLimit = creditLimit;
                }
            }

            if (customer.HasCreditLimit && customer.CreditLimit < 500)
            {
                return false;
            }

            CustomerDataAccess.AddCustomer(customer);

            return true;
        }
    }
}