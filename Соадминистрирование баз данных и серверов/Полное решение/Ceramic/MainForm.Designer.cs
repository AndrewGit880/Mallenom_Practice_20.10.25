namespace CeramicQualityControl
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.таблицыToolStripMenuItem,
            this.пользователиToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 28);
            this.menuStrip1.TabIndex = 0;

            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);

            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            this.таблицыToolStripMenuItem.Click += new System.EventHandler(this.таблицыToolStripMenuItem_Click);

            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            this.пользователиToolStripMenuItem.Click += new System.EventHandler(this.пользователиToolStripMenuItem_Click);

            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);

            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 28);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 622);
            this.mainPanel.TabIndex = 1;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Система контроля качества керамики";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
    }
}