using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CeramicQualityControl
{
    public partial class MainForm : Form
    {
        private string connectionString;

        public MainForm()
        {
            InitializeComponent();
            UpdateWindowTitle("Главная");
        }

        private void UpdateWindowTitle(string menuItem)
        {
            this.Text = $"Система контроля качества керамики - {menuItem}";
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateWindowTitle("Настройки подключения");
            ShowSettings();
        }

        private void таблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateWindowTitle("Управление таблицами");
            ShowTables();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateWindowTitle("Управление пользователями");
            ShowUsers();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowSettings()
        {
            ClearPanel();
            var settingsControl = new SettingsControl();
            settingsControl.ConnectionEstablished += OnConnectionEstablished;
            mainPanel.Controls.Add(settingsControl);
            settingsControl.Dock = DockStyle.Fill;
        }

        private void ShowTables()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Сначала настройте подключение к базе данных");
                настройкиToolStripMenuItem_Click(null, null);
                return;
            }

            ClearPanel();
            var tablesControl = new TablesControl(connectionString);
            mainPanel.Controls.Add(tablesControl);
            tablesControl.Dock = DockStyle.Fill;
        }

        private void ShowUsers()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Сначала настройте подключение к базе данных");
                настройкиToolStripMenuItem_Click(null, null);
                return;
            }

            ClearPanel();
            var usersControl = new UsersControl(connectionString);
            mainPanel.Controls.Add(usersControl);
            usersControl.Dock = DockStyle.Fill;
        }

        private void ClearPanel()
        {
            mainPanel.Controls.Clear();
        }

        private void OnConnectionEstablished(string connString)
        {
            connectionString = connString;
        }
    }
}