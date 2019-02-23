namespace MultiFaceRec
{
    partial class FrmAttendanceRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAttendanceRecords));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.txtModule2 = new System.Windows.Forms.TextBox();
            this.txtClass2 = new System.Windows.Forms.TextBox();
            this.txtDate2 = new System.Windows.Forms.TextBox();
            this.txtTime2 = new System.Windows.Forms.TextBox();
            this.btninsert = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnclearalldata = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAttendance = new System.Windows.Forms.ComboBox();
            this.btnExportAttendanceRecordsToExcel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyAttendanceSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Module Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Class:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Time:";
            // 
            // txtName2
            // 
            this.txtName2.Location = new System.Drawing.Point(12, 72);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(220, 26);
            this.txtName2.TabIndex = 6;
            // 
            // txtModule2
            // 
            this.txtModule2.Location = new System.Drawing.Point(12, 151);
            this.txtModule2.Name = "txtModule2";
            this.txtModule2.Size = new System.Drawing.Size(220, 26);
            this.txtModule2.TabIndex = 7;
            // 
            // txtClass2
            // 
            this.txtClass2.Location = new System.Drawing.Point(12, 217);
            this.txtClass2.Name = "txtClass2";
            this.txtClass2.Size = new System.Drawing.Size(220, 26);
            this.txtClass2.TabIndex = 8;
            // 
            // txtDate2
            // 
            this.txtDate2.Location = new System.Drawing.Point(16, 289);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Size = new System.Drawing.Size(220, 26);
            this.txtDate2.TabIndex = 9;
            // 
            // txtTime2
            // 
            this.txtTime2.Location = new System.Drawing.Point(16, 365);
            this.txtTime2.Name = "txtTime2";
            this.txtTime2.Size = new System.Drawing.Size(220, 26);
            this.txtTime2.TabIndex = 10;
            // 
            // btninsert
            // 
            this.btninsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninsert.Location = new System.Drawing.Point(366, 787);
            this.btninsert.Name = "btninsert";
            this.btninsert.Size = new System.Drawing.Size(157, 48);
            this.btninsert.TabIndex = 11;
            this.btninsert.Text = "Insert";
            this.btninsert.UseVisualStyleBackColor = true;
            this.btninsert.Click += new System.EventHandler(this.btninsert_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.Location = new System.Drawing.Point(576, 787);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(322, 48);
            this.btnupdate.TabIndex = 12;
            this.btnupdate.Text = "Update Attendance Records";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnclearalldata
            // 
            this.btnclearalldata.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclearalldata.Location = new System.Drawing.Point(914, 787);
            this.btnclearalldata.Name = "btnclearalldata";
            this.btnclearalldata.Size = new System.Drawing.Size(314, 48);
            this.btnclearalldata.TabIndex = 14;
            this.btnclearalldata.Text = "Clear Attendance Records";
            this.btnclearalldata.UseVisualStyleBackColor = true;
            this.btnclearalldata.Click += new System.EventHandler(this.btnclearalldata_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(253, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1202, 712);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(366, 859);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(240, 48);
            this.btnLogOut.TabIndex = 21;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Attendance:";
            // 
            // cmbAttendance
            // 
            this.cmbAttendance.FormattingEnabled = true;
            this.cmbAttendance.Items.AddRange(new object[] {
            "Present",
            "Absent"});
            this.cmbAttendance.Location = new System.Drawing.Point(16, 443);
            this.cmbAttendance.Name = "cmbAttendance";
            this.cmbAttendance.Size = new System.Drawing.Size(220, 28);
            this.cmbAttendance.TabIndex = 24;
            // 
            // btnExportAttendanceRecordsToExcel
            // 
            this.btnExportAttendanceRecordsToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportAttendanceRecordsToExcel.Location = new System.Drawing.Point(967, 859);
            this.btnExportAttendanceRecordsToExcel.Name = "btnExportAttendanceRecordsToExcel";
            this.btnExportAttendanceRecordsToExcel.Size = new System.Drawing.Size(261, 48);
            this.btnExportAttendanceRecordsToExcel.TabIndex = 25;
            this.btnExportAttendanceRecordsToExcel.Text = "Export to excel";
            this.btnExportAttendanceRecordsToExcel.UseVisualStyleBackColor = true;
            this.btnExportAttendanceRecordsToExcel.Visible = false;
            this.btnExportAttendanceRecordsToExcel.Click += new System.EventHandler(this.btnExportAttendanceRecordsToExcel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1456, 33);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.modifyAttendanceSheetToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(297, 30);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(297, 30);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // modifyAttendanceSheetToolStripMenuItem
            // 
            this.modifyAttendanceSheetToolStripMenuItem.Name = "modifyAttendanceSheetToolStripMenuItem";
            this.modifyAttendanceSheetToolStripMenuItem.Size = new System.Drawing.Size(297, 30);
            this.modifyAttendanceSheetToolStripMenuItem.Text = "Modify Attendance Sheet";
            this.modifyAttendanceSheetToolStripMenuItem.Click += new System.EventHandler(this.modifyAttendanceSheetToolStripMenuItem_Click);
            // 
            // FrmAttendanceRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1456, 919);
            this.Controls.Add(this.btnExportAttendanceRecordsToExcel);
            this.Controls.Add(this.cmbAttendance);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnclearalldata);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btninsert);
            this.Controls.Add(this.txtTime2);
            this.Controls.Add(this.txtDate2);
            this.Controls.Add(this.txtClass2);
            this.Controls.Add(this.txtModule2);
            this.Controls.Add(this.txtName2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmAttendanceRecords";
            this.Text = "Attendance Records";
            this.Load += new System.EventHandler(this.FrmAttendanceRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName2;
        private System.Windows.Forms.TextBox txtModule2;
        private System.Windows.Forms.TextBox txtClass2;
        private System.Windows.Forms.TextBox txtDate2;
        private System.Windows.Forms.TextBox txtTime2;
        private System.Windows.Forms.Button btninsert;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnclearalldata;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbAttendance;
        private System.Windows.Forms.Button btnExportAttendanceRecordsToExcel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyAttendanceSheetToolStripMenuItem;
    }
}