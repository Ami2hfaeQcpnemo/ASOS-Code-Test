using System;

namespace App
{
    public class Customer
    {
        #region Properties
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public bool HasCreditLimit { get; set; }

        public int CreditLimit { get; set; }

        public Company Company { get; set; }
        #endregion

        #region Constructors
        public Customer(string firstName, string surname, string email, DateTime dateOfBirth)
        {

            if (!ValidateName(firstName))
                throw new ArgumentException("FirstName is invalid");

            if (!ValidateName(surname))
                throw new ArgumentException("Surname is invalid");

            if (!ValidateEmail(email))
                throw new ArgumentException("Email is invalid");

            if (!ValidateAge(dateOfBirth))
                throw new ArgumentException("Date of Birth is invalid");

            DateOfBirth = dateOfBirth;
            EmailAddress = email;
            Firstname = firstName;
            Surname = surname;
        }

        public Customer(string firstName, string surname, string email, DateTime dateOfBirth, Company company)
            : this(firstName, surname, email, dateOfBirth)
        {
            if (!ValidateCompany(company))
                throw new ArgumentException("Company is invalid");

            Company = company;
        } 
        #endregion

        #region Validate Functions
        public static bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name);
        }

        public static bool ValidateEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains(".");
        }

        public static bool ValidateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
                age--;

            return age >= 21;
        }

        public static bool ValidateCompany(Company company)
        {
            return company != null;
        }

        //public static bool ValidateCreditLimit(bool hasCreditLimit, int creditLimit)
        public static bool ValidateCreditLimit(bool hasCreditLimit)
        {
            return !hasCreditLimit;
            //return !hasCreditLimit || (creditLimit >= LowerLimit);
        }

        #endregion
    }
}