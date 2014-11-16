namespace WinFormCRUD1301681007_3attempt
{
    partial class frmEditUsers
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditUsers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsUsers = new System.Windows.Forms.ToolStrip();
            this.btnNewUser = new System.Windows.Forms.ToolStripButton();
            this.btnEditUser = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteUser = new System.Windows.Forms.ToolStripButton();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsUsers = new System.Windows.Forms.BindingSource(this.components);
            this.dsPhoneBook = new WinFormCRUD1301681007_3attempt.PhoneBook();
            this.tsPhones = new System.Windows.Forms.ToolStrip();
            this.btnNewPhone = new System.Windows.Forms.ToolStripButton();
            this.btnEditPhone = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePhone = new System.Windows.Forms.ToolStripButton();
            this.dgvPhones = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phonesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPhones = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new WinFormCRUD1301681007_3attempt.PhoneBookTableAdapters.UsersTableAdapter();
            this.phonesTableAdapter = new WinFormCRUD1301681007_3attempt.PhoneBookTableAdapters.PhonesTableAdapter();
            this.tsUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPhoneBook)).BeginInit();
            this.tsPhones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPhones)).BeginInit();
            this.SuspendLayout();
            // 
            // tsUsers
            // 
            this.tsUsers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewUser,
            this.btnEditUser,
            this.btnDeleteUser});
            this.tsUsers.Location = new System.Drawing.Point(0, 0);
            this.tsUsers.Name = "tsUsers";
            this.tsUsers.Size = new System.Drawing.Size(603, 25);
            this.tsUsers.TabIndex = 0;
            this.tsUsers.Text = "toolStrip1";
            // 
            // btnNewUser
            // 
            this.btnNewUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNewUser.Image = ((System.Drawing.Image)(resources.GetObject("btnNewUser.Image")));
            this.btnNewUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(35, 22);
            this.btnNewUser.Text = "New";
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditUser.Image = ((System.Drawing.Image)(resources.GetObject("btnEditUser.Image")));
            this.btnEditUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(31, 22);
            this.btnEditUser.Text = "Edit";
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteUser.Image")));
            this.btnDeleteUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(44, 22);
            this.btnDeleteUser.Text = "Delete";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeight = 28;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dgvUsers.DataSource = this.bsUsers;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.Location = new System.Drawing.Point(0, 25);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(603, 211);
            this.dgvUsers.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.firstnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            this.lastnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 200;
            // 
            // bsUsers
            // 
            this.bsUsers.DataMember = "Users";
            this.bsUsers.DataSource = this.dsPhoneBook;
            this.bsUsers.CurrentChanged += new System.EventHandler(this.bsUsers_CurrentChanged);
            // 
            // dsPhoneBook
            // 
            this.dsPhoneBook.DataSetName = "dsPhoneBook";
            this.dsPhoneBook.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsPhones
            // 
            this.tsPhones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsPhones.AutoSize = false;
            this.tsPhones.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPhones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPhones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewPhone,
            this.btnEditPhone,
            this.btnDeletePhone});
            this.tsPhones.Location = new System.Drawing.Point(0, 239);
            this.tsPhones.Name = "tsPhones";
            this.tsPhones.Size = new System.Drawing.Size(603, 25);
            this.tsPhones.TabIndex = 2;
            this.tsPhones.Text = "toolStrip1";
            // 
            // btnNewPhone
            // 
            this.btnNewPhone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNewPhone.Image = ((System.Drawing.Image)(resources.GetObject("btnNewPhone.Image")));
            this.btnNewPhone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewPhone.Name = "btnNewPhone";
            this.btnNewPhone.Size = new System.Drawing.Size(35, 22);
            this.btnNewPhone.Text = "New";
            this.btnNewPhone.Click += new System.EventHandler(this.btnNewPhone_Click);
            // 
            // btnEditPhone
            // 
            this.btnEditPhone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditPhone.Image = ((System.Drawing.Image)(resources.GetObject("btnEditPhone.Image")));
            this.btnEditPhone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditPhone.Name = "btnEditPhone";
            this.btnEditPhone.Size = new System.Drawing.Size(31, 22);
            this.btnEditPhone.Text = "Edit";
            this.btnEditPhone.Click += new System.EventHandler(this.btnEditPhone_Click);
            // 
            // btnDeletePhone
            // 
            this.btnDeletePhone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDeletePhone.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePhone.Image")));
            this.btnDeletePhone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeletePhone.Name = "btnDeletePhone";
            this.btnDeletePhone.Size = new System.Drawing.Size(44, 22);
            this.btnDeletePhone.Text = "Delete";
            this.btnDeletePhone.Click += new System.EventHandler(this.btnDeletePhone_Click);
            // 
            // dgvPhones
            // 
            this.dgvPhones.AllowUserToAddRows = false;
            this.dgvPhones.AllowUserToDeleteRows = false;
            this.dgvPhones.AllowUserToOrderColumns = true;
            this.dgvPhones.AllowUserToResizeRows = false;
            this.dgvPhones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhones.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhones.ColumnHeadersHeight = 28;
            this.dgvPhones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.useridDataGridViewTextBoxColumn,
            this.phonesDataGridViewTextBoxColumn});
            this.dgvPhones.DataSource = this.bsPhones;
            this.dgvPhones.EnableHeadersVisualStyles = false;
            this.dgvPhones.Location = new System.Drawing.Point(0, 267);
            this.dgvPhones.Name = "dgvPhones";
            this.dgvPhones.RowHeadersVisible = false;
            this.dgvPhones.Size = new System.Drawing.Size(603, 194);
            this.dgvPhones.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Visible = false;
            // 
            // useridDataGridViewTextBoxColumn
            // 
            this.useridDataGridViewTextBoxColumn.DataPropertyName = "user_id";
            this.useridDataGridViewTextBoxColumn.HeaderText = "user_id";
            this.useridDataGridViewTextBoxColumn.Name = "useridDataGridViewTextBoxColumn";
            this.useridDataGridViewTextBoxColumn.Visible = false;
            // 
            // phonesDataGridViewTextBoxColumn
            // 
            this.phonesDataGridViewTextBoxColumn.DataPropertyName = "phones";
            this.phonesDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phonesDataGridViewTextBoxColumn.Name = "phonesDataGridViewTextBoxColumn";
            this.phonesDataGridViewTextBoxColumn.Width = 200;
            // 
            // bsPhones
            // 
            this.bsPhones.DataMember = "Phones";
            this.bsPhones.DataSource = this.dsPhoneBook;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // phonesTableAdapter
            // 
            this.phonesTableAdapter.ClearBeforeFill = true;
            // 
            // frmEditUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 461);
            this.Controls.Add(this.dgvPhones);
            this.Controls.Add(this.tsPhones);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.tsUsers);
            this.Name = "frmEditUsers";
            this.Text = "User";
            this.Load += new System.EventHandler(this.frmEditUsers_Load);
            this.tsUsers.ResumeLayout(false);
            this.tsUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPhoneBook)).EndInit();
            this.tsPhones.ResumeLayout(false);
            this.tsPhones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPhones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsUsers;
        private System.Windows.Forms.ToolStripButton btnNewUser;
        private System.Windows.Forms.ToolStripButton btnEditUser;
        private System.Windows.Forms.ToolStripButton btnDeleteUser;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.ToolStrip tsPhones;
        private System.Windows.Forms.ToolStripButton btnNewPhone;
        private System.Windows.Forms.ToolStripButton btnEditPhone;
        private System.Windows.Forms.ToolStripButton btnDeletePhone;
        private System.Windows.Forms.DataGridView dgvPhones;
        private System.Windows.Forms.BindingSource bsUsers;
        private PhoneBook dsPhoneBook;
        private System.Windows.Forms.BindingSource bsPhones;
        private PhoneBookTableAdapters.UsersTableAdapter usersTableAdapter;
        private PhoneBookTableAdapters.PhonesTableAdapter phonesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn useridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phonesDataGridViewTextBoxColumn;
    }
}