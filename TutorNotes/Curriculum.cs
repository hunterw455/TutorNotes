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
            this._currentCurriculum = App.allCurriculum[grade];
        }

        ~Curriculum() { }

        public List<string> CurrentCurriculum
        {
            get
            {
                return this._currentCurriculum;
            }
            set
            {
                this._currentCurriculum = value;
            }
        }

        public void removeTopic(string topic)
        {
            CurrentCurriculum.Remove(topic);
        }

        public string currentTopic()
        {
            return CurrentCurriculum[0];
        }
    }
}
