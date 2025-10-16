using MauiBankingExercise.ViewModels;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MauiBankingExercise.Views
{
    public abstract class BasePage : ContentPage
    {
        private bool _hasAppeared = false;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is BaseViewModel viewModel)
            {
                // Call OnFirstAppearAsync only on the first appearance
                if (!_hasAppeared)
                {
                    _hasAppeared = true;
                    await viewModel.OnFirstAppearAsync();
                }

                // Always call OnAppearingAsync
                await viewModel.OnAppearingAsync();
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is BaseViewModel viewModel)
            {
                await viewModel.OnDisappearingAsync();
            }
        }
    }
}
