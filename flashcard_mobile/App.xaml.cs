using flashcard_mobile.Views;
using flashcard_mobile.Services;

namespace flashcard_mobile
{
    public partial class App : Application
    {
        public static DataService DataService { get; private set; }
        public static string CurrentUserEmail { get; set; }

        public App()
        {
            InitializeComponent();

            // Initialize the DataService as an in-memory service
            DataService = new DataService();

            MainPage = new AppShell();
        }
    }
}