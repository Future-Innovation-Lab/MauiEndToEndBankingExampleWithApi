using System.Collections.Generic;

namespace MauiBankingExercise.Models
{
    public class CustomerDisplayModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string IdentityNumber { get; set; }
        public string Nationality { get; set; }

        // Bank information
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string BranchCode { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public bool IsBankActive { get; set; }
        public string OperatingHours { get; set; }

        // Customer Type information
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }

        // Additional computed properties
        public string FullName => $"{FirstName} {LastName}";
        public string DisplayAddress => !string.IsNullOrEmpty(PhysicalAddress) ? PhysicalAddress : "Address not provided";
        public string BankContactInfo => $"{ContactPhoneNumber} | {ContactEmail}";

        // Navigation properties for additional data if needed
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}