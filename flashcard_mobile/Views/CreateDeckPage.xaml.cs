using System;
using System.Collections.ObjectModel;

namespace flashcard_mobile.Views
{
    public partial class CreateDeckPage : ContentPage
    {
        public ObservableCollection<QuestionAnswer> Questions { get; set; }

        public CreateDeckPage()
        {
            InitializeComponent();
            Questions = new ObservableCollection<QuestionAnswer>();
            QuestionsCollectionView.ItemsSource = Questions;
        }

        private void OnCreateButtonClicked(object sender, EventArgs e)
        {
            // Add logic for creating the deck
            string title = TitleEntry.Text;
            string description = DescriptionEntry.Text;
            string category = (string)CategoryPicker.SelectedItem;

            // Example: Display an alert for now
            DisplayAlert("Deck Created", $"Title: {title}\nDescription: {description}\nCategory: {category}", "OK");
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            // Add logic for adding a question and answer
            string question = QuestionEntry.Text;
            string answer = AnswerEntry.Text;

            if (!string.IsNullOrWhiteSpace(question) && !string.IsNullOrWhiteSpace(answer))
            {
                Questions.Add(new QuestionAnswer { Question = question, Answer = answer });
                QuestionEntry.Text = string.Empty;
                AnswerEntry.Text = string.Empty;
            }
            else
            {
                DisplayAlert("Error", "Please enter both a question and an answer.", "OK");
            }
        }
    }

    public class QuestionAnswer
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
