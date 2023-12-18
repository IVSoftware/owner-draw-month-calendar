using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace owner_draw_month_calendar
{
    public partial class DecemberOnlyPicker : UserControl
    {
        public DecemberOnlyPicker()
        {
            InitializeComponent();
            labelPick.Click += (sender, e) =>
            {
                BeginInvoke(() => 
                {
                    var screen = labelSelected.PointToScreen(new Point(-10, labelSelected.Bottom));
                    picker.Location = screen;
                    picker.ShowDialog(this);
                });
            };
            Disposed += (sender, e) => picker.Dispose();
            picker.Calendar.PropertyChanged += (sender, e) =>
            {
                if(picker.Calendar.SelectedDay != null)
                {
                    labelSelected.Text = picker.Calendar.SelectedDay?.ToShortDateString();
                }
            };
        }
        readonly PickerForm picker = new PickerForm();
    }
    class PickerForm : Form, INotifyPropertyChanged, IMessageFilter
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public PickerForm()
        {
            StartPosition = FormStartPosition.Manual;
            ClientSize = new Size(400, 250);
            Controls.Add(Calendar);
            Calendar.PropertyChanged += (sender, e) =>
            {
                if(e.PropertyName == nameof(Calendar.SelectedDay))
                {
                    if(Calendar.SelectedDay != null) 
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            };
            Application.AddMessageFilter(this);
            Disposed += (sender, e) => Application.RemoveMessageFilter(this);
        }
        public DecemberOnlyCalendar Calendar { get; } = new DecemberOnlyCalendar
        {
            Dock = DockStyle.Fill,
        };
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HTCAPTION = 0x2;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
            {
                return true;
            }
            return false;
        }
    }
}
