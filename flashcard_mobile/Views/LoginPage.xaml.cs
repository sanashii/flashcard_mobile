using flashcard_mobile.ViewModels; // Adjust this to the correct namespace where LoginPageViewModel is defined
using Microsoft.Maui.Controls;
using System;

namespace flashcard_mobile.Views;
public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginPageViewModel();
    }

     /* private void OnEmailCompleted(object sender, EventArgs e)
    {
        passwordEntry.Focus();
    } */

    private void OnPasswordCompleted(object sender, EventArgs e)
    {
        if (this.BindingContext is LoginPageViewModel loginViewModel)
        {
            loginViewModel.LoginCommand.Execute(null);
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ResetFields();
    }

    private void ResetFields()
    {
        if (BindingContext is LoginPageViewModel viewModel)
        {
            viewModel.Email = string.Empty;
            viewModel.Password = string.Empty;
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}