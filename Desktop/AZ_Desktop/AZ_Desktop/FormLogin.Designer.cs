namespace AZ_Desktop
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_LoginName = new System.Windows.Forms.TextBox();
            this.textBox_LoginPass = new System.Windows.Forms.TextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_LoginService = new System.Windows.Forms.Button();
            this.button_LoginInsert = new System.Windows.Forms.Button();
            this.button_LoginDelete = new System.Windows.Forms.Button();
            this.button_LoginUpdate = new System.Windows.Forms.Button();
            this.comboBox_LoginPermission = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(307, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Üdvözöljük!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(354, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Belépés";
            // 
            // textBox_LoginName
            // 
            this.textBox_LoginName.Location = new System.Drawing.Point(271, 149);
            this.textBox_LoginName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox_LoginName.Name = "textBox_LoginName";
            this.textBox_LoginName.Size = new System.Drawing.Size(244, 30);
            this.textBox_LoginName.TabIndex = 2;
            // 
            // textBox_LoginPass
            // 
            this.textBox_LoginPass.Location = new System.Drawing.Point(271, 208);
            this.textBox_LoginPass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox_LoginPass.Name = "textBox_LoginPass";
            this.textBox_LoginPass.Size = new System.Drawing.Size(244, 30);
            this.textBox_LoginPass.TabIndex = 3;
            // 
            // button_Login
            // 
            this.button_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button_Login.Location = new System.Drawing.Point(301, 314);
            this.button_Login.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(180, 36);
            this.button_Login.TabIndex = 4;
            this.button_Login.Text = "Belépés";
            this.button_Login.UseVisualStyleBackColor = false;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(230, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Név";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(216, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Jelszó";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AZ_Desktop.Properties.Resources.kutya_macska;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 131);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // button_LoginService
            // 
            this.button_LoginService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_LoginService.Location = new System.Drawing.Point(301, 360);
            this.button_LoginService.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_LoginService.Name = "button_LoginService";
            this.button_LoginService.Size = new System.Drawing.Size(180, 36);
            this.button_LoginService.TabIndex = 9;
            this.button_LoginService.Text = "Szerviz";
            this.button_LoginService.UseVisualStyleBackColor = false;
            this.button_LoginService.Click += new System.EventHandler(this.button_LoginService_Click);
            // 
            // button_LoginInsert
            // 
            this.button_LoginInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(225)))));
            this.button_LoginInsert.Location = new System.Drawing.Point(271, 413);
            this.button_LoginInsert.Name = "button_LoginInsert";
            this.button_LoginInsert.Size = new System.Drawing.Size(75, 36);
            this.button_LoginInsert.TabIndex = 10;
            this.button_LoginInsert.Text = "Felvitel";
            this.button_LoginInsert.UseVisualStyleBackColor = false;
            this.button_LoginInsert.Visible = false;
            this.button_LoginInsert.Click += new System.EventHandler(this.button_LoginInsert_Click);
            // 
            // button_LoginDelete
            // 
            this.button_LoginDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.button_LoginDelete.Location = new System.Drawing.Point(433, 413);
            this.button_LoginDelete.Name = "button_LoginDelete";
            this.button_LoginDelete.Size = new System.Drawing.Size(75, 36);
            this.button_LoginDelete.TabIndex = 11;
            this.button_LoginDelete.Text = "Törlés";
            this.button_LoginDelete.UseVisualStyleBackColor = false;
            this.button_LoginDelete.Visible = false;
            this.button_LoginDelete.Click += new System.EventHandler(this.button_LoginDelete_Click);
            // 
            // button_LoginUpdate
            // 
            this.button_LoginUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(165)))), ((int)(((byte)(240)))));
            this.button_LoginUpdate.Location = new System.Drawing.Point(352, 413);
            this.button_LoginUpdate.Name = "button_LoginUpdate";
            this.button_LoginUpdate.Size = new System.Drawing.Size(75, 36);
            this.button_LoginUpdate.TabIndex = 12;
            this.button_LoginUpdate.Text = "Módosít";
            this.button_LoginUpdate.UseVisualStyleBackColor = false;
            this.button_LoginUpdate.Visible = false;
            this.button_LoginUpdate.Click += new System.EventHandler(this.button_LoginUpdate_Click);
            // 
            // comboBox_LoginPermission
            // 
            this.comboBox_LoginPermission.FormattingEnabled = true;
            this.comboBox_LoginPermission.Items.AddRange(new object[] {
            "teljes",
            "felhasználó"});
            this.comboBox_LoginPermission.Location = new System.Drawing.Point(271, 258);
            this.comboBox_LoginPermission.Name = "comboBox_LoginPermission";
            this.comboBox_LoginPermission.Size = new System.Drawing.Size(244, 31);
            this.comboBox_LoginPermission.TabIndex = 13;
            this.comboBox_LoginPermission.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AZ_Desktop.Properties.Resources.Login___out1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(779, 688);
            this.Controls.Add(this.comboBox_LoginPermission);
            this.Controls.Add(this.button_LoginUpdate);
            this.Controls.Add(this.button_LoginDelete);
            this.Controls.Add(this.button_LoginInsert);
            this.Controls.Add(this.button_LoginService);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.textBox_LoginPass);
            this.Controls.Add(this.textBox_LoginName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormLogin";
            this.Text = "A-Z Menhely";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_LoginName;
        private System.Windows.Forms.TextBox textBox_LoginPass;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_LoginService;
        private System.Windows.Forms.Button button_LoginInsert;
        private System.Windows.Forms.Button button_LoginDelete;
        private System.Windows.Forms.Button button_LoginUpdate;
        private System.Windows.Forms.ComboBox comboBox_LoginPermission;
    }
}

