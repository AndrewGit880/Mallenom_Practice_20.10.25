using System;
using System.Data;
using System.Windows.Forms;

namespace CeramicQualityControl
{
    public partial class EditForm : Form
    {
        private DataRow row;
        private DataTable table;

        public EditForm(DataRow dataRow, DataTable dataTable)
        {
            row = dataRow;
            table = dataTable;
            InitializeComponent();
            CreateFormFields();
        }

        private void CreateFormFields()
        {
            int y = 10;
            foreach (DataColumn column in table.Columns)
            {
                if (column.AutoIncrement) continue;

                var label = new Label
                {
                    Text = column.ColumnName,
                    Location = new System.Drawing.Point(10, y),
                    Width = 120,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top
                };

                var textBox = new TextBox
                {
                    Location = new System.Drawing.Point(130, y),
                    Width = 200,
                    Text = row.IsNull(column) ? "" : row[column].ToString(),
                    Tag = column,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right
                };

                panelMain.Controls.Add(label);
                panelMain.Controls.Add(textBox);
                y += 30;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelMain.Controls)
            {
                if (control is TextBox textBox && textBox.Tag is DataColumn column)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(textBox.Text) && column.AllowDBNull)
                            row[column] = DBNull.Value;
                        else
                            row[column] = Convert.ChangeType(textBox.Text, column.DataType);
                    }
                    catch
                    {
                        MessageBox.Show($"Ошибка в поле {column.ColumnName}", "Ошибка");
                        return;
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}