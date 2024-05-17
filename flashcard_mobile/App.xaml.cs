using flashcard_mobile.Views;
using flashcard_mobile.Services;
using System.IO;
using Microsoft.Maui.Storage;

namespace flashcard_mobile
{
    public partial class App : Application
    {
        public static DataService DataService { get; private set; }

        public App()
        {
            InitializeComponent();

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "userdatabase.db");
            DataService = new DataService(dbPath);


            MainPage = new AppShell();
        }
    }
}
