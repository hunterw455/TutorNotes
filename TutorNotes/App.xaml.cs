using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TutorNotes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Dictionary<string, User> TutorNotesUsers { get; set; } = new Dictionary<string, User>(); // Probably not most secure, but will in future make better
        public static User CurrentUser { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the dictionary for user accounts
            User user1 = new User("user1","abc123", "Jane", "Doe");
            User user2 = new User("user2", "123abc", "John", "Doe");
            TutorNotesUsers = new Dictionary<string, User>
            {
                
                { user1.Username, user1},
                { user2.Username, user2}
            };

            // Shows the main window with log in screen
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
