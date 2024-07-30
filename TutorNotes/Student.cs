using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorNotes
{
    public class Student
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private char _grade;
        private string _level;
        private Note _studentNotes;
        private string _academicGoal;
        private Educator _assignedEducator;
        private string _displayName;

        public Student(string fName, string lName, string level, string goals)
        {
            this._firstName = fName;
            this._lastName = lName;
            this._level = level;
            this._academicGoal = goals;
            this._assignedEducator = ((Educator)App.CurrentUser);
        }



        public string DisplayName{
            get 
            { 
                return this._firstName + " " + this._lastName[0];
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

        public string Level
        {
            get
            {
                return this._level;
            }
        }

        public string AcademicGoal
        {
            get
            {
                return this._academicGoal;
            }
            set
            {
                this._academicGoal = value;
            }
        }

        public char Grade
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
