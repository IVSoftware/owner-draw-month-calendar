namespace owner_draw_month_calendar
{
    partial class DecemberOnlyPicker
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            labelPick = new Label();
            labelSelected = new Label();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            this.BackColor = Color.White;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.Controls.Add(labelPick, 1, 0);
            tableLayoutPanel.Controls.Add(labelSelected, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(240, 38);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelPick
            // 
            labelPick.AutoSize = true;
            labelPick.BackColor = Color.LightGray;
            labelPick.Dock = DockStyle.Fill;
            labelPick.Location = new Point(203, 0);
            labelPick.Name = "labelPick";
            labelPick.Size = new Size(34, 38);
            labelPick.TabIndex = 0;
            labelPick.Text = "ᐁ";
            labelPick.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            labelSelected.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelSelected.Location = new Point(3, 3);
            labelSelected.Name = "labelSelected";
            labelSelected.Size = new Size(194, 31);
            labelSelected.TabIndex = 1;
            // 
            // DecemberOnlyPicker
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "DecemberOnlyPicker";
            Size = new Size(240, 38);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        private TableLayoutPanel tableLayoutPanel;
        #endregion

        private Label labelPick;
        private Label labelSelected;
    }
}
