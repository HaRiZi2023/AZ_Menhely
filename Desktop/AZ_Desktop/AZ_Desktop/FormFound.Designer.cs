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
            this.button_FoundUpdate = new System.Windows.Forms.Button();
            this.button_FoundDelete = new System.Windows.Forms.Button();
            this.pictureBox_FoundImage = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_FoundChoice = new System.Windows.Forms.TextBox();
            this.richTextBox_FoundOther = new System.Windows.Forms.RichTextBox();
            this.textBox_FoundSpecies = new System.Windows.Forms.TextBox();
            this.textBox_FoundGender = new System.Windows.Forms.TextBox();
            this.textBox_FoundInjury = new System.Windows.Forms.TextBox();
            this.listView_Found = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_FoundId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.label2.Location = new System.Drawing.Point(321, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Faj";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hol találták";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sérült-e";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Megjegyzés";
            // 
            // textBox_FoundWhere
            // 
            this.textBox_FoundWhere.Location = new System.Drawing.Point(377, 279);
            this.textBox_FoundWhere.Name = "textBox_FoundWhere";
            this.textBox_FoundWhere.ReadOnly = true;
            this.textBox_FoundWhere.Size = new System.Drawing.Size(233, 30);
            this.textBox_FoundWhere.TabIndex = 11;
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
            this.label8.Location = new System.Drawing.Point(279, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Választás";
            // 
            // textBox_FoundChoice
            // 
            this.textBox_FoundChoice.Location = new System.Drawing.Point(377, 134);
            this.textBox_FoundChoice.Name = "textBox_FoundChoice";
            this.textBox_FoundChoice.ReadOnly = true;
            this.textBox_FoundChoice.Size = new System.Drawing.Size(145, 30);
            this.textBox_FoundChoice.TabIndex = 19;
            // 
            // richTextBox_FoundOther
            // 
            this.richTextBox_FoundOther.Location = new System.Drawing.Point(377, 387);
            this.richTextBox_FoundOther.Name = "richTextBox_FoundOther";
            this.richTextBox_FoundOther.Size = new System.Drawing.Size(233, 206);
            this.richTextBox_FoundOther.TabIndex = 20;
            this.richTextBox_FoundOther.Text = "";
            // 
            // textBox_FoundSpecies
            // 
            this.textBox_FoundSpecies.Location = new System.Drawing.Point(377, 182);
            this.textBox_FoundSpecies.Name = "textBox_FoundSpecies";
            this.textBox_FoundSpecies.ReadOnly = true;
            this.textBox_FoundSpecies.Size = new System.Drawing.Size(145, 30);
            this.textBox_FoundSpecies.TabIndex = 21;
            // 
            // textBox_FoundGender
            // 
            this.textBox_FoundGender.Location = new System.Drawing.Point(377, 228);
            this.textBox_FoundGender.Name = "textBox_FoundGender";
            this.textBox_FoundGender.Size = new System.Drawing.Size(145, 30);
            this.textBox_FoundGender.TabIndex = 22;
            // 
            // textBox_FoundInjury
            // 
            this.textBox_FoundInjury.Location = new System.Drawing.Point(377, 329);
            this.textBox_FoundInjury.Name = "textBox_FoundInjury";
            this.textBox_FoundInjury.Size = new System.Drawing.Size(145, 30);
            this.textBox_FoundInjury.TabIndex = 23;
            // 
            // listView_Found
            // 
            this.listView_Found.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_Found.HideSelection = false;
            this.listView_Found.Location = new System.Drawing.Point(53, 235);
            this.listView_Found.Name = "listView_Found";
            this.listView_Found.Size = new System.Drawing.Size(200, 415);
            this.listView_Found.TabIndex = 24;
            this.listView_Found.UseCompatibleStateImageBehavior = false;
            this.listView_Found.View = System.Windows.Forms.View.Details;
            this.listView_Found.SelectedIndexChanged += new System.EventHandler(this.listView_Found_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Faj";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hol";
            this.columnHeader3.Width = 150;
            // 
            // textBox_FoundId
            // 
            this.textBox_FoundId.Location = new System.Drawing.Point(377, 81);
            this.textBox_FoundId.Name = "textBox_FoundId";
            this.textBox_FoundId.ReadOnly = true;
            this.textBox_FoundId.Size = new System.Drawing.Size(145, 30);
            this.textBox_FoundId.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 23);
            this.label9.TabIndex = 25;
            this.label9.Text = "Azonosító";
            // 
            // FormFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AZ_Desktop.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(650, 695);
            this.Controls.Add(this.textBox_FoundId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listView_Found);
            this.Controls.Add(this.textBox_FoundInjury);
            this.Controls.Add(this.textBox_FoundGender);
            this.Controls.Add(this.textBox_FoundSpecies);
            this.Controls.Add(this.richTextBox_FoundOther);
            this.Controls.Add(this.textBox_FoundChoice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_FoundDelete);
            this.Controls.Add(this.button_FoundUpdate);
            this.Controls.Add(this.pictureBox_FoundImage);
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
            this.Text = "v";
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
        private System.Windows.Forms.TextBox textBox_FoundGender;
        private System.Windows.Forms.TextBox textBox_FoundInjury;
        private System.Windows.Forms.ListView listView_Found;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox textBox_FoundId;
        private System.Windows.Forms.Label label9;
    }
}