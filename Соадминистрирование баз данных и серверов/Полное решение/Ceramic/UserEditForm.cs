using System;
using System.Windows.Forms;

namespace CeramicQualityControl
{
    public partial class UserEditForm : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public bool IsEditMode { get; private set; }

        public UserEditForm(bool isEditMode = false, string currentUsername = "")
        {
            IsEditMode = isEditMode;
            InitializeComponent();

            if (isEditMode)
            {
                Text = "Редактирование пользователя";
                txtUsername.Text = currentUsername;
                txtUsername.Enabled = false; 
            }
            else
            {
                Text = "Добавление пользователя";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Введите имя пользователя", "Ошибка");
                return;
            }

            if (!IsEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка");
                return;
            }

            Username = txtUsername.Text.Trim();
            Password = txtPassword.Text;
            Role = cmbRole.SelectedItem?.ToString() ?? "user";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            // Заполняем комбобокс ролями
            cmbRole.Items.AddRange(new string[] { "admin", "user", "operator" });
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 1;
        }

        public void SetCurrentRole(string role)
        {
            for (int i = 0; i < cmbRole.Items.Count; i++)
            {
                if (cmbRole.Items[i].ToString() == role)
                {
                    cmbRole.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}