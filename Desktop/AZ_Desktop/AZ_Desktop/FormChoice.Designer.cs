﻿namespace AZ_Desktop
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
            this.listBox_Choice = new System.Windows.Forms.ListBox();
            this.button_ChoiceInsert = new System.Windows.Forms.Button();
            this.button__ChoiceUpdate = new System.Windows.Forms.Button();
            this.button_ChoiceDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_ChoiceCat = new System.Windows.Forms.CheckBox();
            this.checkBox_ChoiceDog = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_ChoiceChoice = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_Choice
            // 
            this.listBox_Choice.FormattingEnabled = true;
            this.listBox_Choice.ItemHeight = 23;
            this.listBox_Choice.Location = new System.Drawing.Point(44, 208);
            this.listBox_Choice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox_Choice.Name = "listBox_Choice";
            this.listBox_Choice.Size = new System.Drawing.Size(250, 556);
            this.listBox_Choice.TabIndex = 0;
            this.listBox_Choice.SelectedIndexChanged += new System.EventHandler(this.listBox_Choice_SelectedIndexChanged_1);
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
            this.button_ChoiceInsert.Click += new System.EventHandler(this.button_ChoiceInsert_Click);
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
            this.button__ChoiceUpdate.Click += new System.EventHandler(this.button__ChoiceUpdate_Click);
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
            this.button_ChoiceDelete.Click += new System.EventHandler(this.button_ChoiceDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::AZ_Desktop.Properties.Resources.Pasztel_szürke;
            this.groupBox1.Controls.Add(this.button_ChoiceChoice);
            this.groupBox1.Controls.Add(this.checkBox_ChoiceCat);
            this.groupBox1.Controls.Add(this.checkBox_ChoiceDog);
            this.groupBox1.Location = new System.Drawing.Point(44, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(250, 175);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Válasszon állatfajt";
            // 
            // checkBox_ChoiceCat
            // 
            this.checkBox_ChoiceCat.AutoSize = true;
            this.checkBox_ChoiceCat.Location = new System.Drawing.Point(77, 67);
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
            this.checkBox_ChoiceDog.Location = new System.Drawing.Point(77, 32);
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
            this.button4.Location = new System.Drawing.Point(392, 488);
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
            // button_ChoiceChoice
            // 
            this.button_ChoiceChoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button_ChoiceChoice.Location = new System.Drawing.Point(139, 115);
            this.button_ChoiceChoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ChoiceChoice.Name = "button_ChoiceChoice";
            this.button_ChoiceChoice.Size = new System.Drawing.Size(94, 41);
            this.button_ChoiceChoice.TabIndex = 7;
            this.button_ChoiceChoice.Text = "Választás";
            this.button_ChoiceChoice.UseVisualStyleBackColor = false;
            this.button_ChoiceChoice.Click += new System.EventHandler(this.button_ChoiceChoice_Click);
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
            this.Controls.Add(this.listBox_Choice);
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

        private System.Windows.Forms.ListBox listBox_Choice;
        private System.Windows.Forms.Button button_ChoiceInsert;
        private System.Windows.Forms.Button button__ChoiceUpdate;
        private System.Windows.Forms.Button button_ChoiceDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_ChoiceCat;
        private System.Windows.Forms.CheckBox checkBox_ChoiceDog;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_ChoiceChoice;
    }
}