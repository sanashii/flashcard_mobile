using flashcard_mobile.ViewModels;
using Microsoft.Maui.Controls;

namespace flashcard_mobile.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterPageViewModel();
        }

        /*private void OnNameCompleted(object sender, EventArgs e)
        {
            emailEntry.Focus();
        }

        private void OnEmailCompleted(object sender, EventArgs e)
        {
            passwordEntry.Focus();
        }

        private void OnPasswordCompleted(object sender, EventArgs e)
        {
            passwordEntry.Unfocus(); // Optionally trigger registration directly
        } */


        protected override void OnAppearing()
        {
            base.OnAppearing();
            ResetFields();
        }

        private void ResetFields()
        {
            if (BindingContext is RegisterPageViewModel viewModel)
            {
                viewModel.Name = string.Empty;
                viewModel.Email = string.Empty;
                viewModel.Password = string.Empty;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}