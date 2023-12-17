namespace owner_draw_month_calendar
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            decemberOnlyCalendar = new DecemberOnlyCalendar();
            SuspendLayout();
            // 
            // decemberOnlyCalendar
            // 
            decemberOnlyCalendar.Dock = DockStyle.Fill;
            decemberOnlyCalendar.Location = new Point(0, 0);
            decemberOnlyCalendar.Name = "decemberOnlyCalendar";
            decemberOnlyCalendar.Size = new Size(478, 294);
            decemberOnlyCalendar.TabIndex = 0;
            decemberOnlyCalendar.Year = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 294);
            Controls.Add(decemberOnlyCalendar);
            Name = "MainForm";
            Text = "Main Form";
            ResumeLayout(false);
        }

        #endregion

        private DecemberOnlyCalendar decemberOnlyCalendar;
    }
}
