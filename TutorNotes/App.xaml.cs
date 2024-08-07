﻿using System;
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
        public static SignInHandler signInHandler { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the dictionary for user accounts as demonstration
            Educator user1 = new Educator("user1","abc123", "Jane", "Doe", "Educator");
            Educator user2 = new Educator("user2", "123abc", "John", "Doe", "Educator");
            TutorNotesUsers = new Dictionary<string, User>
            {
                
                { user1.Username, user1},
                { user2.Username, user2}
            };
            signInHandler = new SignInHandler(TutorNotesUsers);

            // Gets the information from the json file 
            string jsonFilePath = "curriculum.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            allCurriculum = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonContent);
        }
    }
}
