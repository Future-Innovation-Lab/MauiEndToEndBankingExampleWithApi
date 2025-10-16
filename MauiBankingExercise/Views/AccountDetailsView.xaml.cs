using MauiBankingExercise.ViewModels;

namespace MauiBankingExercise.Views
{
    public partial class AccountDetailsView : BasePage
    {
        public AccountDetailsView(AccountDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
