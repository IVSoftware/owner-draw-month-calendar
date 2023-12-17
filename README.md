# Owner Draw Month Calendar

The functionality that you're describing is a significant departure from the normal functioning of a `MonthCalendar`. Olivier's answer does a terrific job of explaining how to intercept `Win32` messages if your strategy is to disable the functionality that you understandably deem "pointless" using this approach. 

The reason I'm posting another answer is to offer a perspective that it's fairly straightforward to make your own control in the first place. This way you can make it do _exactly_ what you want in terms of style and function. 

If you're open to 'not' basing your solution on `MonthControl`, you might want to experiment with using `TableLayoutPanel controls to simplify making the grids you need.

[![designer][1]][1]


This layout can be provisioned with _blank_ labels in the constructor of the `UserControl` as a canvas.

```
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
                Dock = DockStyle.Fill,
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
```

___

In this minimal proof of concept, the left and right arrows decrement or increment the Year property, showing the previous/next December only. 

[![runtime][2]][2]

Changes are handled by first clearing all the numbers from all the days and then rebuilding the month of December based on the day of the week that `theFirst` falls on. 

```
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
```
