namespace AZ_Desktop
{
    partial class FormChip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChip));
            this.textBox_ChipName = new System.Windows.Forms.TextBox();
            this.label_ChipName = new System.Windows.Forms.Label();
            this.button_ChipSearch = new System.Windows.Forms.Button();
            this.button_ChipControl = new System.Windows.Forms.Button();
            this.textBox_ChipNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_ChipOther = new System.Windows.Forms.Label();
            this.richTextBox_ChipOther = new System.Windows.Forms.RichTextBox();
            this.button_ChipUpdate = new System.Windows.Forms.Button();
            this.label_ChipSpecies = new System.Windows.Forms.Label();
            this.textBox_ChipSpecies = new System.Windows.Forms.TextBox();
            this.button_ChipNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_ChipName
            // 
            this.textBox_ChipName.Location = new System.Drawing.Point(52, 393);
            this.textBox_ChipName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ChipName.Name = "textBox_ChipName";
            this.textBox_ChipName.ReadOnly = true;
            this.textBox_ChipName.Size = new System.Drawing.Size(161, 30);
            this.textBox_ChipName.TabIndex = 1;
            this.textBox_ChipName.Visible = false;
            // 
            // label_ChipName
            // 
            this.label_ChipName.AutoSize = true;
            this.label_ChipName.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_ChipName.Location = new System.Drawing.Point(81, 366);
            this.label_ChipName.Name = "label_ChipName";
            this.label_ChipName.Size = new System.Drawing.Size(35, 23);
            this.label_ChipName.TabIndex = 2;
            this.label_ChipName.Text = "Név";
            this.label_ChipName.Visible = false;
            // 
            // button_ChipSearch
            // 
            this.button_ChipSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_ChipSearch.Location = new System.Drawing.Point(181, 324);
            this.button_ChipSearch.Name = "button_ChipSearch";
            this.button_ChipSearch.Size = new System.Drawing.Size(122, 39);
            this.button_ChipSearch.TabIndex = 3;
            this.button_ChipSearch.Text = "Keresés";
            this.button_ChipSearch.UseVisualStyleBackColor = false;
            this.button_ChipSearch.Click += new System.EventHandler(this.button_ChipSearch_Click);
            // 
            // button_ChipControl
            // 
            this.button_ChipControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button_ChipControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_ChipControl.Location = new System.Drawing.Point(252, 163);
            this.button_ChipControl.Name = "button_ChipControl";
            this.button_ChipControl.Size = new System.Drawing.Size(122, 39);
            this.button_ChipControl.TabIndex = 4;
            this.button_ChipControl.Text = "Ellenőrzés";
            this.button_ChipControl.UseVisualStyleBackColor = false;
            this.button_ChipControl.Click += new System.EventHandler(this.button_ChipControl_Click);
            // 
            // textBox_ChipNumber
            // 
            this.textBox_ChipNumber.Location = new System.Drawing.Point(252, 95);
            this.textBox_ChipNumber.Name = "textBox_ChipNumber";
            this.textBox_ChipNumber.Size = new System.Drawing.Size(211, 30);
            this.textBox_ChipNumber.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chip szám";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(62, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "A keresés gomb lenyomásával Ön";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(62, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "a www.petvetdata oldalára lesz átíráníitva!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AZ_Desktop.Properties.Resources.Chip2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(79, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 112);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_ChipOther
            // 
            this.label_ChipOther.AutoSize = true;
            this.label_ChipOther.Location = new System.Drawing.Point(44, 430);
            this.label_ChipOther.Name = "label_ChipOther";
            this.label_ChipOther.Size = new System.Drawing.Size(82, 23);
            this.label_ChipOther.TabIndex = 9;
            this.label_ChipOther.Text = "Megjegyzés";
            this.label_ChipOther.Visible = false;
            // 
            // richTextBox_ChipOther
            // 
            this.richTextBox_ChipOther.Location = new System.Drawing.Point(48, 456);
            this.richTextBox_ChipOther.Name = "richTextBox_ChipOther";
            this.richTextBox_ChipOther.Size = new System.Drawing.Size(402, 128);
            this.richTextBox_ChipOther.TabIndex = 10;
            this.richTextBox_ChipOther.Text = "";
            this.richTextBox_ChipOther.Visible = false;
            // 
            // button_ChipUpdate
            // 
            this.button_ChipUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.button_ChipUpdate.Location = new System.Drawing.Point(181, 600);
            this.button_ChipUpdate.Name = "button_ChipUpdate";
            this.button_ChipUpdate.Size = new System.Drawing.Size(122, 39);
            this.button_ChipUpdate.TabIndex = 11;
            this.button_ChipUpdate.Text = "Módosítás";
            this.button_ChipUpdate.UseVisualStyleBackColor = false;
            this.button_ChipUpdate.Visible = false;
            this.button_ChipUpdate.Click += new System.EventHandler(this.button_ChipUpdate_Click);
            // 
            // label_ChipSpecies
            // 
            this.label_ChipSpecies.AutoSize = true;
            this.label_ChipSpecies.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_ChipSpecies.Location = new System.Drawing.Point(285, 366);
            this.label_ChipSpecies.Name = "label_ChipSpecies";
            this.label_ChipSpecies.Size = new System.Drawing.Size(30, 23);
            this.label_ChipSpecies.TabIndex = 13;
            this.label_ChipSpecies.Text = "Faj";
            this.label_ChipSpecies.Visible = false;
            // 
            // textBox_ChipSpecies
            // 
            this.textBox_ChipSpecies.Location = new System.Drawing.Point(289, 393);
            this.textBox_ChipSpecies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ChipSpecies.Multiline = true;
            this.textBox_ChipSpecies.Name = "textBox_ChipSpecies";
            this.textBox_ChipSpecies.ReadOnly = true;
            this.textBox_ChipSpecies.Size = new System.Drawing.Size(161, 30);
            this.textBox_ChipSpecies.TabIndex = 12;
            this.textBox_ChipSpecies.Visible = false;
            // 
            // button_ChipNew
            // 
            this.button_ChipNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_ChipNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_ChipNew.Location = new System.Drawing.Point(113, 163);
            this.button_ChipNew.Name = "button_ChipNew";
            this.button_ChipNew.Size = new System.Drawing.Size(122, 39);
            this.button_ChipNew.TabIndex = 14;
            this.button_ChipNew.Text = "Új lekérdezés";
            this.button_ChipNew.UseVisualStyleBackColor = false;
            this.button_ChipNew.Click += new System.EventHandler(this.button_ChipNew_Click);
            // 
            // FormChip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AZ_Desktop.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(494, 649);
            this.Controls.Add(this.button_ChipNew);
            this.Controls.Add(this.label_ChipSpecies);
            this.Controls.Add(this.textBox_ChipSpecies);
            this.Controls.Add(this.button_ChipUpdate);
            this.Controls.Add(this.richTextBox_ChipOther);
            this.Controls.Add(this.label_ChipOther);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_ChipNumber);
            this.Controls.Add(this.button_ChipControl);
            this.Controls.Add(this.button_ChipSearch);
            this.Controls.Add(this.label_ChipName);
            this.Controls.Add(this.textBox_ChipName);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormChip";
            this.Text = "A-Z Menhely";
            this.Load += new System.EventHandler(this.FormChip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_ChipName;
        private System.Windows.Forms.Label label_ChipName;
        private System.Windows.Forms.Button button_ChipSearch;
        private System.Windows.Forms.Button button_ChipControl;
        private System.Windows.Forms.TextBox textBox_ChipNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_ChipOther;
        private System.Windows.Forms.Button button_ChipUpdate;
        private System.Windows.Forms.Label label_ChipSpecies;
        private System.Windows.Forms.TextBox textBox_ChipSpecies;
        private System.Windows.Forms.Button button_ChipNew;
        public System.Windows.Forms.RichTextBox richTextBox_ChipOther;
    }
}