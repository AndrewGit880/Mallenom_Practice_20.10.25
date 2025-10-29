using System;
using System.Data;
using Npgsql;
using System.Windows.Forms;

namespace CeramicQualityControl
{
    public partial class UsersControl : UserControl
    {
        private string connectionString;

        public UsersControl(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (var form = new UserEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    AddUserToDatabase(form.Username, form.Password, form.Role);
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите пользователя для редактирования", "Информация");
                return;
            }

            string username = listViewUsers.SelectedItems[0].Text;
            string currentRole = listViewUsers.SelectedItems[0].SubItems[1].Text;

            using (var form = new UserEditForm(true, username))
            {
                form.SetCurrentRole(currentRole);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateUserInDatabase(form.Username, form.Password, form.Role);
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите пользователя для удаления", "Информация");
                return;
            }

            string username = listViewUsers.SelectedItems[0].Text;
            if (MessageBox.Show($"Удалить пользователя {username}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteUserFromDatabase(username);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                listViewUsers.Items.Clear();

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT usename, 
                               CASE 
                                   WHEN usesuper THEN 'admin'
                                   ELSE 'user'
                               END as role
                        FROM pg_catalog.pg_user 
                        ORDER BY usename";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string username = reader.GetString(0);
                            string role = reader.GetString(1);

                            var item = new ListViewItem(new string[] { username, role });
                            listViewUsers.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка");
            }
        }

        private void AddUserToDatabase(string username, string password, string role)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string createUserQuery = $"CREATE USER {username} WITH PASSWORD '{password}'";
                    using (var cmd = new NpgsqlCommand(createUserQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    if (role == "admin")
                    {
                        string grantQuery = $"ALTER USER {username} WITH SUPERUSER";
                        using (var cmd = new NpgsqlCommand(grantQuery, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Пользователь {username} успешно создан", "Успех");
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания пользователя: {ex.Message}", "Ошибка");
            }
        }

        private void UpdateUserInDatabase(string username, string password, string role)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    if (!string.IsNullOrEmpty(password))
                    {
                        string updatePasswordQuery = $"ALTER USER {username} WITH PASSWORD '{password}'";
                        using (var cmd = new NpgsqlCommand(updatePasswordQuery, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    string roleQuery = role == "admin" ?
                        $"ALTER USER {username} WITH SUPERUSER" :
                        $"ALTER USER {username} WITH NOSUPERUSER";

                    using (var cmd = new NpgsqlCommand(roleQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Пользователь {username} успешно обновлен", "Успех");
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления пользователя: {ex.Message}", "Ошибка");
            }
        }

        private void DeleteUserFromDatabase(string username)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string query = $"DROP USER {username}";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Пользователь {username} успешно удален", "Успех");
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления пользователя: {ex.Message}", "Ошибка");
            }
        }

        private void UsersControl_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}