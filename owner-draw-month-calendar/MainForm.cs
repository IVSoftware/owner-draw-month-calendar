namespace owner_draw_month_calendar
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            decemberOnlyCalendar.PropertyChanged += (sender, e) =>
            {
                Text = decemberOnlyCalendar.SelectedDay?.ToLongDateString() ?? string.Empty;
            };
        }
    }
}
