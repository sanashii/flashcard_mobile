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
    }
}