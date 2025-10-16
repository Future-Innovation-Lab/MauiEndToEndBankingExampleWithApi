using MauiBankingExercise.ViewModels;

namespace MauiBankingExercise.Views
{
    public partial class CreateTransactionView : BasePage
    {
        public CreateTransactionView(CreateTransactionViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
