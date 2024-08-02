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
        private string _grade;
        private string _level;
        private Note _studentNotes;
        private string _academicGoal;
        private Educator _assignedEducator;
        private Curriculum _studentCurriculum;

        public Student(string fName, string lName, string level, string goals)
        {
            this._firstName = fName;
            this._lastName = lName;
            this._level = level;
            this._academicGoal = goals;
            this._assignedEducator = ((Educator)App.CurrentUser);
            this._studentNotes = new Note();
            this._grade = "";
            this._studentCurriculum = new Curriculum(level);
        }

        public Student(Student s)
        {
            this._firstName = s.FirstName;
            this._lastName = s.LastName;
            this._level = s.Level;
            this._assignedEducator = s.AssignedEducator;
            this._academicGoal = s.AcademicGoal;
            this._studentNotes = s.StudentNotes;
            this._studentCurriculum = s.StudentCurriculum;
            this._grade = s.Grade;
        }

        ~Student()
        {

        }

        public Curriculum StudentCurriculum
        {
            get
            {
                return this._studentCurriculum;
            }
            set
            {
                this._studentCurriculum = value;
            }
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

        public Educator AssignedEducator
        {
            get
            {
                return this._assignedEducator;
            }
        }

        public Note StudentNotes
        {
            get
            {
                return this._studentNotes;
            }
        }

        public string Grade
        {
            get
            {
                return this._grade;
            }
            set
            {
                this._grade = value;
            }
        }
    }
}
