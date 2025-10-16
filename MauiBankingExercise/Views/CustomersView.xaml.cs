using MauiBankingExercise.ViewModels;

namespace MauiBankingExercise.Views;

public partial class CustomersView : BasePage
{
	public CustomersView(CustomersViewModel customersViewModel)
	{
		InitializeComponent();
        BindingContext = customersViewModel;
    }
}