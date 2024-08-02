using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;

namespace TutorNotes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Dictionary<string, User> TutorNotesUsers { get; set; } = new Dictionary<string, User>(); // Probably not most secure, but will in future make better
        public static User CurrentUser { get; set; }
        public static Dictionary<string, List<string>> allCurriculum { get; set; } = new Dictionary<string, List<string>>();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the dictionary for user accounts
            Educator user1 = new Educator("user1","abc123", "Jane", "Doe", "Educator");
            Educator user2 = new Educator("user2", "123abc", "John", "Doe", "Educator");
            TutorNotesUsers = new Dictionary<string, User>
            {
                
                { user1.Username, user1},
                { user2.Username, user2}
            };

            // Get the file path using relative path
            string jsonFilePath = "curriculum.json"; // Assumes the file is in the same directory as the executable
            string jsonContent = File.ReadAllText(jsonFilePath);
            allCurriculum = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonContent);

            foreach(var topic in allCurriculum["1st"])
            {
                Console.WriteLine(topic);
            }


        }
    }
}
