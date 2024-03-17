namespace AZ_Desktop
{
    partial class FormChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChoice));
            this.Vendegek = new System.Windows.Forms.ListBox();
            this.button_ChoiceInsert = new System.Windows.Forms.Button();
            this.button__ChoiceUpdate = new System.Windows.Forms.Button();
            this.button_ChoiceDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_ChoiceCat = new System.Windows.Forms.CheckBox();
            this.checkBox_ChoiceDog = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Vendegek
            // 
            this.Vendegek.FormattingEnabled = true;
            this.Vendegek.ItemHeight = 23;
            this.Vendegek.Location = new System.Drawing.Point(57, 182);
            this.Vendegek.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Vendegek.Name = "Vendegek";
            this.Vendegek.Size = new System.Drawing.Size(250, 556);
            this.Vendegek.TabIndex = 0;
            // 
            // button_ChoiceInsert
            // 
            this.button_ChoiceInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(225)))));
            this.button_ChoiceInsert.Location = new System.Drawing.Point(392, 300);
            this.button_ChoiceInsert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ChoiceInsert.Name = "button_ChoiceInsert";
            this.button_ChoiceInsert.Size = new System.Drawing.Size(94, 41);
            this.button_ChoiceInsert.TabIndex = 1;
            this.button_ChoiceInsert.Text = "Felvitel";
            this.button_ChoiceInsert.UseVisualStyleBackColor = false;
            // 
            // button__ChoiceUpdate
            // 
            this.button__ChoiceUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(165)))), ((int)(((byte)(240)))));
            this.button__ChoiceUpdate.Location = new System.Drawing.Point(392, 367);
            this.button__ChoiceUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button__ChoiceUpdate.Name = "button__ChoiceUpdate";
            this.button__ChoiceUpdate.Size = new System.Drawing.Size(94, 41);
            this.button__ChoiceUpdate.TabIndex = 2;
            this.button__ChoiceUpdate.Text = "Módosítás";
            this.button__ChoiceUpdate.UseVisualStyleBackColor = false;
            // 
            // button_ChoiceDelete
            // 
            this.button_ChoiceDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.button_ChoiceDelete.Location = new System.Drawing.Point(392, 426);
            this.button_ChoiceDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ChoiceDelete.Name = "button_ChoiceDelete";
            this.button_ChoiceDelete.Size = new System.Drawing.Size(94, 41);
            this.button_ChoiceDelete.TabIndex = 3;
            this.button_ChoiceDelete.Text = "Törlés";
            this.button_ChoiceDelete.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::AZ_Desktop.Properties.Resources.Pasztel_szürke;
            this.groupBox1.Controls.Add(this.checkBox_ChoiceCat);
            this.groupBox1.Controls.Add(this.checkBox_ChoiceDog);
            this.groupBox1.Location = new System.Drawing.Point(44, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(250, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Válasszon állatfajt";
            // 
            // checkBox_ChoiceCat
            // 
            this.checkBox_ChoiceCat.AutoSize = true;
            this.checkBox_ChoiceCat.Location = new System.Drawing.Point(124, 66);
            this.checkBox_ChoiceCat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_ChoiceCat.Name = "checkBox_ChoiceCat";
            this.checkBox_ChoiceCat.Size = new System.Drawing.Size(82, 27);
            this.checkBox_ChoiceCat.TabIndex = 6;
            this.checkBox_ChoiceCat.Text = "macska";
            this.checkBox_ChoiceCat.UseVisualStyleBackColor = true;
            // 
            // checkBox_ChoiceDog
            // 
            this.checkBox_ChoiceDog.AutoSize = true;
            this.checkBox_ChoiceDog.Location = new System.Drawing.Point(124, 31);
            this.checkBox_ChoiceDog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_ChoiceDog.Name = "checkBox_ChoiceDog";
            this.checkBox_ChoiceDog.Size = new System.Drawing.Size(70, 27);
            this.checkBox_ChoiceDog.TabIndex = 5;
            this.checkBox_ChoiceDog.Text = "kutya";
            this.checkBox_ChoiceDog.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button4.Location = new System.Drawing.Point(392, 492);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 41);
            this.button4.TabIndex = 6;
            this.button4.Text = "Vissza";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AZ_Desktop.Properties.Resources.Mancs11;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(332, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 126);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FormChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AZ_Desktop.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(607, 751);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_ChoiceDelete);
            this.Controls.Add(this.button__ChoiceUpdate);
            this.Controls.Add(this.button_ChoiceInsert);
            this.Controls.Add(this.Vendegek);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormChoice";
            this.Text = "A-Z Menhely";
            this.Load += new System.EventHandler(this.FormChoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Vendegek;
        private System.Windows.Forms.Button button_ChoiceInsert;
        private System.Windows.Forms.Button button__ChoiceUpdate;
        private System.Windows.Forms.Button button_ChoiceDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_ChoiceCat;
        private System.Windows.Forms.CheckBox checkBox_ChoiceDog;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}