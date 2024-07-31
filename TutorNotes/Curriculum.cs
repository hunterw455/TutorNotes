using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorNotes
{
    public class Curriculum
    {
        private List<string> _currentCurriculum;

        public Curriculum(string grade)
        {
            this._currentCurriculum = new List<string>();
            this._currentCurriculum = setCurriculumByGrade(grade);
        }

        public List<string> CurrentCurriculum
        {
            get
            {
                return this._currentCurriculum;
            }
        }

        public List<string> setCurriculumByGrade(string grade)
        {
            Dictionary<string, List<string>> _allCurriculum = new Dictionary<string, List<string>>();
            populateDictionary();
            // Will search through the dictionary and get the list 


            return new List<string>();
        }

        public void populateDictionary()
        {
            // See if can read in a text file with grades and topics
        }

    }
}
