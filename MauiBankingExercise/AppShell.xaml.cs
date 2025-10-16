namespace MauiBankingExercise
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("CustomerDashboardView", typeof(Views.CustomerDashboardView));
            Routing.RegisterRoute("AccountDetailsView", typeof(Views.AccountDetailsView));
            Routing.RegisterRoute("CreateTransactionView", typeof(Views.CreateTransactionView));
        }
    }
}
