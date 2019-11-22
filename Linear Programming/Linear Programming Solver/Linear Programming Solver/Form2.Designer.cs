namespace Linear_Programming_Solver
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.Exit = new CS_ClassLibraryTester.clsButtonPurple();
            this.chnl = new CS_ClassLibraryTester.clsButtonPurple();
            this.slcTheme1 = new CS_ClassLibraryTester.SLCTheme();
            this.slcTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(53, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 180);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coded By \r\nMohammed Al Sayed Hasan\r\nمحمد السيد محمد حسن\r\nZagzig University\r\nSecti" +
    "on 13";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Exit
            // 
            this.Exit.Customization = "9fX1/6mpqf8=";
            this.Exit.Font = new System.Drawing.Font("Verdana", 8F);
            this.Exit.Image = null;
            this.Exit.Location = new System.Drawing.Point(398, 0);
            this.Exit.Name = "Exit";
            this.Exit.NoRounding = false;
            this.Exit.Size = new System.Drawing.Size(39, 24);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "X";
            this.Exit.Transparent = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // chnl
            // 
            this.chnl.Customization = "9fX1/6mpqf8=";
            this.chnl.Font = new System.Drawing.Font("Verdana", 8F);
            this.chnl.Image = null;
            this.chnl.Location = new System.Drawing.Point(114, 301);
            this.chnl.Name = "chnl";
            this.chnl.NoRounding = false;
            this.chnl.Size = new System.Drawing.Size(208, 36);
            this.chnl.TabIndex = 2;
            this.chnl.Text = "My Youtube Channel";
            this.chnl.Transparent = false;
            this.chnl.Click += new System.EventHandler(this.chnl_Click);
            // 
            // slcTheme1
            // 
            this.slcTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(57)))), ((int)(((byte)(72)))));
            this.slcTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.slcTheme1.Controls.Add(this.chnl);
            this.slcTheme1.Controls.Add(this.Exit);
            this.slcTheme1.Controls.Add(this.label1);
            this.slcTheme1.Customization = "JRIV/zYjIP82IyD/JRIV/w==";
            this.slcTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slcTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.slcTheme1.Image = null;
            this.slcTheme1.Location = new System.Drawing.Point(0, 0);
            this.slcTheme1.Movable = true;
            this.slcTheme1.Name = "slcTheme1";
            this.slcTheme1.NoRounding = false;
            this.slcTheme1.Sizable = false;
            this.slcTheme1.Size = new System.Drawing.Size(437, 359);
            this.slcTheme1.SmartBounds = true;
            this.slcTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.slcTheme1.TabIndex = 0;
            this.slcTheme1.Text = "About";
            this.slcTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.slcTheme1.Transparent = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 359);
            this.Controls.Add(this.slcTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.slcTheme1.ResumeLayout(false);
            this.slcTheme1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CS_ClassLibraryTester.clsButtonPurple Exit;
        private CS_ClassLibraryTester.clsButtonPurple chnl;
        private CS_ClassLibraryTester.SLCTheme slcTheme1;


    }
}