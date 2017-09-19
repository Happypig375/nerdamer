namespace NerdamerMarkdownGen
{
    partial class Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel = new System.Windows.Forms.TableLayoutPanel();
            this.In = new System.Windows.Forms.TextBox();
            this.Out = new System.Windows.Forms.TextBox();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.Top = new System.Windows.Forms.FlowLayoutPanel();
            this.TimeoutLabel = new System.Windows.Forms.Label();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.Panel.SuspendLayout();
            this.Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.ColumnCount = 1;
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Panel.Controls.Add(this.In, 0, 1);
            this.Panel.Controls.Add(this.Out, 0, 2);
            this.Panel.Controls.Add(this.Progress, 0, 3);
            this.Panel.Controls.Add(this.Top, 0, 0);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.RowCount = 4;
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Panel.Size = new System.Drawing.Size(284, 261);
            this.Panel.TabIndex = 0;
            // 
            // In
            // 
            this.In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.In.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.In.Location = new System.Drawing.Point(3, 33);
            this.In.MaxLength = 2147483647;
            this.In.Multiline = true;
            this.In.Name = "In";
            this.In.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.In.Size = new System.Drawing.Size(278, 99);
            this.In.TabIndex = 0;
            this.In.Text = "run|";
            this.In.TextChanged += new System.EventHandler(this.In_TextChanged);
            // 
            // Out
            // 
            this.Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Out.Location = new System.Drawing.Point(3, 138);
            this.Out.MaxLength = 2147483647;
            this.Out.Multiline = true;
            this.Out.Name = "Out";
            this.Out.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Out.Size = new System.Drawing.Size(278, 99);
            this.Out.TabIndex = 1;
            this.Out.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_KeyDown);
            // 
            // Progress
            // 
            this.Progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Progress.Location = new System.Drawing.Point(3, 243);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(278, 15);
            this.Progress.TabIndex = 2;
            // 
            // Top
            // 
            this.Top.Controls.Add(this.TimeoutLabel);
            this.Top.Controls.Add(this.TimePicker);
            this.Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Top.Location = new System.Drawing.Point(3, 3);
            this.Top.Name = "Top";
            this.Top.Size = new System.Drawing.Size(278, 24);
            this.Top.TabIndex = 3;
            // 
            // TimeoutLabel
            // 
            this.TimeoutLabel.Location = new System.Drawing.Point(3, 0);
            this.TimeoutLabel.Name = "TimeoutLabel";
            this.TimeoutLabel.Size = new System.Drawing.Size(72, 24);
            this.TimeoutLabel.TabIndex = 0;
            this.TimeoutLabel.Text = "Timeout after:";
            this.TimeoutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimePicker
            // 
            this.TimePicker.CustomFormat = "H:mm:ss";
            this.TimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePicker.Location = new System.Drawing.Point(81, 3);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.ShowUpDown = true;
            this.TimePicker.Size = new System.Drawing.Size(183, 20);
            this.TimePicker.TabIndex = 1;
            this.TimePicker.Value = new System.DateTime(2017, 9, 16, 0, 0, 30, 0);
            this.TimePicker.ValueChanged += new System.EventHandler(this.TimePicker_ValueChanged);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Panel);
            this.Name = "Form";
            this.Text = "Nerdamer Tester";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Panel;
        private System.Windows.Forms.TextBox In;
        private System.Windows.Forms.TextBox Out;
        private System.Windows.Forms.ProgressBar Progress;
        private new System.Windows.Forms.FlowLayoutPanel Top;
        private System.Windows.Forms.Label TimeoutLabel;
        private System.Windows.Forms.DateTimePicker TimePicker;
    }
}

