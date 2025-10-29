using System;
using Npgsql;
using System.Windows.Forms;

namespace CeramicQualityControl
{
    public partial class SettingsControl : UserControl
    {
        public event Action<string> ConnectionEstablished;

        public SettingsControl() => InitializeComponent();

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                var builder = new NpgsqlConnectionStringBuilder
                {
                    Host = txtServer.Text,
                    Port = int.Parse(txtPort.Text),
                    Database = txtDatabase.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };

                using (var conn = new NpgsqlConnection(builder.ToString()))
                {
                    conn.Open();
                    ConnectionEstablished?.Invoke(builder.ToString());
                    MessageBox.Show("Подключение успешно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}