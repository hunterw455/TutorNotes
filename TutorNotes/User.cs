using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorNotes
{
    public class User
    {
        private string _username;
        private string _password;
        private readonly int _userID;
        private string _firstName;
        private string _lastName;
        private static int count = 0;

        public User(string username, string password, string fName, string lName)
        {
            this._username = username;
            this._password = password;
            this._firstName = fName;
            this._lastName = lName;
            this._userID = count;
            count++;
        }
        ~User() { }


        // Properties
        public string Username
        {
            get 
            { 
                return this._username; 
            }
            set
            {
                this._username = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this._firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this._lastName;
            }
        }

        public int UserId
        {
            get
            {
                return this._userID;
            }
        }
    }
}