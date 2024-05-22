using CommunityToolkit.Maui.Views;
using flashcard_mobile.Models;

namespace flashcard_mobile.Views
{
    public partial class CardPopUp : Popup
    {
        public CardPopUp(Deck deck)
        {
            InitializeComponent();
            BindingContext = deck;
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void OnScanButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
