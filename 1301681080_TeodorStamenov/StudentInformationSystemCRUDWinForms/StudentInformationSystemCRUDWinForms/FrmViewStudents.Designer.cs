namespace StudentInformationSystemCRUDWinForms
{
    partial class FrmViewStudents
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
            this.dgvStudentData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(87, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "View All Students In System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgvStudentData
            // 
            this.dgvStudentData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentData.Location = new System.Drawing.Point(12, 83);
            this.dgvStudentData.Name = "dgvStudentData";
            this.dgvStudentData.Size = new System.Drawing.Size(465, 412);
            this.dgvStudentData.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(189, 517);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmViewStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(489, 567);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvStudentData);
            this.Controls.Add(this.label1);
            this.Name = "FrmViewStudents";
            this.Text = "View All Students";
            this.Load += new System.EventHandler(this.FrmViewStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStudentData;
        private System.Windows.Forms.Button btnClose;
    }
}