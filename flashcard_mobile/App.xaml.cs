using flashcard_mobile.Views;
using flashcard_mobile.Services;
using CommunityToolkit.Maui;
using System.ComponentModel;

namespace flashcard_mobile
{
    public partial class App : Application
    {
        public static DataService DataService { get; private set; }
        public static string CurrentUserEmail { get; set; }

        public static SessionService SessionService { get; private set; }   


        public App()
        {
            InitializeComponent();

            // Initialize the DataService as an in-memory service
            SessionService = new SessionService();
            DataService = new DataService();

            MainPage = new AppShell();
        }
    }
}   