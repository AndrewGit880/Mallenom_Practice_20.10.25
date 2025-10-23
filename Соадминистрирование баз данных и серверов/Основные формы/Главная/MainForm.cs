using System;
using System.Windows.Forms;

namespace CeramicQualityControl
{
    public partial class MainForm : Form
    {
        private string connectionString;

        public MainForm()
        {
            InitializeComponent();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new SettingsControl());
        }

        private void таблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Сначала настройте подключение к БД");
                настройкиToolStripMenuItem_Click(null, null);
                return;
            }
            ShowControl(new TablesControl(connectionString));
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Сначала настройте подключение к БД");
                настройкиToolStripMenuItem_Click(null, null);
                return;
            }
            ShowControl(new UsersControl(connectionString));
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowControl(UserControl control)
        {
            mainPanel.Controls.Clear();

            if (control is SettingsControl settings)
                settings.ConnectionEstablished += conn => connectionString = conn;

            mainPanel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
    }
}