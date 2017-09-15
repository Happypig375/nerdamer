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
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.ColumnCount = 1;
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel.Controls.Add(this.In, 0, 0);
            this.Panel.Controls.Add(this.Out, 0, 1);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.RowCount = 2;
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel.Size = new System.Drawing.Size(284, 261);
            this.Panel.TabIndex = 0;
            // 
            // In
            // 
            this.In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.In.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.In.Location = new System.Drawing.Point(3, 3);
            this.In.Multiline = true;
            this.In.Name = "In";
            this.In.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.In.Size = new System.Drawing.Size(278, 124);
            this.In.TabIndex = 0;
            this.In.TextChanged += new System.EventHandler(this.In_TextChanged);
            // 
            // Out
            // 
            this.Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Out.Location = new System.Drawing.Point(3, 133);
            this.Out.Multiline = true;
            this.Out.Name = "Out";
            this.Out.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Out.Size = new System.Drawing.Size(278, 125);
            this.Out.TabIndex = 1;
            this.Out.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_KeyDown);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Panel);
            this.Name = "Form";
            this.Text = "Form1";
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Panel;
        private System.Windows.Forms.TextBox In;
        private System.Windows.Forms.TextBox Out;
    }
}

