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
            pickerDecemberOnly = new DecemberOnlyPicker();
            label1 = new Label();
            SuspendLayout();
            // 
            // pickerDecemberOnly
            // 
            pickerDecemberOnly.BackColor = Color.White;
            pickerDecemberOnly.Location = new Point(98, 30);
            pickerDecemberOnly.Name = "pickerDecemberOnly";
            pickerDecemberOnly.Size = new Size(211, 35);
            pickerDecemberOnly.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 36);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 2;
            label1.Text = "Picker";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 244);
            Controls.Add(label1);
            Controls.Add(pickerDecemberOnly);
            Name = "MainForm";
            Padding = new Padding(10);
            Text = "Main Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DecemberOnlyPicker pickerDecemberOnly;
        private Label label1;
    }
}
