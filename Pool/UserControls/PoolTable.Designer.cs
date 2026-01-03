namespace _8Pool
{
    partial class PoolTable
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
            this.components = new System.ComponentModel.Container();
            this.grpTable = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.cmsPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpTable.SuspendLayout();
            this.cmsPlayer.SuspendLayout();
            this.cmsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTable
            // 
            this.grpTable.ContextMenuStrip = this.cmsTable;
            this.grpTable.Controls.Add(this.lblTime);
            this.grpTable.Controls.Add(this.btnEnd);
            this.grpTable.Controls.Add(this.btnStartStop);
            this.grpTable.Controls.Add(this.panel1);
            this.grpTable.Controls.Add(this.lblName);
            this.grpTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTable.ForeColor = System.Drawing.Color.White;
            this.grpTable.Location = new System.Drawing.Point(3, 3);
            this.grpTable.Name = "grpTable";
            this.grpTable.Size = new System.Drawing.Size(267, 179);
            this.grpTable.TabIndex = 5;
            this.grpTable.TabStop = false;
            this.grpTable.Text = "Tabel 1";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(27, 134);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(134, 35);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEnd.ForeColor = System.Drawing.Color.White;
            this.btnEnd.Location = new System.Drawing.Point(186, 105);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(73, 36);
            this.btnEnd.TabIndex = 8;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStartStop.ForeColor = System.Drawing.Color.White;
            this.btnStartStop.Location = new System.Drawing.Point(186, 61);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(73, 38);
            this.btnStartStop.TabIndex = 7;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::_8Pool.Properties.Resources.pool;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(19, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 63);
            this.panel1.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.ContextMenuStrip = this.cmsPlayer;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(255, 33);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Player";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsPlayer
            // 
            this.cmsPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.cmsPlayer.Name = "cmsPlayer";
            this.cmsPlayer.Size = new System.Drawing.Size(161, 29);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmsTable
            // 
            this.cmsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.cmsTable.Name = "cmsTable";
            this.cmsTable.Size = new System.Drawing.Size(181, 70);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // PoolTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.grpTable);
            this.DoubleBuffered = true;
            this.Name = "PoolTable";
            this.Size = new System.Drawing.Size(274, 184);
            this.Load += new System.EventHandler(this.PoolTable_Load);
            this.grpTable.ResumeLayout(false);
            this.cmsPlayer.ResumeLayout(false);
            this.cmsPlayer.PerformLayout();
            this.cmsTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTable;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip cmsPlayer;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmsTable;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
    }
}
