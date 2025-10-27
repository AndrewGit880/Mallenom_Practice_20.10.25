namespace CeramicQualityControl
{
    partial class TablesControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.cmbTables);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 50);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Таблицы:";
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(80, 12);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(150, 24);
            this.cmbTables.TabIndex = 1;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(240, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(330, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(420, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(510, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 50);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(600, 350);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // TablesControl
            // 
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "TablesControl";
            this.Size = new System.Drawing.Size(600, 400);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}