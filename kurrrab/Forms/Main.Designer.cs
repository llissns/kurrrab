namespace kurrrab
{
    partial class Main
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
            this.PanelContent = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.buttonContacts = new System.Windows.Forms.Button();
            this.buttonServices = new System.Windows.Forms.Button();
            this.buttonRooms = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelContent
            // 
            this.PanelContent.BackColor = System.Drawing.Color.Linen;
            this.PanelContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelContent.Location = new System.Drawing.Point(191, 0);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(687, 556);
            this.PanelContent.TabIndex = 0;
            this.PanelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelContent_Paint);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Linen;
            this.panelMenu.Controls.Add(this.buttonAbout);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Controls.Add(this.buttonAccount);
            this.panelMenu.Controls.Add(this.buttonContacts);
            this.panelMenu.Controls.Add(this.buttonServices);
            this.panelMenu.Controls.Add(this.buttonRooms);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 556);
            this.panelMenu.TabIndex = 1;
            // 
            // buttonAbout
            // 
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonAbout.ImageKey = "(none)";
            this.buttonAbout.Location = new System.Drawing.Point(0, 168);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(200, 48);
            this.buttonAbout.TabIndex = 0;
            this.buttonAbout.Text = "О гостинице";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Лесное озеро";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kurrrab.Properties.Resources.icons8_остров_85;
            this.pictureBox1.Location = new System.Drawing.Point(57, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // buttonAccount
            // 
            this.buttonAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccount.Location = new System.Drawing.Point(0, 487);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(200, 48);
            this.buttonAccount.TabIndex = 4;
            this.buttonAccount.Text = "Личный кабинет";
            this.buttonAccount.UseVisualStyleBackColor = true;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // buttonContacts
            // 
            this.buttonContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContacts.Location = new System.Drawing.Point(0, 330);
            this.buttonContacts.Name = "buttonContacts";
            this.buttonContacts.Size = new System.Drawing.Size(200, 48);
            this.buttonContacts.TabIndex = 3;
            this.buttonContacts.Text = "Контакты";
            this.buttonContacts.UseVisualStyleBackColor = true;
            this.buttonContacts.Click += new System.EventHandler(this.buttonContacts_Click);
            // 
            // buttonServices
            // 
            this.buttonServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonServices.Location = new System.Drawing.Point(0, 276);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(200, 48);
            this.buttonServices.TabIndex = 2;
            this.buttonServices.Text = "Услуги";
            this.buttonServices.UseVisualStyleBackColor = true;
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            // 
            // buttonRooms
            // 
            this.buttonRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRooms.Location = new System.Drawing.Point(0, 222);
            this.buttonRooms.Name = "buttonRooms";
            this.buttonRooms.Size = new System.Drawing.Size(200, 48);
            this.buttonRooms.TabIndex = 1;
            this.buttonRooms.Text = "Номера";
            this.buttonRooms.UseVisualStyleBackColor = true;
            this.buttonRooms.Click += new System.EventHandler(this.buttonRooms_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 556);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.PanelContent);
            this.Name = "Main";
            this.Text = "Главный экран";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelContent;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonAccount;
        private System.Windows.Forms.Button buttonContacts;
        private System.Windows.Forms.Button buttonServices;
        private System.Windows.Forms.Button buttonRooms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAbout;
    }
}

