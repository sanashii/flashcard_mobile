// Located in DataService.cs within the Services folder
using flashcard_mobile.Models;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace flashcard_mobile.Services
{
    public class DataService
    {
        private readonly string _dbPath;

        public DataService(string dbPath)
        {
            _dbPath = dbPath;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection($"Filename={_dbPath}");
            connection.Open();

            var command = new SqliteCommand("CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Email TEXT UNIQUE, Password TEXT)", connection);
            command.ExecuteNonQuery();
        }

        public async Task AddUserAsync(User user)
        {
            using var connection = new SqliteConnection($"Filename={_dbPath}");
            await connection.OpenAsync();

            var command = new SqliteCommand("INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)", connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<User> GetUserAsync(string email)
        {
            using var connection = new SqliteConnection($"Filename={_dbPath}");
            await connection.OpenAsync();

            var command = new SqliteCommand("SELECT * FROM Users WHERE Email = @Email", connection);
            command.Parameters.AddWithValue("@Email", email);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3)
                };
            }

            return null;
        }
    }
}
