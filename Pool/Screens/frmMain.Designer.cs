namespace _8Pool.Screens
{
    partial class frmMain
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
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.ucSidebar = new _8Pool.UserControls.Helpers.ucSidebar();
            this.SuspendLayout();
            // 
            // flpTables
            // 
            this.flpTables.Location = new System.Drawing.Point(219, 12);
            this.flpTables.Name = "flpTables";
            this.flpTables.Size = new System.Drawing.Size(570, 384);
            this.flpTables.TabIndex = 0;
            this.flpTables.AutoScroll = true;
            // 
            // ucSidebar
            // 
            this.ucSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ucSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucSidebar.Location = new System.Drawing.Point(0, 0);
            this.ucSidebar.Name = "ucSidebar";
            this.ucSidebar.Size = new System.Drawing.Size(213, 397);
            this.ucSidebar.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(801, 397);
            this.Controls.Add(this.ucSidebar);
            this.Controls.Add(this.flpTables);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTables;
        private UserControls.Helpers.ucSidebar ucSidebar;
    }
}

