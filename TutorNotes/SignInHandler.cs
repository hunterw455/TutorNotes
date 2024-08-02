using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TutorNotes
{
    public class SignInHandler
    {
        private Dictionary<string, User> _userDataBase;
        public SignInHandler(Dictionary <string, User> userDataBase) { 
            this._userDataBase = userDataBase;
        }

        public Dictionary<string, User> UserDataBase 
        {
            get 
            { 
                return _userDataBase; 
            }
            set
            {
                this._userDataBase = value;
            } 
        }

        public bool userFound(string user)
        {
            return UserDataBase.ContainsKey(user);
        }
        public bool successfulSignIn(string user, string password)
        {
            return UserDataBase[user].Password == password;
        }
        public void signIn(string user, string password, Window win)
        {
            if (userFound(user)) {
                if (successfulSignIn(user, password))
                {
                    App.CurrentUser = App.TutorNotesUsers[user];
                    // Will load in new window once user inputs valid login credentials
                    HomeScreen homeScreen = new HomeScreen();
                    win.Visibility = Visibility.Hidden;
                    homeScreen.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
        }
    }
}
// I would like to be able to implement hashing into here in the future to protect password data