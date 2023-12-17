using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace owner_draw_month_calendar
{
    public partial class DecemberOnlyCalendar : UserControl, INotifyPropertyChanged
    {
        public DecemberOnlyCalendar() => InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            buttonYearDown.Click += (sender, e) => Year--;
            buttonYearUp.Click += (sender, e) => Year++; 
            labelYear.DataBindings.Add("Text", this, "FormattedYear", true, DataSourceUpdateMode.OnPropertyChanged);
            for (int col = 0; col < 7; col++) for (int row = 3; row < 9; row++)
                {
                    var label = new Label
                    {
                        TextAlign = ContentAlignment.MiddleCenter,
                        Padding = new Padding(0),
                        Margin = new Padding(0),
                        BackColor = Color.White,
                        Dock = DockStyle.Fill,
                    };
                    tableLayoutPanel.Controls.Add(label, col, row);
                }
            Year = DateTime.Today.Year;
        }

        public int Year
        {
            get => _year;
            set
            {
                if (!Equals(_year, value))
                {
                    _year = value;
                    OnPropertyChanged();
                }
            }
        }
        int _year = default;
        public string FormattedYear => $"December {Year}";


        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if(propertyName ==  nameof(Year)) 
            {
                OnYearChanged();
                OnPropertyChanged(nameof(FormattedYear));
            }
        }

        private void OnYearChanged()
        {
            Clear();
            var theFirst = new DateTime(Year, 12, 1);
            var today = theFirst;
            var dow = theFirst.DayOfWeek;
            int row = 3;
            int col = (int)dow;
            while(today.Month == 12)
            {
                if(tableLayoutPanel.GetControlFromPosition(col, row) is Label label)
                {
                    label.Text = $"{today.Day}";
                    col = (col + 1) % 7;
                    if (col == 0) row++;
                }
                else
                {

                }
                today = today + TimeSpan.FromDays(1);
            };
        }
        private void Clear()
        {

            for (int col = 0; col < 7; col++) for (int row = 2; row < 9; row++)
                {
                    if(tableLayoutPanel.GetControlFromPosition(col,row) is Label label) 
                        label.Text = string.Empty;
                }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
