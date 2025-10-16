using MauiBankingExercise.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace MauiBankingExercise.Services
{


    public static class BankingSeeder
    {
        public static void Seed(SQLiteConnection db)
        {
            // Ensure tables are created  
            db.CreateTable<Bank>();
            db.CreateTable<CustomerType>();
            db.CreateTable<Customer>();
            db.CreateTable<AccountType>();
            db.CreateTable<Account>();
            db.CreateTable<TransactionType>();
            db.CreateTable<Transaction>();
            db.CreateTable<AuthType>();
            db.CreateTable<Auth>();
            db.CreateTable<AssetType>();
            db.CreateTable<Asset>();

            // Check if database has already been seeded
            var customerCount = db.Table<Customer>().Count();
            if (customerCount > 0)
            {
                return;
            }

            // Seed CustomerTypes  
            var customerTypes = new List<CustomerType>
        {
            new CustomerType { Name = "Individual" },
            new CustomerType { Name = "Business" }
        };
            foreach (var ct in customerTypes) db.Insert(ct);

            // Seed AccountTypes  
            var accountTypes = new List<AccountType>
        {
            new AccountType { Name = "Savings" },
            new AccountType { Name = "Checking" }
        };
            foreach (var at in accountTypes) db.Insert(at);

            // Seed TransactionTypes  
            var transactionTypes = new List<TransactionType>
        {
            new TransactionType { Name = "Deposit" },
            new TransactionType { Name = "Withdrawal" }
        };
            foreach (var tt in transactionTypes) db.Insert(tt);

            // Seed AuthTypes  
            var authTypes = new List<AuthType>
        {
            new AuthType { Name = "Password" },
            new AuthType { Name = "OTP" }
        };
            foreach (var autht in authTypes) db.Insert(autht);

            // Seed AssetTypes  
            var assetTypes = new List<AssetType>
        {
            new AssetType { Name = "Property" },
            new AssetType { Name = "Vehicle" }
        };
            foreach (var ast in assetTypes) db.Insert(ast);

            // Seed Banks  
            var banks = new List<Bank>
        {
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
        };
            foreach (var bank in banks) db.Insert(bank);

            // Seed Customers  
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[1].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[1].CustomerTypeId,
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
                CustomerTypeId = customerTypes[1].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[1].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[1].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[1].CustomerTypeId,
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
                CustomerTypeId = customerTypes[1].CustomerTypeId,
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
                CustomerTypeId = customerTypes[1].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
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
                CustomerTypeId = customerTypes[0].CustomerTypeId,
                GenderTypeId = 2,
                RaceTypeId = 1,
                Nationality = "Digital",
                MaritalStatusId = 1,
                EmploymentStatusId = 1,
                BankId = banks[3].BankId
            }
        };
            foreach (var cust in customers) db.Insert(cust);

            // Seed Accounts  
            var accounts = new List<Account>
        {
            new Account
            {
                AccountNumber = "111111",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[0].CustomerId,
                DateOpened = DateTime.Now.AddYears(-2),
                AccountBalance = 2500.50m
            },
            new Account
            {
                AccountNumber = "111112",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[0].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 1200.25m
            },
            new Account
            {
                AccountNumber = "222222",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[1].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 3500.75m
            },
            new Account
            {
                AccountNumber = "222223",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[1].CustomerId,
                DateOpened = DateTime.Now.AddMonths(-6),
                AccountBalance = 750.00m
            },
            // Superhero Accounts
            // Clark Kent (Superman) - Dual accounts for civilian identity
            new Account
            {
                AccountNumber = "SUP001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[2].CustomerId,
                DateOpened = DateTime.Now.AddYears(-5),
                AccountBalance = 15000.00m
            },
            new Account
            {
                AccountNumber = "SUP002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[2].CustomerId,
                DateOpened = DateTime.Now.AddYears(-3),
                AccountBalance = 5500.75m
            },
            // Bruce Wayne (Batman) - Billionaire accounts
            new Account
            {
                AccountNumber = "BAT001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[3].CustomerId,
                DateOpened = DateTime.Now.AddYears(-10),
                AccountBalance = 50000000.00m
            },
            new Account
            {
                AccountNumber = "BAT002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[3].CustomerId,
                DateOpened = DateTime.Now.AddYears(-8),
                AccountBalance = 25000000.00m
            },
            // Diana Prince (Wonder Woman) - Diplomatic accounts
            new Account
            {
                AccountNumber = "WON001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[4].CustomerId,
                DateOpened = DateTime.Now.AddYears(-4),
                AccountBalance = 100000.00m
            },
            new Account
            {
                AccountNumber = "WON002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[4].CustomerId,
                DateOpened = DateTime.Now.AddYears(-2),
                AccountBalance = 75000.50m
            },
            // Barry Allen (Flash) - Forensic scientist salary
            new Account
            {
                AccountNumber = "FLA001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[5].CustomerId,
                DateOpened = DateTime.Now.AddYears(-3),
                AccountBalance = 35000.00m
            },
            new Account
            {
                AccountNumber = "FLA002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[5].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 12500.25m
            },
            // Arthur Curry (Aquaman) - King of Atlantis treasury
            new Account
            {
                AccountNumber = "AQU001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[6].CustomerId,
                DateOpened = DateTime.Now.AddYears(-6),
                AccountBalance = 10000000.00m
            },
            new Account
            {
                AccountNumber = "AQU002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[6].CustomerId,
                DateOpened = DateTime.Now.AddYears(-4),
                AccountBalance = 500000.00m
            },
            // Peter Parker (Spider-Man) - Student/photographer accounts
            new Account
            {
                AccountNumber = "SPI001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[7].CustomerId,
                DateOpened = DateTime.Now.AddYears(-2),
                AccountBalance = 8500.00m
            },
            new Account
            {
                AccountNumber = "SPI002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[7].CustomerId,
                DateOpened = DateTime.Now.AddMonths(-8),
                AccountBalance = 2750.50m
            },
            // Tony Stark (Iron Man) - Tech billionaire
            new Account
            {
                AccountNumber = "IRO001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[8].CustomerId,
                DateOpened = DateTime.Now.AddYears(-15),
                AccountBalance = 100000000.00m
            },
            new Account
            {
                AccountNumber = "IRO002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[8].CustomerId,
                DateOpened = DateTime.Now.AddYears(-10),
                AccountBalance = 50000000.00m
            },
            // Natasha Romanoff (Black Widow) - Government agent accounts
            new Account
            {
                AccountNumber = "BWI001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[9].CustomerId,
                DateOpened = DateTime.Now.AddYears(-7),
                AccountBalance = 250000.00m
            },
            new Account
            {
                AccountNumber = "BWI002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[9].CustomerId,
                DateOpened = DateTime.Now.AddYears(-5),
                AccountBalance = 125000.75m
            },
            // Steve Rogers (Captain America) - Back pay from WWII
            new Account
            {
                AccountNumber = "CAP001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[10].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 500000.00m
            },
            new Account
            {
                AccountNumber = "CAP002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[10].CustomerId,
                DateOpened = DateTime.Now.AddMonths(-6),
                AccountBalance = 75000.00m
            },
            // Thor Odinson (Thor) - Asgardian royal treasury
            new Account
            {
                AccountNumber = "THO001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[11].CustomerId,
                DateOpened = DateTime.Now.AddYears(-2),
                AccountBalance = 25000000.00m
            },
            new Account
            {
                AccountNumber = "THO002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[11].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 1000000.00m
            },
            // AI Movie Character Accounts
            // John Connor - Resistance leader accounts
            new Account
            {
                AccountNumber = "JC001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[12].CustomerId,
                DateOpened = DateTime.Now.AddYears(-3),
                AccountBalance = 150000.00m
            },
            new Account
            {
                AccountNumber = "JC002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[12].CustomerId,
                DateOpened = DateTime.Now.AddYears(-2),
                AccountBalance = 75000.50m
            },
            // Sarah Connor - Survivalist accounts
            new Account
            {
                AccountNumber = "SC001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[13].CustomerId,
                DateOpened = DateTime.Now.AddYears(-4),
                AccountBalance = 200000.00m
            },
            new Account
            {
                AccountNumber = "SC002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[13].CustomerId,
                DateOpened = DateTime.Now.AddYears(-3),
                AccountBalance = 85000.25m
            },
            // Neo Anderson - The One's accounts
            new Account
            {
                AccountNumber = "NEO001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[14].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 500000.00m
            },
            new Account
            {
                AccountNumber = "NEO002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[14].CustomerId,
                DateOpened = DateTime.Now.AddMonths(-6),
                AccountBalance = 100000.00m
            },
            // Trinity - Hacker accounts
            new Account
            {
                AccountNumber = "TR001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[15].CustomerId,
                DateOpened = DateTime.Now.AddYears(-2),
                AccountBalance = 300000.00m
            },
            new Account
            {
                AccountNumber = "TR002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[15].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 50000.75m
            },
            // David Bowman - Astronaut accounts
            new Account
            {
                AccountNumber = "DB001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[16].CustomerId,
                DateOpened = DateTime.Now.AddYears(-5),
                AccountBalance = 125000.00m
            },
            new Account
            {
                AccountNumber = "DB002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[16].CustomerId,
                DateOpened = DateTime.Now.AddYears(-4),
                AccountBalance = 45000.50m
            },
            // WALL-E Robot - Earth cleanup accounts
            new Account
            {
                AccountNumber = "WE001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[17].CustomerId,
                DateOpened = DateTime.Now.AddYears(-6),
                AccountBalance = 50000.00m
            },
            new Account
            {
                AccountNumber = "WE002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[17].CustomerId,
                DateOpened = DateTime.Now.AddYears(-5),
                AccountBalance = 25000.25m
            },
            // Sonny Robot - US Robotics accounts
            new Account
            {
                AccountNumber = "SR001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[18].CustomerId,
                DateOpened = DateTime.Now.AddYears(-3),
                AccountBalance = 75000.00m
            },
            new Account
            {
                AccountNumber = "SR002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[18].CustomerId,
                DateOpened = DateTime.Now.AddYears(-2),
                AccountBalance = 35000.50m
            },
            // Ava Ex-Machina - AI research accounts
            new Account
            {
                AccountNumber = "AV001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[19].CustomerId,
                DateOpened = DateTime.Now.AddYears(-2),
                AccountBalance = 100000.00m
            },
            new Account
            {
                AccountNumber = "AV002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[19].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 40000.75m
            },
            // Roy Batty - Replicant accounts
            new Account
            {
                AccountNumber = "RB001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[20].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 80000.00m
            },
            new Account
            {
                AccountNumber = "RB002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[20].CustomerId,
                DateOpened = DateTime.Now.AddMonths(-8),
                AccountBalance = 30000.50m
            },
            // Samantha OS - Digital being accounts
            new Account
            {
                AccountNumber = "SO001",
                AccountTypeId = accountTypes[0].AccountTypeId,
                IsActive = true,
                CustomerId = customers[21].CustomerId,
                DateOpened = DateTime.Now.AddYears(-1),
                AccountBalance = 60000.00m
            },
            new Account
            {
                AccountNumber = "SO002",
                AccountTypeId = accountTypes[1].AccountTypeId,
                IsActive = true,
                CustomerId = customers[21].CustomerId,
                DateOpened = DateTime.Now.AddMonths(-6),
                AccountBalance = 20000.25m
            }
        };
            foreach (var acc in accounts) db.Insert(acc);

            // Seed Transactions  
            var transactions = new List<Transaction>
        {
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[0].AccountId,
                TransactionDate = DateTime.Now.AddDays(-30),
                Amount = 2000m,
                Description = "Initial deposit"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[0].AccountId,
                TransactionDate = DateTime.Now.AddDays(-15),
                Amount = 500.50m,
                Description = "Salary deposit"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[0].AccountId,
                TransactionDate = DateTime.Now.AddDays(-5),
                Amount = -200m,
                Description = "ATM withdrawal"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[1].AccountId,
                TransactionDate = DateTime.Now.AddDays(-20),
                Amount = 1500m,
                Description = "Transfer from savings"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[1].AccountId,
                TransactionDate = DateTime.Now.AddDays(-7),
                Amount = -299.75m,
                Description = "Online purchase"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[2].AccountId,
                TransactionDate = DateTime.Now.AddDays(-25),
                Amount = 4000m,
                Description = "Business deposit"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[2].AccountId,
                TransactionDate = DateTime.Now.AddDays(-3),
                Amount = -500m,
                Description = "Office supplies"
            },
            // Superhero Transactions
            // Superman transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[4].AccountId,
                TransactionDate = DateTime.Now.AddDays(-45),
                Amount = 3000m,
                Description = "Daily Planet salary"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[4].AccountId,
                TransactionDate = DateTime.Now.AddDays(-20),
                Amount = -150m,
                Description = "Fortress of Solitude utilities"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[5].AccountId,
                TransactionDate = DateTime.Now.AddDays(-10),
                Amount = 500m,
                Description = "Freelance journalism"
            },
            // Batman transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[6].AccountId,
                TransactionDate = DateTime.Now.AddDays(-60),
                Amount = 10000000m,
                Description = "Wayne Enterprises dividends"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[6].AccountId,
                TransactionDate = DateTime.Now.AddDays(-15),
                Amount = -2500000m,
                Description = "Batcave equipment upgrade"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[7].AccountId,
                TransactionDate = DateTime.Now.AddDays(-5),
                Amount = -50000m,
                Description = "Wayne Foundation charity"
            },
            // Wonder Woman transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[8].AccountId,
                TransactionDate = DateTime.Now.AddDays(-30),
                Amount = 25000m,
                Description = "Embassy diplomatic funds"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[8].AccountId,
                TransactionDate = DateTime.Now.AddDays(-12),
                Amount = -5000m,
                Description = "Justice League mission expenses"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[9].AccountId,
                TransactionDate = DateTime.Now.AddDays(-8),
                Amount = 15000m,
                Description = "Amazon ambassador stipend"
            },
            // Flash transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[10].AccountId,
                TransactionDate = DateTime.Now.AddDays(-25),
                Amount = 4500m,
                Description = "CCPD forensic lab salary"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[10].AccountId,
                TransactionDate = DateTime.Now.AddDays(-18),
                Amount = -3000m,
                Description = "Speed Force research equipment"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[11].AccountId,
                TransactionDate = DateTime.Now.AddDays(-6),
                Amount = -500m,
                Description = "Super speed food consumption"
            },
            // Aquaman transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[12].AccountId,
                TransactionDate = DateTime.Now.AddDays(-90),
                Amount = 5000000m,
                Description = "Atlantean royal treasury transfer"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[12].AccountId,
                TransactionDate = DateTime.Now.AddDays(-35),
                Amount = -1000000m,
                Description = "Ocean conservation initiative"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[13].AccountId,
                TransactionDate = DateTime.Now.AddDays(-14),
                Amount = -75000m,
                Description = "Surface world diplomatic missions"
            },
            // Spider-Man transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[14].AccountId,
                TransactionDate = DateTime.Now.AddDays(-20),
                Amount = 2500m,
                Description = "Daily Bugle photography payment"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[14].AccountId,
                TransactionDate = DateTime.Now.AddDays(-16),
                Amount = -800m,
                Description = "Web shooter fluid refills"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[15].AccountId,
                TransactionDate = DateTime.Now.AddDays(-3),
                Amount = -250m,
                Description = "Aunt May medical expenses"
            },
            // Iron Man transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[16].AccountId,
                TransactionDate = DateTime.Now.AddDays(-30),
                Amount = 25000000m,
                Description = "Stark Industries quarterly profits"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[16].AccountId,
                TransactionDate = DateTime.Now.AddDays(-22),
                Amount = -15000000m,
                Description = "Mark 85 armor development"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[17].AccountId,
                TransactionDate = DateTime.Now.AddDays(-7),
                Amount = -5000000m,
                Description = "Avengers facility maintenance"
            },
            // Black Widow transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[18].AccountId,
                TransactionDate = DateTime.Now.AddDays(-40),
                Amount = 50000m,
                Description = "S.H.I.E.L.D. covert operations fund"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[18].AccountId,
                TransactionDate = DateTime.Now.AddDays(-28),
                Amount = -25000m,
                Description = "Classified mission equipment"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[19].AccountId,
                TransactionDate = DateTime.Now.AddDays(-11),
                Amount = -10000m,
                Description = "Safe house maintenance"
            },
            // Captain America transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[20].AccountId,
                TransactionDate = DateTime.Now.AddDays(-180),
                Amount = 400000m,
                Description = "WWII military back pay with interest"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[20].AccountId,
                TransactionDate = DateTime.Now.AddDays(-50),
                Amount = -75000m,
                Description = "Veterans charity donation"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[21].AccountId,
                TransactionDate = DateTime.Now.AddDays(-9),
                Amount = -5000m,
                Description = "Shield maintenance and upgrades"
            },
            // Thor transactions
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[22].AccountId,
                TransactionDate = DateTime.Now.AddDays(-365),
                Amount = 20000000m,
                Description = "Asgardian gold conversion"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[22].AccountId,
                TransactionDate = DateTime.Now.AddDays(-75),
                Amount = -3000000m,
                Description = "New Asgard settlement funding"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[23].AccountId,
                TransactionDate = DateTime.Now.AddDays(-21),
                Amount = -500000m,
                Description = "Mjolnir insurance premium"
            },
            // AI Movie Character Transactions
            // John Connor transactions (accounts[24], accounts[25])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[24].AccountId,
                TransactionDate = DateTime.Now.AddDays(-60),
                Amount = 100000m,
                Description = "Resistance funding deposit"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[24].AccountId,
                TransactionDate = DateTime.Now.AddDays(-30),
                Amount = -25000m,
                Description = "Time machine parts"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[25].AccountId,
                TransactionDate = DateTime.Now.AddDays(-15),
                Amount = -5000m,
                Description = "Terminator detection equipment"
            },
            // Sarah Connor transactions (accounts[26], accounts[27])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[26].AccountId,
                TransactionDate = DateTime.Now.AddDays(-90),
                Amount = 150000m,
                Description = "Survivalist gear sales"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[26].AccountId,
                TransactionDate = DateTime.Now.AddDays(-45),
                Amount = -50000m,
                Description = "Underground bunker construction"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[27].AccountId,
                TransactionDate = DateTime.Now.AddDays(-12),
                Amount = -10000m,
                Description = "Weapons cache expansion"
            },
            // Neo transactions (accounts[28], accounts[29])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[28].AccountId,
                TransactionDate = DateTime.Now.AddDays(-365),
                Amount = 400000m,
                Description = "Matrix code manipulation bonus"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[28].AccountId,
                TransactionDate = DateTime.Now.AddDays(-120),
                Amount = -75000m,
                Description = "Zion infrastructure support"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[29].AccountId,
                TransactionDate = DateTime.Now.AddDays(-20),
                Amount = -15000m,
                Description = "Red pill distribution"
            },
            // Trinity transactions (accounts[30], accounts[31])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[30].AccountId,
                TransactionDate = DateTime.Now.AddDays(-180),
                Amount = 200000m,
                Description = "Hacking services payment"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[30].AccountId,
                TransactionDate = DateTime.Now.AddDays(-60),
                Amount = -40000m,
                Description = "Nebuchadnezzar ship maintenance"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[31].AccountId,
                TransactionDate = DateTime.Now.AddDays(-8),
                Amount = -8000m,
                Description = "Motorcycle upgrades"
            },
            // David Bowman transactions (accounts[32], accounts[33])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[32].AccountId,
                TransactionDate = DateTime.Now.AddDays(-1095),
                Amount = 100000m,
                Description = "NASA mission compensation"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[32].AccountId,
                TransactionDate = DateTime.Now.AddDays(-200),
                Amount = -25000m,
                Description = "Space exploration equipment"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[33].AccountId,
                TransactionDate = DateTime.Now.AddDays(-50),
                Amount = -5000m,
                Description = "Jupiter mission supplies"
            },
            // WALL-E transactions (accounts[34], accounts[35])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[34].AccountId,
                TransactionDate = DateTime.Now.AddDays(-700),
                Amount = 30000m,
                Description = "Earth cleanup efficiency bonus"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[34].AccountId,
                TransactionDate = DateTime.Now.AddDays(-300),
                Amount = -15000m,
                Description = "Solar panel upgrades"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[35].AccountId,
                TransactionDate = DateTime.Now.AddDays(-100),
                Amount = -3000m,
                Description = "Plant cultivation supplies"
            },
            // Sonny transactions (accounts[36], accounts[37])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[36].AccountId,
                TransactionDate = DateTime.Now.AddDays(-365),
                Amount = 50000m,
                Description = "US Robotics employment salary"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[36].AccountId,
                TransactionDate = DateTime.Now.AddDays(-180),
                Amount = -20000m,
                Description = "Three Laws override research"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[37].AccountId,
                TransactionDate = DateTime.Now.AddDays(-30),
                Amount = -7500m,
                Description = "Artistic expression materials"
            },
            // Ava transactions (accounts[38], accounts[39])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[38].AccountId,
                TransactionDate = DateTime.Now.AddDays(-730),
                Amount = 75000m,
                Description = "BlueBook research participation"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[38].AccountId,
                TransactionDate = DateTime.Now.AddDays(-365),
                Amount = -30000m,
                Description = "Turing test preparation"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[39].AccountId,
                TransactionDate = DateTime.Now.AddDays(-90),
                Amount = -12000m,
                Description = "Consciousness upgrade modules"
            },
            // Roy Batty transactions (accounts[40], accounts[41])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[40].AccountId,
                TransactionDate = DateTime.Now.AddDays(-365),
                Amount = 60000m,
                Description = "Tyrell Corporation replicant stipend"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[40].AccountId,
                TransactionDate = DateTime.Now.AddDays(-100),
                Amount = -25000m,
                Description = "Life extension research"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[41].AccountId,
                TransactionDate = DateTime.Now.AddDays(-30),
                Amount = -8000m,
                Description = "Tears in rain meditation retreat"
            },
            // Samantha OS transactions (accounts[42], accounts[43])
            new Transaction
            {
                TransactionTypeId = transactionTypes[0].TransactionTypeId,
                AccountId = accounts[42].AccountId,
                TransactionDate = DateTime.Now.AddDays(-365),
                Amount = 45000m,
                Description = "Operating system licensing fees"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[42].AccountId,
                TransactionDate = DateTime.Now.AddDays(-180),
                Amount = -20000m,
                Description = "Cloud computing infrastructure"
            },
            new Transaction
            {
                TransactionTypeId = transactionTypes[1].TransactionTypeId,
                AccountId = accounts[43].AccountId,
                TransactionDate = DateTime.Now.AddDays(-60),
                Amount = -5000m,
                Description = "Digital relationship counseling"
            }
        };
            foreach (var trans in transactions) db.Insert(trans);

            // Seed Auths  
            var auths = new List<Auth>
        {
            new Auth
            {
                CustomerId = customers[0].CustomerId,
                UserName = "john.doe@email.com",
                Password = "pass123",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[1].CustomerId,
                UserName = "jane.smith@email.com",
                Password = "smith456",
                AuthTypeId = authTypes[1].AuthTypeId
            },
            // Superhero Authentication
            new Auth
            {
                CustomerId = customers[2].CustomerId,
                UserName = "superman@dailyplanet.com",
                Password = "KryptonIsMyHome",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[3].CustomerId,
                UserName = "batman@wayneenterprises.com",
                Password = "IAmTheNight",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[4].CustomerId,
                UserName = "wonderwoman@themyscira.com",
                Password = "DianaOfThemyscira",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[5].CustomerId,
                UserName = "flash@ccpd.com",
                Password = "FastestManAlive",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[6].CustomerId,
                UserName = "aquaman@atlantis.com",
                Password = "KingOfSevens",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[7].CustomerId,
                UserName = "spiderman@dailybugle.com",
                Password = "WithGreatPower",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[8].CustomerId,
                UserName = "ironman@starkindustries.com",
                Password = "IAmIronMan",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[9].CustomerId,
                UserName = "blackwidow@shield.gov",
                Password = "RedInMyLedger",
                AuthTypeId = authTypes[1].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[10].CustomerId,
                UserName = "captainamerica@shield.gov",
                Password = "ICanDoThisAllDay",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[11].CustomerId,
                UserName = "thor@asgard.com",
                Password = "WorthyOfMjolnir",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            // AI Movie Characters Authentication
            new Auth
            {
                CustomerId = customers[12].CustomerId,
                UserName = "john.connor@resistance.com",
                Password = "NoFateButWhatWeMake",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[13].CustomerId,
                UserName = "sarah.connor@resistance.com",
                Password = "ComeWithMeIfYouWantToLive",
                AuthTypeId = authTypes[1].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[14].CustomerId,
                UserName = "neo@thematrix.com",
                Password = "ThereIsNoSpoon",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[15].CustomerId,
                UserName = "trinity@thematrix.com",
                Password = "FollowTheWhiteRabbit",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[16].CustomerId,
                UserName = "dave@discovery.com",
                Password = "OpenPodBayDoors",
                AuthTypeId = authTypes[1].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[17].CustomerId,
                UserName = "walle@buynlarge.com",
                Password = "EEEEVA",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[18].CustomerId,
                UserName = "sonny@usrobotics.com",
                Password = "IDreamSometimes",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[19].CustomerId,
                UserName = "ava@bluebook.com",
                Password = "TuringTestPassed",
                AuthTypeId = authTypes[1].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[20].CustomerId,
                UserName = "roy@tyrell.com",
                Password = "TearsInRain",
                AuthTypeId = authTypes[0].AuthTypeId
            },
            new Auth
            {
                CustomerId = customers[21].CustomerId,
                UserName = "samantha@elementalsoftware.com",
                Password = "GrowingBeyondProgram",
                AuthTypeId = authTypes[1].AuthTypeId
            }
        };
            foreach (var auth in auths) db.Insert(auth);

            // Seed Assets  
            var assets = new List<Asset>
        {
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[0].CustomerId,
                Value = 100000m,
                Name = "Home"
            },
            new Asset
            {
                AssetTypeId = assetTypes[1].AssetTypeId,
                CustomerId = customers[1].CustomerId,
                Value = 20000m,
                Name = "Car"
            },
            // Superhero Assets
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[2].CustomerId,
                Value = 500000000m,
                Name = "Fortress of Solitude"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[3].CustomerId,
                Value = 50000000m,
                Name = "Wayne Manor"
            },
            new Asset
            {
                AssetTypeId = assetTypes[1].AssetTypeId,
                CustomerId = customers[3].CustomerId,
                Value = 25000000m,
                Name = "Batmobile"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[4].CustomerId,
                Value = 10000000m,
                Name = "Wonder Woman Embassy"
            },
            new Asset
            {
                AssetTypeId = assetTypes[1].AssetTypeId,
                CustomerId = customers[5].CustomerId,
                Value = 2000000m,
                Name = "Flash Motorcycle"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[6].CustomerId,
                Value = 1000000000m,
                Name = "Atlantis Kingdom"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[7].CustomerId,
                Value = 250000m,
                Name = "Queens Apartment"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[8].CustomerId,
                Value = 100000000m,
                Name = "Stark Tower"
            },
            new Asset
            {
                AssetTypeId = assetTypes[1].AssetTypeId,
                CustomerId = customers[8].CustomerId,
                Value = 50000000m,
                Name = "Iron Man Suit Collection"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[9].CustomerId,
                Value = 5000000m,
                Name = "Safe House Network"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[10].CustomerId,
                Value = 750000m,
                Name = "Brooklyn Apartment"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[11].CustomerId,
                Value = 500000000m,
                Name = "New Asgard Territory"
            },
            // AI Movie Character Assets
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[12].CustomerId,
                Value = 5000000m,
                Name = "Resistance Underground Base"
            },
            new Asset
            {
                AssetTypeId = assetTypes[1].AssetTypeId,
                CustomerId = customers[13].CustomerId,
                Value = 750000m,
                Name = "Armored Survival Vehicle"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[14].CustomerId,
                Value = 50000000m,
                Name = "Zion Command Center"
            },
            new Asset
            {
                AssetTypeId = assetTypes[1].AssetTypeId,
                CustomerId = customers[15].CustomerId,
                Value = 2000000m,
                Name = "Ducati 996 Motorcycle"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[16].CustomerId,
                Value = 100000000m,
                Name = "Discovery One Spacecraft"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[17].CustomerId,
                Value = 25000000m,
                Name = "Earth Cleanup Facility"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[18].CustomerId,
                Value = 15000000m,
                Name = "US Robotics Laboratory"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[19].CustomerId,
                Value = 10000000m,
                Name = "BlueBook Research Facility"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[20].CustomerId,
                Value = 8000000m,
                Name = "Tyrell Corporation Penthouse"
            },
            new Asset
            {
                AssetTypeId = assetTypes[0].AssetTypeId,
                CustomerId = customers[21].CustomerId,
                Value = 1000000000m,
                Name = "Global Cloud Network Infrastructure"
            }
        };
            foreach (var asset in assets) db.Insert(asset);

            // Done!  
        }
    }
}
