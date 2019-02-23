namespace MultiFaceRec
{
    partial class FrmModifyAttendanceSheet
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearAttendanceSheet = new System.Windows.Forms.Button();
            this.btnUpdateAttendanceSheet = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlInsertDeleteStudent = new System.Windows.Forms.Panel();
            this.txtStudentRollNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoRows = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlInsertDeleteStudent.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(295, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1169, 734);
            this.dataGridView2.TabIndex = 0;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.Location = new System.Drawing.Point(18, 74);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(230, 35);
            this.txtStudentName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Student Name:";
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(13, 224);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(261, 68);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "Insert New Student";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(13, 323);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(262, 67);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Student";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClearAttendanceSheet
            // 
            this.btnClearAttendanceSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnClearAttendanceSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAttendanceSheet.Location = new System.Drawing.Point(16, 20);
            this.btnClearAttendanceSheet.Name = "btnClearAttendanceSheet";
            this.btnClearAttendanceSheet.Size = new System.Drawing.Size(227, 83);
            this.btnClearAttendanceSheet.TabIndex = 5;
            this.btnClearAttendanceSheet.Text = "Clear Attendance Sheet";
            this.btnClearAttendanceSheet.UseVisualStyleBackColor = false;
            this.btnClearAttendanceSheet.Click += new System.EventHandler(this.btnClearAttendanceSheet_Click);
            // 
            // btnUpdateAttendanceSheet
            // 
            this.btnUpdateAttendanceSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUpdateAttendanceSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAttendanceSheet.Location = new System.Drawing.Point(14, 130);
            this.btnUpdateAttendanceSheet.Name = "btnUpdateAttendanceSheet";
            this.btnUpdateAttendanceSheet.Size = new System.Drawing.Size(227, 87);
            this.btnUpdateAttendanceSheet.TabIndex = 6;
            this.btnUpdateAttendanceSheet.Text = "Update Attendance Sheet";
            this.btnUpdateAttendanceSheet.UseVisualStyleBackColor = false;
            this.btnUpdateAttendanceSheet.Click += new System.EventHandler(this.btnUpdateAttendanceSheet_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnUpdateAttendanceSheet);
            this.panel1.Controls.Add(this.btnClearAttendanceSheet);
            this.panel1.Location = new System.Drawing.Point(7, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 240);
            this.panel1.TabIndex = 7;
            // 
            // pnlInsertDeleteStudent
            // 
            this.pnlInsertDeleteStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInsertDeleteStudent.Controls.Add(this.txtStudentRollNo);
            this.pnlInsertDeleteStudent.Controls.Add(this.label2);
            this.pnlInsertDeleteStudent.Controls.Add(this.btnDelete);
            this.pnlInsertDeleteStudent.Controls.Add(this.btnInsert);
            this.pnlInsertDeleteStudent.Controls.Add(this.label1);
            this.pnlInsertDeleteStudent.Controls.Add(this.txtStudentName);
            this.pnlInsertDeleteStudent.Location = new System.Drawing.Point(7, 12);
            this.pnlInsertDeleteStudent.Name = "pnlInsertDeleteStudent";
            this.pnlInsertDeleteStudent.Size = new System.Drawing.Size(282, 414);
            this.pnlInsertDeleteStudent.TabIndex = 8;
            // 
            // txtStudentRollNo
            // 
            this.txtStudentRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentRollNo.Location = new System.Drawing.Point(18, 158);
            this.txtStudentRollNo.Name = "txtStudentRollNo";
            this.txtStudentRollNo.Size = new System.Drawing.Size(230, 35);
            this.txtStudentRollNo.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "Student Roll No:";
            // 
            // lblNoRows
            // 
            this.lblNoRows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblNoRows.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNoRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRows.ForeColor = System.Drawing.Color.Red;
            this.lblNoRows.Location = new System.Drawing.Point(599, 778);
            this.lblNoRows.Name = "lblNoRows";
            this.lblNoRows.Size = new System.Drawing.Size(77, 50);
            this.lblNoRows.TabIndex = 9;
            this.lblNoRows.Text = "0";
            this.lblNoRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(290, 783);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 45);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Number of Students:";
            // 
            // FrmModifyAttendanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1450, 880);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNoRows);
            this.Controls.Add(this.pnlInsertDeleteStudent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "FrmModifyAttendanceSheet";
            this.Text = "Modify Attendance Sheet";
            this.Load += new System.EventHandler(this.FrmModifyAttendanceSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlInsertDeleteStudent.ResumeLayout(false);
            this.pnlInsertDeleteStudent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClearAttendanceSheet;
        private System.Windows.Forms.Button btnUpdateAttendanceSheet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlInsertDeleteStudent;
        private System.Windows.Forms.TextBox txtStudentRollNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoRows;
        private System.Windows.Forms.Label label3;
    }
}