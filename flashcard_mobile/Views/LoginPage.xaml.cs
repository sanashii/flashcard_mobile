namespace flashcard_mobile.Views;
using flashcard_mobile.ViewModels; // Adjust this to the correct namespace where LoginPageViewModel is defined
using Microsoft.Maui.Controls;
using System;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginPageViewModel();
    }
}

