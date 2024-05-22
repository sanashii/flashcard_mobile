using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace flashcard_mobile.Views
{
    public partial class ScanDeck : ContentPage
    {
        public ObservableCollection<Flashcard> Flashcards { get; set; }

        public ScanDeck()
        {
            InitializeComponent();

            Flashcards = new ObservableCollection<Flashcard>
            {
                new Flashcard { Question = "Question question. Something is questioning. What is the answer?", Answer = "This answer is behind the question." },
                new Flashcard { Question = "Another question?", Answer = "Another answer." }
            };

            BindingContext = this;
        }

        private void OnPreviousButtonClicked(object sender, EventArgs e)
        {
            int newPosition = (carouselView.Position - 1 + Flashcards.Count) % Flashcards.Count;
            carouselView.Position = newPosition;
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            int newPosition = (carouselView.Position + 1) % Flashcards.Count;
            carouselView.Position = newPosition;
        }

        private void OnCarouselViewPositionChanged(object sender, PositionChangedEventArgs e)
        {
            // Reset the IsAnswerVisible property when the position changes
            foreach (var flashcard in Flashcards)
            {
                flashcard.IsAnswerVisible = false;
            }
        }

        private bool isFrontVisible = true;
        private async void OnFlipButtonClicked(object sender, EventArgs e)
        {
            var grid = (Grid)((TappedEventArgs)e).Parameter;
            var frontCard = (Frame)grid.FindByName("FrontCard");
            var backCard = (Frame)grid.FindByName("BackCard");

            if (frontCard.IsVisible)
            {
                await frontCard.RotateYTo(90, 250, Easing.CubicIn);
                frontCard.IsVisible = false;
                backCard.IsVisible = true;
                backCard.RotationY = -90;
                await backCard.RotateYTo(0, 250, Easing.CubicOut);
            }
            else
            {
                await backCard.RotateYTo(90, 250, Easing.CubicIn);
                backCard.IsVisible = false;
                frontCard.IsVisible = true;
                frontCard.RotationY = -90;
                await frontCard.RotateYTo(0, 250, Easing.CubicOut);
            }
        }
    }

    public class Flashcard : BindableObject
    {
        private bool _isAnswerVisible;

        public string Question { get; set; }
        public string Answer { get; set; }

        public bool IsAnswerVisible
        {
            get => _isAnswerVisible;
            set
            {
                _isAnswerVisible = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Text));
            }
        }

        public string Text => IsAnswerVisible ? Answer : Question;

        public ICommand ToggleCardCommand => new Command(() =>
        {
            IsAnswerVisible = !IsAnswerVisible;
        });

    }
}
