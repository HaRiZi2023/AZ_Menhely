namespace AZ_Desktop
{
    partial class FormFound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFound));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_FoundWhere = new System.Windows.Forms.TextBox();
            this.listBox_Found = new System.Windows.Forms.ListBox();
            this.button_FoundUpdate = new System.Windows.Forms.Button();
            this.button_FoundDelete = new System.Windows.Forms.Button();
            this.pictureBox_FoundImage = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_FoundChoice = new System.Windows.Forms.TextBox();
            this.richTextBox_FoundOther = new System.Windows.Forms.RichTextBox();
            this.textBox_FoundSpecies = new System.Windows.Forms.TextBox();
            this.textBox_FoundGender = new System.Windows.Forms.TextBox();
            this.textBox_FoundInjury = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FoundImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(222, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Találtam / Keresem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Faj";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hol találták";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sérült-e";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 346);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Megjegyzés";
            // 
            // textBox_FoundWhere
            // 
            this.textBox_FoundWhere.Location = new System.Drawing.Point(384, 238);
            this.textBox_FoundWhere.Name = "textBox_FoundWhere";
            this.textBox_FoundWhere.ReadOnly = true;
            this.textBox_FoundWhere.Size = new System.Drawing.Size(233, 30);
            this.textBox_FoundWhere.TabIndex = 11;
            // 
            // listBox_Found
            // 
            this.listBox_Found.FormattingEnabled = true;
            this.listBox_Found.ItemHeight = 23;
            this.listBox_Found.Location = new System.Drawing.Point(53, 234);
            this.listBox_Found.Name = "listBox_Found";
            this.listBox_Found.Size = new System.Drawing.Size(200, 418);
            this.listBox_Found.TabIndex = 13;
            // 
            // button_FoundUpdate
            // 
            this.button_FoundUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(165)))), ((int)(((byte)(210)))));
            this.button_FoundUpdate.Location = new System.Drawing.Point(283, 613);
            this.button_FoundUpdate.Name = "button_FoundUpdate";
            this.button_FoundUpdate.Size = new System.Drawing.Size(126, 37);
            this.button_FoundUpdate.TabIndex = 15;
            this.button_FoundUpdate.Text = "Módosítás";
            this.button_FoundUpdate.UseVisualStyleBackColor = false;
            this.button_FoundUpdate.Click += new System.EventHandler(this.button_FoundUpdate_Click);
            // 
            // button_FoundDelete
            // 
            this.button_FoundDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.button_FoundDelete.Location = new System.Drawing.Point(419, 613);
            this.button_FoundDelete.Name = "button_FoundDelete";
            this.button_FoundDelete.Size = new System.Drawing.Size(126, 37);
            this.button_FoundDelete.TabIndex = 16;
            this.button_FoundDelete.Text = "Törlés";
            this.button_FoundDelete.UseVisualStyleBackColor = false;
            this.button_FoundDelete.Click += new System.EventHandler(this.button_FoundDelete_Click);
            // 
            // pictureBox_FoundImage
            // 
            this.pictureBox_FoundImage.BackColor = System.Drawing.Color.Silver;
            this.pictureBox_FoundImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_FoundImage.Location = new System.Drawing.Point(53, 81);
            this.pictureBox_FoundImage.Name = "pictureBox_FoundImage";
            this.pictureBox_FoundImage.Size = new System.Drawing.Size(200, 137);
            this.pictureBox_FoundImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_FoundImage.TabIndex = 14;
            this.pictureBox_FoundImage.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Választás";
            // 
            // textBox_FoundChoice
            // 
            this.textBox_FoundChoice.Location = new System.Drawing.Point(384, 93);
            this.textBox_FoundChoice.Name = "textBox_FoundChoice";
            this.textBox_FoundChoice.ReadOnly = true;
            this.textBox_FoundChoice.Size = new System.Drawing.Size(145, 30);
            this.textBox_FoundChoice.TabIndex = 19;
            // 
            // richTextBox_FoundOther
            // 
            this.richTextBox_FoundOther.Location = new System.Drawing.Point(384, 346);
            this.richTextBox_FoundOther.Name = "richTextBox_FoundOther";
            this.richTextBox_FoundOther.Size = new System.Drawing.Size(233, 206);
            this.richTextBox_FoundOther.TabIndex = 20;
            this.richTextBox_FoundOther.Text = "";
            // 
            // textBox_FoundSpecies
            // 
            this.textBox_FoundSpecies.Location = new System.Drawing.Point(384, 141);
            this.textBox_FoundSpecies.Name = "textBox_FoundSpecies";
            this.textBox_FoundSpecies.ReadOnly = true;
            this.textBox_FoundSpecies.Size = new System.Drawing.Size(145, 30);
            this.textBox_FoundSpecies.TabIndex = 21;
            // 
            // textBox_FoundGender
            // 
            this.textBox_FoundGender.Location = new System.Drawing.Point(384, 187);
            this.textBox_FoundGender.Name = "textBox_FoundGender";
            this.textBox_FoundGender.Size = new System.Drawing.Size(145, 30);
            this.textBox_FoundGender.TabIndex = 22;
            // 
            // textBox_FoundInjury
            // 
            this.textBox_FoundInjury.Location = new System.Drawing.Point(384, 288);
            this.textBox_FoundInjury.Name = "textBox_FoundInjury";
            this.textBox_FoundInjury.Size = new System.Drawing.Size(145, 30);
            this.textBox_FoundInjury.TabIndex = 23;
            // 
            // FormFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AZ_Desktop.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(650, 695);
            this.Controls.Add(this.textBox_FoundInjury);
            this.Controls.Add(this.textBox_FoundGender);
            this.Controls.Add(this.textBox_FoundSpecies);
            this.Controls.Add(this.richTextBox_FoundOther);
            this.Controls.Add(this.textBox_FoundChoice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_FoundDelete);
            this.Controls.Add(this.button_FoundUpdate);
            this.Controls.Add(this.pictureBox_FoundImage);
            this.Controls.Add(this.listBox_Found);
            this.Controls.Add(this.textBox_FoundWhere);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormFound";
            this.Text = "A-Z Menhely";
            this.Load += new System.EventHandler(this.FormFound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FoundImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_FoundWhere;
        private System.Windows.Forms.PictureBox pictureBox_FoundImage;
        private System.Windows.Forms.Button button_FoundUpdate;
        private System.Windows.Forms.Button button_FoundDelete;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_FoundChoice;
        private System.Windows.Forms.RichTextBox richTextBox_FoundOther;
        private System.Windows.Forms.TextBox textBox_FoundSpecies;
        public System.Windows.Forms.ListBox listBox_Found;
        private System.Windows.Forms.TextBox textBox_FoundGender;
        private System.Windows.Forms.TextBox textBox_FoundInjury;
    }
}