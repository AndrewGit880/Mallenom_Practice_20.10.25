using System;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CeramicQualityControl
{
    public partial class TablesControl : UserControl
    {
        private string connectionString;
        private DataTable currentTable;
        private string currentTableName;

        public TablesControl(string connString)
        {
            connectionString = connString;
            InitializeComponent();
            LoadTables();
        }

        private void LoadTables()
        {
            try
            {
                cmbTables.Items.Clear();
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var tables = new List<string>();
                    using (var cmd = new NpgsqlCommand(
                        "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public'", conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            tables.Add(reader.GetString(0));

                    cmbTables.Items.AddRange(tables.ToArray());
                    if (tables.Count > 0) cmbTables.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowError("Ошибка загрузки таблиц: " + ex.Message);
            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTableName = cmbTables.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(currentTableName))
                LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var adapter = new NpgsqlDataAdapter($"SELECT * FROM {currentTableName} LIMIT 100", conn);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                    dataGridView.DataSource = currentTable;
                }
            }
            catch (Exception ex)
            {
                ShowError("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentTable == null) return;

            using (var form = new AddForm(currentTable))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SaveData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow?.DataBoundItem is DataRowView rowView)
            {
                using (var form = new EditForm(rowView.Row, currentTable))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        SaveData();
                    }
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow?.DataBoundItem is DataRowView rowView &&
                MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                rowView.Row.Delete();
                SaveData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void SaveData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var adapter = new NpgsqlDataAdapter($"SELECT * FROM {currentTableName}", conn);
                    new NpgsqlCommandBuilder(adapter);
                    adapter.Update(currentTable);
                }
            }
            catch (Exception ex)
            {
                ShowError("Ошибка сохранения: " + ex.Message);
                currentTable.RejectChanges();
                LoadData();
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit_Click(sender, e);
        }

        private void ShowError(string message) =>
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}