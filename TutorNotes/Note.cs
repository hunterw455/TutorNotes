using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorNotes
{
    public class Note
    {
        private Dictionary<DateTime, string> _noteCollection;

        public Note(){
            this._noteCollection = new Dictionary<DateTime, string>();
        }
        ~Note(){ }

        // Properties
        public Dictionary<DateTime, string> NoteCollection
        {
            get 
            {
                return this._noteCollection;
            }
            set
            {
                this._noteCollection = value;
            }
        }

        // Methods
        public void addNote(string s, DateTime day)
        {
            if (!this._noteCollection.ContainsKey(day))
            {
                this._noteCollection.Add(day, s);
            }
            else
            {
                this._noteCollection[day] = s;
            }
        }

        public string getNote(DateTime day)
        {
            if (this._noteCollection.Count != 0 && this._noteCollection.ContainsKey(day)) {
                var note = this._noteCollection[day];
                return note;
            }
            return "";
        }

        public bool containsNote(DateTime day)
        {
            if (this._noteCollection.Count != 0 && this._noteCollection.ContainsKey(day))
            {
                return true;
            }
            return false;
        }
    }
}

