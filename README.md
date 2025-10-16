# MAUI Banking Exercise - Complete MVVM Implementation

> Important — Educational Use Only
>
> This repository is provided strictly for learning and demonstration. It is not production-ready, is not security-hardened, and must not be used with real banking data or in regulated environments. No warranties are provided.

## 📋 Project Overview

This .NET MAUI application implements a complete banking system using the MVVM pattern with modern .NET development practices. The application meets all the specified requirements for customer selection, dashboard management, and transaction functionality.

## ✅ Completed Requirements

### 1. Customer Selection (No login required)
- **✅ Simple customer selection screen**
- **✅ ListView/CollectionView displaying customers from database**
- **✅ Navigation to customer dashboard on selection**

### 2. Customer Dashboard
- **✅ Display selected customer's name and information**
- **✅ Show customer accounts with balances**
- **✅ List all accounts using CollectionView**
- **✅ Account selection for drill-down functionality**

### 3. Transaction Functionality

#### Viewing Transactions
- **✅ Account selection displays transaction history**
- **✅ Complete transaction list for selected account**
- **✅ Transaction details (date, amount, description, type)**

#### Making Transactions
- **✅ UI for entering transaction amount**
- **✅ Transaction type selection (Deposit/Withdrawal)**
- **✅ Input validation (withdrawal limits)**
- **✅ Balance validation (cannot withdraw more than available)**

#### Transaction Processing
- **✅ Create new Transaction in database**
- **✅ Update account balance automatically**
- **✅ Refresh transaction list and account balance**
- **✅ Transaction rollback on errors**

## 🏗️ Architecture Overview

### Diagram

```mermaid
flowchart TB
     %% Layers
     subgraph UI[Views (XAML Pages)]
          CustomersView[CustomersView]
          CustomerDashboardView[CustomerDashboardView]
          AccountDetailsView[AccountDetailsView]
          CreateTransactionView[CreateTransactionView]
     end

     subgraph VM[ViewModels]
          CustomersVM[CustomersViewModel]
          CustomerDashboardVM[CustomerDashboardViewModel]
          AccountDetailsVM[AccountDetailsViewModel]
          CreateTransactionVM[CreateTransactionViewModel]
     end

     subgraph SVC[Services / Data Access]
          BankingDb[BankingDatabaseService]
          Seeder[DatabaseSeederService]
     end

     subgraph DB[SQLite Database]
          TblCustomer[(Customer)]
          TblAccount[(Account)]
          TblTransaction[(Transaction)]
          TblTxnType[(TransactionType)]
     end

     Shell[App Shell Navigation]

     %% Bindings (two-way)
     CustomersView <--> CustomersVM
     CustomerDashboardView <--> CustomerDashboardVM
     AccountDetailsView <--> AccountDetailsVM
     CreateTransactionView <--> CreateTransactionVM

     %% Navigation
     Shell -. routes .-> CustomersView
     CustomersView -. select customer .-> CustomerDashboardView
     CustomerDashboardView -. select account .-> AccountDetailsView
     AccountDetailsView -. create transaction .-> CreateTransactionView

     %% VM to Services
     CustomersVM -->|queries, commands| BankingDb
     CustomerDashboardVM --> BankingDb
     AccountDetailsVM --> BankingDb
     CreateTransactionVM -->|validation + submit| BankingDb

     %% Services to DB
     BankingDb --> TblCustomer
     BankingDb --> TblAccount
     BankingDb --> TblTransaction
     BankingDb --> TblTxnType

     %% Support
     Seeder -. dev/test data .-> DB
```

### MVVM Pattern Implementation
The application follows strict MVVM principles using the **CommunityToolkit.Mvvm** library:

- **Models**: SQLite entities with relationships
- **Views**: XAML pages inheriting from BasePage
- **ViewModels**: ObservableObject implementations with commands
- **Services**: Database and business logic layer

### Key Design Patterns

1. **Repository Pattern**: `BankingDatabaseService` centralizes data access
2. **Command Pattern**: RelayCommand and AsyncRelayCommand for user interactions
3. **Observer Pattern**: ObservableProperty for two-way data binding
4. **Navigation Pattern**: Shell-based navigation with query parameters

## 📁 Project Structure

```
MauiBankingExercise/
├── Models/                     # Data entities
│   ├── Customer.cs
│   ├── Account.cs
│   ├── Transaction.cs
│   ├── TransactionType.cs
│   └── ... (other entities)
├── ViewModels/                 # MVVM ViewModels
│   ├── BaseViewModel.cs
│   ├── CustomersViewModel.cs
│   ├── CustomerDashboardViewModel.cs
│   ├── AccountDetailsViewModel.cs
│   └── CreateTransactionViewModel.cs
├── Views/                      # UI Pages
│   ├── BasePage.cs
│   ├── CustomersView.xaml
│   ├── CustomerDashboardView.xaml
│   ├── AccountDetailsView.xaml
│   └── CreateTransactionView.xaml
├── Services/                   # Business logic
│   ├── BankingDatabaseService.cs
│   └── DatabaseSeederService.cs
├── Converters/                 # Value converters
└── Resources/                  # Styles, images, fonts
```

## 🔄 Application Flow

### 1. Customer Selection Flow
```
CustomersView → CustomersViewModel → BankingDatabaseService
     ↓
Customer Selection → Navigation with CustomerId parameter
     ↓
CustomerDashboardView (with customer details and accounts)
```

### 2. Account Details Flow
```
CustomerDashboardView → Account Selection → Navigation with AccountId
     ↓
AccountDetailsView → AccountDetailsViewModel → Transaction History
     ↓
"Create Transaction" Button → CreateTransactionView
```

### 3. Transaction Creation Flow
```
CreateTransactionView → Validation → Database Transaction
     ↓
Success → Navigation back → Refresh Account Details
```

## 🛢️ Database Schema

### Core Entities
- **Customer**: Customer information and relationships
- **Account**: Bank accounts with balances
- **Transaction**: Financial transactions with amounts
- **TransactionType**: Deposit/Withdrawal types

### Key Relationships
- Customer → Multiple Accounts (1:N)
- Account → Multiple Transactions (1:N)
- TransactionType → Multiple Transactions (1:N)

## 🎯 Key Features Implemented

### Data Management
- **SQLite database** with SQLiteNetExtensions for relationships
- **Seeded test data** for development and testing
- **Async/await patterns** throughout data layer
- **Transaction management** with rollback capabilities

### User Interface
- **Modern MAUI controls** (CollectionView, Border, etc.)
- **Responsive design** with Grid and StackLayout
- **Data binding** with x:DataType for performance
- **Navigation** using Shell routing system

### Business Logic
- **Input validation** for transaction amounts
- **Balance checking** before withdrawals
- **Real-time balance updates** after transactions
- **Error handling** with user feedback

## 🔧 Technical Stack

- **.NET 9.0** - Latest .NET framework
- **.NET MAUI** - Cross-platform UI framework
- **SQLite** - Local database storage
- **CommunityToolkit.Mvvm** - MVVM helpers and commands
- **SQLiteNetExtensions** - ORM with relationship support

## 🏃‍♂️ How to Run

1. **Prerequisites**:
     - .NET 9.0 SDK
     - Windows 10/11 with developer tools
     - Visual Studio 2022 (17.11+) with the .NET MAUI workload
     - Or Visual Studio Code with the .NET MAUI extension

2. **Build and Run**:
     Using Visual Studio: open `MauiBankingExerciseSln.sln` and press F5.

     Using PowerShell + .NET CLI:

     ```powershell
     # From the repository root where the solution file exists
     dotnet build .\MauiBankingExerciseSln.sln -c Debug

     # Run the Windows target
     dotnet run --project .\MauiBankingExercise\MauiBankingExercise.csproj -f net9.0-windows10.0.19041.0 -c Debug
     ```

3. **Test Data**:
   - 2 sample customers (John Doe, Jane Smith)
   - 4 sample accounts with different balances
   - Multiple sample transactions for testing

## 🎨 UI Screenshots Overview

### Customer Selection Screen
- Clean list of customers with basic information
- Tap to select and navigate to customer dashboard

### Customer Dashboard
- Customer information in header section
- List of customer accounts with balances
- Tap account to view transaction details

### Account Details
- Account information and current balance
- Complete transaction history
- "Create Transaction" button for new transactions

### Create Transaction
- Transaction type picker (Deposit/Withdrawal)
- Amount input with validation
- Description field (optional)
- Real-time validation feedback

## 🔄 Navigation Flow

```
App Start → CustomersView (Customer List)
     ↓ (Customer Selected)
CustomerDashboardView (Customer Info + Accounts)
     ↓ (Account Selected)
AccountDetailsView (Account Info + Transactions)
     ↓ (Create Transaction Button)
CreateTransactionView (Transaction Form)
     ↓ (Submit Success)
← Back to AccountDetailsView (Updated Balance)
```

## 🎯 Best Practices Implemented

### MVVM Pattern
- **Separation of concerns** between View, ViewModel, and Model
- **Data binding** instead of code-behind manipulation
- **Commands** for user interactions
- **ObservableProperty** for automatic change notification

### Async Programming
- **Async/await** for database operations
- **Background tasks** for data loading
- **UI responsiveness** during long operations

### Error Handling
- **Try-catch blocks** around critical operations
- **User feedback** for validation errors
- **Transaction rollback** for data consistency

### Code Organization
- **Dependency injection** for services
- **Base classes** for common functionality
- **Consistent naming** and project structure

## 📈 Performance Optimizations

- **Compiled bindings** with x:DataType
- **Virtualization** in CollectionView
- **Async data loading** for responsive UI
- **Efficient navigation** with parameter passing

## 🔮 Future Enhancements

While all requirements are complete, potential improvements include:
- User authentication/login system
- Transaction categories and filtering
- Account transfer functionality
- Transaction receipt generation
- Offline/online synchronization
- Biometric authentication
- Dark mode support

## 📄 License

This project is for educational purposes only as part of the MAUI Banking Exercise assignment. It is not intended for production use and comes without any warranty or guarantees.

### Security & Production Readiness

- Do not enter, store, or transmit real personally identifiable information (PII) or financial data.
- No threat modeling, penetration testing, or compliance hardening has been performed.
- Databases, secrets, logging, and error handling are configured for development convenience, not security.

---

**Assignment completed successfully!** ✅
All requirements implemented with modern .NET MAUI and MVVM best practices.
