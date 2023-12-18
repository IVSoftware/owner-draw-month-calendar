﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace owner_draw_month_calendar
{
    public partial class DecemberOnlyCalendar : UserControl, INotifyPropertyChanged
    {
        public DecemberOnlyCalendar()
        {
            InitializeComponent();
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
                        Anchor = (AnchorStyles)0xF,
                    };
                    label.Click += LabelClicked;
                    label.Paint += (sender, e) =>
                    {
                        if(
                            SelectedDay is DateTime date &&     
                            sender is Label label && 
                            int.TryParse(label.Text, out int day) &&
                            date.Day == day)
                        {
                            var rect = new Rectangle(new Point(), e.ClipRectangle.Size);
                            rect.Inflate(-5, -5);
                            e.Graphics.DrawRectangle(Pens.Red, rect);
                        }
                    };
                    tableLayoutPanel.Controls.Add(label, col, row);
                }
            Year = DateTime.Today.Year;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_origTextHeight == -1)
            {
                if (tableLayoutPanel.GetControlFromPosition(0, 3) is Label golden)
                {
                    if (_origTextHeight == -1)
                    {
                        using (Graphics g = golden.CreateGraphics())
                        {
                            _origTextHeight = g.MeasureString("00", golden.Font).Height;
                            _origRatio = _origTextHeight / golden.Height;
                        }

                        foreach (var label in tableLayoutPanel.Controls.OfType<Label>())
                        {
                            label.Resize += (sender, e) => LabelResize((Label)sender);
                        }

                        foreach (var label in tableLayoutPanelHeader.Controls.OfType<Label>())
                        {
                            label.Resize += (sender, e) => LabelResize((Label)sender);
                        }
                    }
                }
            }
        }

        private void LabelResize(Label label)
        {
            var targetHeight = _origRatio * label.Height;
            float currentSize = label.Font.Size;
            float currentHeight = label.Font.Height;
            float measHeight;
            float maxSize, minSize = 4f;

            using (Graphics g = label.CreateGraphics())
            {
                measHeight = g.MeasureString("00", label.Font).Height; // Unused. For baseline Reference only.
                while (true)
                {
                    using (var font = new Font(label.Font.FontFamily, currentSize))
                    {
                        measHeight = g.MeasureString("00", font).Height;
                    }
                    switch (measHeight.CompareTo(targetHeight))
                    {
                        case 0:
                        case -1:
                            currentSize += 10;
                            break;
                        case 1:
                            maxSize = currentSize;
                            goto breakFromInner;
                    }
                }
                breakFromInner:
                for (int i = 0; i < 10; i++)
                {
                    using (var font = new Font(label.Font.FontFamily, currentSize))
                    {
                        measHeight = g.MeasureString("00", font).Height;
                    }
                    switch (measHeight.CompareTo(targetHeight))
                    {
                        case 0:
                            goto breakFromInner2;
                        case -1:
                            minSize = currentSize;
                            currentSize = (currentSize + maxSize) / 2;
                            break;
                        case 1:
                            maxSize = currentSize;
                            currentSize = (currentSize + minSize) / 2;
                            break;
                    }
                }
                breakFromInner2:
                label.Font = new Font(label.Font.FontFamily, currentSize);
            }
        }

        float _origTextHeight = -1;
        float _origRatio = 0;
        private void OnYearChanged()
        {
            Clear();
            var theFirst = new DateTime(Year, 12, 1);
            var dayOfWeek = theFirst.DayOfWeek;
            var dayIterator = theFirst;
            int row = 3;
            int col = (int)dayOfWeek;
            while (dayIterator.Month == 12)
            {
                if (tableLayoutPanel.GetControlFromPosition(col, row) is Label label)
                {
                    label.Text = $"{dayIterator.Day}";
                    col = (col + 1) % 7;
                    if (col == 0) row++;
                }
                dayIterator = dayIterator + TimeSpan.FromDays(1);
            };
        }
        private void Clear()
        {
            SelectedDay = null;
            for (int col = 0; col < 7; col++) for (int row = 2; row < 9; row++)
                {
                    if (tableLayoutPanel.GetControlFromPosition(col, row) is Label label)
                        label.Text = string.Empty;
                }
        }

        private void LabelClicked(object? sender, EventArgs e)
        {
            if(sender is Label label && int.TryParse(label.Text, out var day)) 
            {
                SelectedDay = new DateTime(Year, 12, day);
            }
        }

        public DateTime? SelectedDay
        {
            get => _selectedDay;
            set
            {
                if (!Equals(_selectedDay, value))
                {
                    _selectedDay = value;
                    OnPropertyChanged();
                }
            }
        }
        DateTime? _selectedDay = default;

        public int Year
        {
            get => _year;
            private set
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
            switch (propertyName)
            {
                case nameof(Year):
                    OnYearChanged();
                    OnPropertyChanged(nameof(FormattedYear));
                    break;
            }
            Refresh();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
