namespace BankingApi.Models
{
    public class CustomerDisplayModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PhysicalAddress { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;

        // Bank information
        public int BankId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string BankAddress { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public string ContactPhoneNumber { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public bool IsBankActive { get; set; }
        public string OperatingHours { get; set; } = string.Empty;

        // Customer Type information
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; } = string.Empty;

        // Computed properties
        public string FullName => $"{FirstName} {LastName}";
        public string DisplayAddress => !string.IsNullOrEmpty(PhysicalAddress) ? PhysicalAddress : "Address not provided";
        public string BankContactInfo => $"{ContactPhoneNumber} | {ContactEmail}";

        // Navigation properties
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
