using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace MauiBankingExercise.ViewModels
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string title = string.Empty;

        /// <summary>
        /// Called when the associated page is appearing
        /// </summary>
        public virtual Task OnAppearingAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when the associated page is disappearing
        /// </summary>
        public virtual Task OnDisappearingAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when the associated page is loaded for the first time
        /// </summary>
        public virtual Task OnFirstAppearAsync()
        {
            return Task.CompletedTask;
        }
    }
}
