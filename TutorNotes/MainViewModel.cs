using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TutorNotes
{
    /// <summary>
    /// Helps with the handling of the cells in the weekly schedule
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ScheduleCell> _scheduleCells;

        public ObservableCollection<ScheduleCell> ScheduleCells
        {
            get { return _scheduleCells; }
            set
            {
                _scheduleCells = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            ScheduleCells = new ObservableCollection<ScheduleCell>();

            // Add cells for each row you want to create
            for (int row = 5; row <= 7; row++) // Example: Rows 5, 6, 7
            {
                for (int col = 2; col <= 8; col++) // Example: Columns 2 to 8
                {
                    // Determine border thickness based on column position
                    string borderThickness = "0,0,0,0"; // Example: Modify as per your requirements

                    // Create a new ScheduleCell object and add it to the collection
                    ScheduleCells.Add(new ScheduleCell(row, col, borderThickness));
                }
            }
        }
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ScheduleCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string BorderThickness { get; set; } // Optional: If you need to adjust border thickness

        public ScheduleCell(int row, int column, string borderThickness)
        {
            Row = row;
            Column = column;
            BorderThickness = borderThickness;
        }
    }
}
