using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorNotes
{
    public class Educator : User
    {
        private ObservableCollection<Student> _studentsAssigned;
        private Schedule _scheduleWeek;
        private string _userType;

        public Educator(string username, string password, string fName, string lName, string type) : base(username, password, fName, lName)
        {
            this._userType = type; //If I were to expand it into different user types like educators, students, and supervisors
            this._studentsAssigned = new ObservableCollection<Student>();
        }

        public void editStudentList()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Student> StudentsAssigned
        {
            get
            {
                return this._studentsAssigned;
            }
        }

        public Schedule ScheduleWeek
        {
            get
            {
                return this._scheduleWeek;
            }
            set
            {
                this._scheduleWeek = value;
            }
        }

        public void addStudentToList(Student s)
        {
            this._studentsAssigned.Add(s);
        }
    }
}
