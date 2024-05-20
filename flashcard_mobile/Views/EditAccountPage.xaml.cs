using flashcard_mobile.ViewModels;

namespace flashcard_mobile.Views
{
    public partial class EditAccountPage : ContentPage
    {
        public EditAccountPage()
        {
            InitializeComponent();
            BindingContext = new EditAccountViewModel();
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            // Implement navigation or feedback after saving changes
            await DisplayAlert("Success", "Account details updated", "OK");
        }
    }
}