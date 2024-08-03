using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace TutorNotes
{
    public class CellInfo : INotifyPropertyChanged
    {
        private Brush _fill;
        public bool _emptiness;

        public CellInfo(string name, Brush borderBrush, Thickness borderThickness, int row, int col, Brush fill)
        {
            CellName = name;
            BorderBrush = borderBrush;
            BorderThickness = borderThickness;
            Fill = fill;
            Emptiness = true; // Will initially be empty when setting up the program.
        }
        ~CellInfo() { }

        // Properties
        public string CellName { get; set; }
        public Brush BorderBrush { get; set; }
        public Thickness BorderThickness { get; set; }

        public bool Emptiness
        {
            get
            {
                return this._emptiness;
            }
            set
            {
                if (_emptiness != value)
                {
                    _emptiness = value;
                    OnPropertyChanged(nameof(Emptiness));
                }
            }
        }

        public Brush Fill
        {
            get
            {
                return this._fill;
            }
            set
            {
                if (this._fill != value)
                {
                    this._fill = value;
                    OnPropertyChanged(nameof(Fill));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
