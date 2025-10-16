using MauiBankingExercise.Models;
using MauiBankingExercise.ViewModels;
using System;
using Microsoft.Maui.Controls;

namespace MauiBankingExercise.Views
{
    public partial class CustomerDashboardView : BasePage
    {
        public CustomerDashboardView(CustomerDashboardViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
