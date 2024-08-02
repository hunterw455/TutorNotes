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
        private ObservableCollection<CellInfo> _cells;
        private string _userType;

        public Educator(string username, string password, string fName, string lName, string type) : base(username, password, fName, lName)
        {
            this._userType = type; //If I were to expand it into different user types like educators, students, and supervisors
            this._studentsAssigned = new ObservableCollection<Student>();
            this._cells = new ObservableCollection<CellInfo>();
        }

        public ObservableCollection<CellInfo> Cells
        {
            get
            {
                return this._cells;
            }
            set
            {
                this._cells = value;
            }
        }

        public ObservableCollection<Student> StudentsAssigned
        {
            get
            {
                return this._studentsAssigned;
            }
        }

        public void addStudentToList(Student s)
        {
            this._studentsAssigned.Add(s);
        }

        public void removeStudent(Student s){
            this._studentsAssigned.Remove(s);
        }

        public void addToCell(CellInfo c)
        {
            this._cells.Add(c);
        }
    }
}
