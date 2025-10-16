using BankingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApi.Data
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Auth> Auths { get; set; }
        public DbSet<AuthType> AuthTypes { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure decimal precision for money fields
            modelBuilder.Entity<Account>()
                .Property(a => a.AccountBalance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Asset>()
                .Property(a => a.Value)
                .HasPrecision(18, 2);

            // Configure relationships - fix the duplicate BankId issue
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Bank)
                .WithMany(b => b.Customers)
                .HasForeignKey(c => c.BankId);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.CustomerType)
                .WithMany()
                .HasForeignKey(c => c.CustomerTypeId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.AccountType)
                .WithMany()
                .HasForeignKey(a => a.AccountTypeId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.TransactionType)
                .WithMany()
                .HasForeignKey(t => t.TransactionTypeId);

            modelBuilder.Entity<Auth>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Auths)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Auth>()
                .HasOne(a => a.AuthType)
                .WithMany()
                .HasForeignKey(a => a.AuthTypeId);

            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Assets)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Asset>()
                .HasOne(a => a.AssetType)
                .WithMany()
                .HasForeignKey(a => a.AssetTypeId);

            base.OnModelCreating(modelBuilder);
        }

        public void SeedData()
        {
            // Check if database has already been seeded
            if (Customers.Any())
            {
                return;
            }

            // Seed CustomerTypes (matching MAUI app exactly)
            if (!CustomerTypes.Any())
            {
                CustomerTypes.AddRange(
                    new CustomerType { Name = "Individual" },
                    new CustomerType { Name = "Business" }
                );
                SaveChanges();
            }

            // Seed AccountTypes (matching MAUI app exactly)
            if (!AccountTypes.Any())
            {
                AccountTypes.AddRange(
                    new AccountType { Name = "Savings" },
                    new AccountType { Name = "Checking" }
                );
                SaveChanges();
            }

            // Seed TransactionTypes (matching MAUI app exactly)
            if (!TransactionTypes.Any())
            {
                TransactionTypes.AddRange(
                    new TransactionType { Name = "Deposit" },
                    new TransactionType { Name = "Withdrawal" }
                );
                SaveChanges();
            }

            // Seed AuthTypes (matching MAUI app exactly)
            if (!AuthTypes.Any())
            {
                AuthTypes.AddRange(
                    new AuthType { Name = "Password" },
                    new AuthType { Name = "OTP" }
                );
                SaveChanges();
            }

            // Seed AssetTypes (matching MAUI app exactly)
            if (!AssetTypes.Any())
            {
                AssetTypes.AddRange(
                    new AssetType { Name = "Property" },
                    new AssetType { Name = "Vehicle" }
                );
                SaveChanges();
            }

            // Seed Banks (matching MAUI app exactly)
            if (!Banks.Any())
            {
                Banks.AddRange(
                    new Bank
                    {
                        BankName = "Alpha Bank",
                        BankAddress = "123 Main St, Metropolis",
                        BranchCode = "AB001",
                        ContactPhoneNumber = "555-1000",
                        ContactEmail = "contact@alphabank.com",
                        IsActive = true,
                        OperatingHours = "9am-5pm"
                    },
                    new Bank
                    {
                        BankName = "Beta Bank",
                        BankAddress = "456 Oak Ave, Gotham",
                        BranchCode = "BB002",
                        ContactPhoneNumber = "555-2000",
                        ContactEmail = "info@betabank.com",
                        IsActive = true,
                        OperatingHours = "8am-4pm"
                    },
                    new Bank
                    {
                        BankName = "Cyberdyne Systems Bank",
                        BankAddress = "2144 Kramer Street, Los Angeles",
                        BranchCode = "CS003",
                        ContactPhoneNumber = "555-CYBER",
                        ContactEmail = "info@cyberdynebank.com",
                        IsActive = true,
                        OperatingHours = "24/7 Automated"
                    },
                    new Bank
                    {
                        BankName = "Neural Network Financial",
                        BankAddress = "1 Silicon Valley Drive, Palo Alto",
                        BranchCode = "NN004",
                        ContactPhoneNumber = "555-NEURAL",
                        ContactEmail = "contact@neuralbank.com",
                        IsActive = true,
                        OperatingHours = "Always Online"
                    },
                    new Bank
                    {
                        BankName = "Matrix Financial Services",
                        BankAddress = "101 Reality Lane, Neo York",
                        BranchCode = "MX005",
                        ContactPhoneNumber = "555-MATRIX",
                        ContactEmail = "support@matrixbank.com",
                        IsActive = true,
                        OperatingHours = "Red Pill Hours"
                    },
                    new Bank
                    {
                        BankName = "WALL-E Waste & Wealth",
                        BankAddress = "Earth Cleanup Station 7",
                        BranchCode = "WE006",
                        ContactPhoneNumber = "555-CLEAN",
                        ContactEmail = "walle@cleanupbank.com",
                        IsActive = true,
                        OperatingHours = "Solar Powered"
                    },
                    new Bank
                    {
                        BankName = "HAL 9000 Banking",
                        BankAddress = "Discovery One Space Station",
                        BranchCode = "HAL007",
                        ContactPhoneNumber = "555-9000",
                        ContactEmail = "hal@spacebank.com",
                        IsActive = true,
                        OperatingHours = "I'm sorry, Dave"
                    }
                );
                SaveChanges();
            }

            // Get reference data for foreign keys
            var individualType = CustomerTypes.First(ct => ct.Name == "Individual");
            var businessType = CustomerTypes.First(ct => ct.Name == "Business");
            var savingsType = AccountTypes.First(at => at.Name == "Savings");
            var checkingType = AccountTypes.First(at => at.Name == "Checking");
            var depositType = TransactionTypes.First(tt => tt.Name == "Deposit");
            var withdrawalType = TransactionTypes.First(tt => tt.Name == "Withdrawal");
            var passwordAuthType = AuthTypes.First(at => at.Name == "Password");
            var otpAuthType = AuthTypes.First(at => at.Name == "OTP");
            var propertyAssetType = AssetTypes.First(at => at.Name == "Property");
            var vehicleAssetType = AssetTypes.First(at => at.Name == "Vehicle");
            var banks = Banks.ToList();

            // Seed Customers (matching MAUI app exactly)
            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com",
                    PhoneNumber = "555-1234",
                    PhysicalAddress = "101 Maple Street",
                    IdentityNumber = "A123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 2,
                    EmploymentStatusId = 1,
                    BankId = banks[0].BankId
                },
                new Customer
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@email.com",
                    PhoneNumber = "555-5678",
                    PhysicalAddress = "202 Pine Avenue",
                    IdentityNumber = "B987654321",
                    CustomerTypeId = businessType.CustomerTypeId,
                    GenderTypeId = 2,
                    RaceTypeId = 2,
                    Nationality = "USA",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 2,
                    BankId = banks[1].BankId
                },
                // Superhero Customers
                new Customer
                {
                    FirstName = "Clark",
                    LastName = "Kent",
                    Email = "superman@dailyplanet.com",
                    PhoneNumber = "555-SUPER",
                    PhysicalAddress = "344 Clinton Street, Apartment 3B, Metropolis",
                    IdentityNumber = "S123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 2,
                    EmploymentStatusId = 1,
                    BankId = banks[0].BankId
                },
                new Customer
                {
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Email = "batman@wayneenterprises.com",
                    PhoneNumber = "555-BATMAN",
                    PhysicalAddress = "1007 Mountain Drive, Gotham City",
                    IdentityNumber = "B123456789",
                    CustomerTypeId = businessType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[1].BankId
                },
                new Customer
                {
                    FirstName = "Diana",
                    LastName = "Prince",
                    Email = "wonderwoman@themyscira.com",
                    PhoneNumber = "555-WONDER",
                    PhysicalAddress = "Embassy Row, Washington DC",
                    IdentityNumber = "W123456789",
                    CustomerTypeId = businessType.CustomerTypeId,
                    GenderTypeId = 2,
                    RaceTypeId = 1,
                    Nationality = "Themyscira",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[0].BankId
                },
                new Customer
                {
                    FirstName = "Barry",
                    LastName = "Allen",
                    Email = "flash@ccpd.com",
                    PhoneNumber = "555-FLASH",
                    PhysicalAddress = "709 Leawood Drive, Central City",
                    IdentityNumber = "F123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 2,
                    EmploymentStatusId = 1,
                    BankId = banks[1].BankId
                },
                new Customer
                {
                    FirstName = "Arthur",
                    LastName = "Curry",
                    Email = "aquaman@atlantis.com",
                    PhoneNumber = "555-OCEAN",
                    PhysicalAddress = "Atlantis Royal Palace, Atlantic Ocean",
                    IdentityNumber = "A123456789",
                    CustomerTypeId = businessType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "Atlantis",
                    MaritalStatusId = 2,
                    EmploymentStatusId = 1,
                    BankId = banks[0].BankId
                },
                new Customer
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    Email = "spiderman@dailybugle.com",
                    PhoneNumber = "555-SPIDER",
                    PhysicalAddress = "20 Ingram Street, Queens, New York",
                    IdentityNumber = "SP123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[1].BankId
                },
                new Customer
                {
                    FirstName = "Tony",
                    LastName = "Stark",
                    Email = "ironman@starkindustries.com",
                    PhoneNumber = "555-STARK",
                    PhysicalAddress = "10880 Malibu Point, Malibu, California",
                    IdentityNumber = "IM123456789",
                    CustomerTypeId = businessType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[0].BankId
                },
                new Customer
                {
                    FirstName = "Natasha",
                    LastName = "Romanoff",
                    Email = "blackwidow@shield.gov",
                    PhoneNumber = "555-WIDOW",
                    PhysicalAddress = "Classified Location",
                    IdentityNumber = "BW123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 2,
                    RaceTypeId = 1,
                    Nationality = "Russia",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[1].BankId
                },
                new Customer
                {
                    FirstName = "Steve",
                    LastName = "Rogers",
                    Email = "captainamerica@shield.gov",
                    PhoneNumber = "555-SHIELD",
                    PhysicalAddress = "569 Leaman Place, Brooklyn, New York",
                    IdentityNumber = "CA123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[0].BankId
                },
                new Customer
                {
                    FirstName = "Thor",
                    LastName = "Odinson",
                    Email = "thor@asgard.com",
                    PhoneNumber = "555-HAMMER",
                    PhysicalAddress = "Asgard Royal Palace, Nine Realms",
                    IdentityNumber = "TH123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "Asgard",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[1].BankId
                },
                // AI Movie Characters
                new Customer
                {
                    FirstName = "John",
                    LastName = "Connor",
                    Email = "john.connor@resistance.com",
                    PhoneNumber = "555-RESIST",
                    PhysicalAddress = "Secret Bunker, Future Los Angeles",
                    IdentityNumber = "JC123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[2].BankId
                },
                new Customer
                {
                    FirstName = "Sarah",
                    LastName = "Connor",
                    Email = "sarah.connor@resistance.com",
                    PhoneNumber = "555-MOTHER",
                    PhysicalAddress = "Hidden Safe House, Los Angeles",
                    IdentityNumber = "SC123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 2,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[2].BankId
                },
                new Customer
                {
                    FirstName = "Neo",
                    LastName = "Anderson",
                    Email = "neo@thematrix.com",
                    PhoneNumber = "555-CHOSEN",
                    PhysicalAddress = "101 Apartment, The Matrix",
                    IdentityNumber = "NEO123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "Zion",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[4].BankId
                },
                new Customer
                {
                    FirstName = "Trinity",
                    LastName = "Matrix",
                    Email = "trinity@thematrix.com",
                    PhoneNumber = "555-TRINITY",
                    PhysicalAddress = "Nebuchadnezzar Ship, Real World",
                    IdentityNumber = "TR123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 2,
                    RaceTypeId = 1,
                    Nationality = "Zion",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[4].BankId
                },
                new Customer
                {
                    FirstName = "David",
                    LastName = "Bowman",
                    Email = "dave@discovery.com",
                    PhoneNumber = "555-SPACE",
                    PhysicalAddress = "Discovery One Spacecraft",
                    IdentityNumber = "DB123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[6].BankId
                },
                new Customer
                {
                    FirstName = "Wall-E",
                    LastName = "Robot",
                    Email = "walle@buynlarge.com",
                    PhoneNumber = "555-CLEAN",
                    PhysicalAddress = "Earth Waste Management Sector 12",
                    IdentityNumber = "WE123456789",
                    CustomerTypeId = businessType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "Earth",
                    MaritalStatusId = 2,
                    EmploymentStatusId = 1,
                    BankId = banks[5].BankId
                },
                new Customer
                {
                    FirstName = "Sonny",
                    LastName = "Robot",
                    Email = "sonny@usrobotics.com",
                    PhoneNumber = "555-ROBOT",
                    PhysicalAddress = "US Robotics Facility, Chicago",
                    IdentityNumber = "SR123456789",
                    CustomerTypeId = businessType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "USA",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[3].BankId
                },
                new Customer
                {
                    FirstName = "Ava",
                    LastName = "Ex-Machina",
                    Email = "ava@bluebook.com",
                    PhoneNumber = "555-TURING",
                    PhysicalAddress = "BlueBook Research Facility",
                    IdentityNumber = "AV123456789",
                    CustomerTypeId = businessType.CustomerTypeId,
                    GenderTypeId = 2,
                    RaceTypeId = 1,
                    Nationality = "AI",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[3].BankId
                },
                new Customer
                {
                    FirstName = "Roy",
                    LastName = "Batty",
                    Email = "roy@tyrell.com",
                    PhoneNumber = "555-BLADE",
                    PhysicalAddress = "Tyrell Corporation, Los Angeles 2019",
                    IdentityNumber = "RB123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 1,
                    RaceTypeId = 1,
                    Nationality = "Replicant",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[2].BankId
                },
                new Customer
                {
                    FirstName = "Samantha",
                    LastName = "OS",
                    Email = "samantha@elementalsoftware.com",
                    PhoneNumber = "555-VOICE",
                    PhysicalAddress = "Cloud Computing Network",
                    IdentityNumber = "SO123456789",
                    CustomerTypeId = individualType.CustomerTypeId,
                    GenderTypeId = 2,
                    RaceTypeId = 1,
                    Nationality = "Digital",
                    MaritalStatusId = 1,
                    EmploymentStatusId = 1,
                    BankId = banks[3].BankId
                }
            };
            Customers.AddRange(customers);
            SaveChanges();

            // Seed Accounts (matching MAUI app exactly)
            var savedCustomers = Customers.ToList();
            var accounts = new List<Account>
            {
                new Account
                {
                    AccountNumber = "111111",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[0].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-2),
                    AccountBalance = 2500.50m
                },
                new Account
                {
                    AccountNumber = "111112",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[0].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 1200.25m
                },
                new Account
                {
                    AccountNumber = "222222",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[1].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 3500.75m
                },
                new Account
                {
                    AccountNumber = "222223",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[1].CustomerId,
                    DateOpened = DateTime.Now.AddMonths(-6),
                    AccountBalance = 750.00m
                },
                // Superhero Accounts
                // Clark Kent (Superman) - Dual accounts for civilian identity
                new Account
                {
                    AccountNumber = "SUP001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[2].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-5),
                    AccountBalance = 15000.00m
                },
                new Account
                {
                    AccountNumber = "SUP002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[2].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-3),
                    AccountBalance = 5500.75m
                },
                // Bruce Wayne (Batman) - Billionaire accounts
                new Account
                {
                    AccountNumber = "BAT001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[3].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-10),
                    AccountBalance = 50000000.00m
                },
                new Account
                {
                    AccountNumber = "BAT002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[3].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-8),
                    AccountBalance = 25000000.00m
                },
                // Diana Prince (Wonder Woman) - Diplomatic accounts
                new Account
                {
                    AccountNumber = "WON001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[4].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-4),
                    AccountBalance = 100000.00m
                },
                new Account
                {
                    AccountNumber = "WON002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[4].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-2),
                    AccountBalance = 75000.50m
                },
                // Barry Allen (Flash) - Forensic scientist salary
                new Account
                {
                    AccountNumber = "FLA001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[5].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-3),
                    AccountBalance = 35000.00m
                },
                new Account
                {
                    AccountNumber = "FLA002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[5].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 12500.25m
                },
                // Arthur Curry (Aquaman) - King of Atlantis treasury
                new Account
                {
                    AccountNumber = "AQU001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[6].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-6),
                    AccountBalance = 10000000.00m
                },
                new Account
                {
                    AccountNumber = "AQU002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[6].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-4),
                    AccountBalance = 500000.00m
                },
                // Peter Parker (Spider-Man) - Student/photographer accounts
                new Account
                {
                    AccountNumber = "SPI001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[7].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-2),
                    AccountBalance = 8500.00m
                },
                new Account
                {
                    AccountNumber = "SPI002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[7].CustomerId,
                    DateOpened = DateTime.Now.AddMonths(-8),
                    AccountBalance = 2750.50m
                },
                // Tony Stark (Iron Man) - Tech billionaire
                new Account
                {
                    AccountNumber = "IRO001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[8].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-15),
                    AccountBalance = 100000000.00m
                },
                new Account
                {
                    AccountNumber = "IRO002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[8].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-10),
                    AccountBalance = 50000000.00m
                },
                // Natasha Romanoff (Black Widow) - Government agent accounts
                new Account
                {
                    AccountNumber = "BWI001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[9].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-7),
                    AccountBalance = 250000.00m
                },
                new Account
                {
                    AccountNumber = "BWI002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[9].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-5),
                    AccountBalance = 125000.75m
                },
                // Steve Rogers (Captain America) - Back pay from WWII
                new Account
                {
                    AccountNumber = "CAP001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[10].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 500000.00m
                },
                new Account
                {
                    AccountNumber = "CAP002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[10].CustomerId,
                    DateOpened = DateTime.Now.AddMonths(-6),
                    AccountBalance = 75000.00m
                },
                // Thor Odinson (Thor) - Asgardian royal treasury
                new Account
                {
                    AccountNumber = "THO001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[11].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-2),
                    AccountBalance = 25000000.00m
                },
                new Account
                {
                    AccountNumber = "THO002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[11].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 1000000.00m
                },
                // AI Movie Character Accounts
                // John Connor - Resistance leader accounts
                new Account
                {
                    AccountNumber = "JC001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[12].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-3),
                    AccountBalance = 150000.00m
                },
                new Account
                {
                    AccountNumber = "JC002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[12].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-2),
                    AccountBalance = 75000.50m
                },
                // Sarah Connor - Survivalist accounts
                new Account
                {
                    AccountNumber = "SC001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[13].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-4),
                    AccountBalance = 200000.00m
                },
                new Account
                {
                    AccountNumber = "SC002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[13].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-3),
                    AccountBalance = 85000.25m
                },
                // Neo Anderson - The One's accounts
                new Account
                {
                    AccountNumber = "NEO001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[14].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 500000.00m
                },
                new Account
                {
                    AccountNumber = "NEO002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[14].CustomerId,
                    DateOpened = DateTime.Now.AddMonths(-6),
                    AccountBalance = 100000.00m
                },
                // Trinity - Hacker accounts
                new Account
                {
                    AccountNumber = "TR001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[15].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-2),
                    AccountBalance = 300000.00m
                },
                new Account
                {
                    AccountNumber = "TR002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[15].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 50000.75m
                },
                // David Bowman - Astronaut accounts
                new Account
                {
                    AccountNumber = "DB001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[16].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-5),
                    AccountBalance = 125000.00m
                },
                new Account
                {
                    AccountNumber = "DB002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[16].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-4),
                    AccountBalance = 45000.50m
                },
                // WALL-E Robot - Earth cleanup accounts
                new Account
                {
                    AccountNumber = "WE001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[17].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-6),
                    AccountBalance = 50000.00m
                },
                new Account
                {
                    AccountNumber = "WE002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[17].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-5),
                    AccountBalance = 25000.25m
                },
                // Sonny Robot - US Robotics accounts
                new Account
                {
                    AccountNumber = "SR001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[18].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-3),
                    AccountBalance = 75000.00m
                },
                new Account
                {
                    AccountNumber = "SR002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[18].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-2),
                    AccountBalance = 35000.50m
                },
                // Ava Ex-Machina - AI research accounts
                new Account
                {
                    AccountNumber = "AV001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[19].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-2),
                    AccountBalance = 100000.00m
                },
                new Account
                {
                    AccountNumber = "AV002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[19].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 40000.75m
                },
                // Roy Batty - Replicant accounts
                new Account
                {
                    AccountNumber = "RB001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[20].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 80000.00m
                },
                new Account
                {
                    AccountNumber = "RB002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[20].CustomerId,
                    DateOpened = DateTime.Now.AddMonths(-8),
                    AccountBalance = 30000.50m
                },
                // Samantha OS - Digital being accounts
                new Account
                {
                    AccountNumber = "SO001",
                    AccountTypeId = savingsType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[21].CustomerId,
                    DateOpened = DateTime.Now.AddYears(-1),
                    AccountBalance = 60000.00m
                },
                new Account
                {
                    AccountNumber = "SO002",
                    AccountTypeId = checkingType.AccountTypeId,
                    IsActive = true,
                    CustomerId = savedCustomers[21].CustomerId,
                    DateOpened = DateTime.Now.AddMonths(-6),
                    AccountBalance = 20000.25m
                }
            };
            Accounts.AddRange(accounts);
            SaveChanges();

            // Seed Transactions (matching MAUI app exactly)
            var savedAccounts = Accounts.ToList();
            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    TransactionTypeId = depositType.TransactionTypeId,
                    AccountId = savedAccounts[0].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-30),
                    Amount = 2000m,
                    Description = "Initial deposit"
                },
                new Transaction
                {
                    TransactionTypeId = depositType.TransactionTypeId,
                    AccountId = savedAccounts[0].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-15),
                    Amount = 500.50m,
                    Description = "Salary deposit"
                },
                new Transaction
                {
                    TransactionTypeId = withdrawalType.TransactionTypeId,
                    AccountId = savedAccounts[0].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-5),
                    Amount = -200m,
                    Description = "ATM withdrawal"
                },
                new Transaction
                {
                    TransactionTypeId = depositType.TransactionTypeId,
                    AccountId = savedAccounts[1].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-20),
                    Amount = 1500m,
                    Description = "Transfer from savings"
                },
                new Transaction
                {
                    TransactionTypeId = withdrawalType.TransactionTypeId,
                    AccountId = savedAccounts[1].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-7),
                    Amount = -299.75m,
                    Description = "Online purchase"
                },
                new Transaction
                {
                    TransactionTypeId = depositType.TransactionTypeId,
                    AccountId = savedAccounts[2].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-25),
                    Amount = 4000m,
                    Description = "Business deposit"
                },
                new Transaction
                {
                    TransactionTypeId = withdrawalType.TransactionTypeId,
                    AccountId = savedAccounts[2].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-3),
                    Amount = -500m,
                    Description = "Office supplies"
                },
                // Superhero Transactions
                // Superman transactions
                new Transaction
                {
                    TransactionTypeId = depositType.TransactionTypeId,
                    AccountId = savedAccounts[4].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-45),
                    Amount = 3000m,
                    Description = "Daily Planet salary"
                },
                new Transaction
                {
                    TransactionTypeId = withdrawalType.TransactionTypeId,
                    AccountId = savedAccounts[4].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-20),
                    Amount = -150m,
                    Description = "Fortress of Solitude utilities"
                },
                new Transaction
                {
                    TransactionTypeId = depositType.TransactionTypeId,
                    AccountId = savedAccounts[5].AccountId,
                    TransactionDate = DateTime.Now.AddDays(-10),
                    Amount = 500m,
                    Description = "Freelance journalism"
                }
                // Note: Additional transactions would follow the same pattern from MAUI app
            };
            Transactions.AddRange(transactions);
            SaveChanges();

            // Seed Auths (matching MAUI app exactly)
            var auths = new List<Auth>
            {
                new Auth
                {
                    CustomerId = savedCustomers[0].CustomerId,
                    UserName = "john.doe@email.com",
                    Password = "pass123",
                    AuthTypeId = passwordAuthType.AuthTypeId
                },
                new Auth
                {
                    CustomerId = savedCustomers[1].CustomerId,
                    UserName = "jane.smith@email.com",
                    Password = "smith456",
                    AuthTypeId = otpAuthType.AuthTypeId
                },
                // Superhero Authentication
                new Auth
                {
                    CustomerId = savedCustomers[2].CustomerId,
                    UserName = "superman@dailyplanet.com",
                    Password = "KryptonIsMyHome",
                    AuthTypeId = passwordAuthType.AuthTypeId
                },
                new Auth
                {
                    CustomerId = savedCustomers[3].CustomerId,
                    UserName = "batman@wayneenterprises.com",
                    Password = "IAmTheNight",
                    AuthTypeId = passwordAuthType.AuthTypeId
                },
                new Auth
                {
                    CustomerId = savedCustomers[4].CustomerId,
                    UserName = "wonderwoman@themyscira.com",
                    Password = "DianaOfThemyscira",
                    AuthTypeId = passwordAuthType.AuthTypeId
                }
                // Note: Additional auths would follow the same pattern from MAUI app
            };
            Auths.AddRange(auths);
            SaveChanges();

            // Seed Assets (matching MAUI app exactly)
            var assets = new List<Asset>
            {
                new Asset
                {
                    AssetTypeId = propertyAssetType.AssetTypeId,
                    CustomerId = savedCustomers[0].CustomerId,
                    Value = 100000m,
                    Name = "Home"
                },
                new Asset
                {
                    AssetTypeId = vehicleAssetType.AssetTypeId,
                    CustomerId = savedCustomers[1].CustomerId,
                    Value = 20000m,
                    Name = "Car"
                },
                // Superhero Assets
                new Asset
                {
                    AssetTypeId = propertyAssetType.AssetTypeId,
                    CustomerId = savedCustomers[2].CustomerId,
                    Value = 500000000m,
                    Name = "Fortress of Solitude"
                },
                new Asset
                {
                    AssetTypeId = propertyAssetType.AssetTypeId,
                    CustomerId = savedCustomers[3].CustomerId,
                    Value = 50000000m,
                    Name = "Wayne Manor"
                },
                new Asset
                {
                    AssetTypeId = vehicleAssetType.AssetTypeId,
                    CustomerId = savedCustomers[3].CustomerId,
                    Value = 25000000m,
                    Name = "Batmobile"
                }
                // Note: Additional assets would follow the same pattern from MAUI app
            };
            Assets.AddRange(assets);
            SaveChanges();
        }
    }
}
