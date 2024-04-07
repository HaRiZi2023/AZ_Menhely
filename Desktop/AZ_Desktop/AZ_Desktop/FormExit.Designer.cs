namespace AZ_Desktop
{
    partial class FormExit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExit));
            this.label_ExitQuestion = new System.Windows.Forms.Label();
            this.label_ExitBye = new System.Windows.Forms.Label();
            this.button_ExitYes = new System.Windows.Forms.Button();
            this.button_ExitNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_ExitQuestion
            // 
            this.label_ExitQuestion.AutoSize = true;
            this.label_ExitQuestion.BackColor = System.Drawing.Color.White;
            this.label_ExitQuestion.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_ExitQuestion.Location = new System.Drawing.Point(87, 9);
            this.label_ExitQuestion.Name = "label_ExitQuestion";
            this.label_ExitQuestion.Size = new System.Drawing.Size(238, 30);
            this.label_ExitQuestion.TabIndex = 0;
            this.label_ExitQuestion.Text = "Valóban ki szeretne lépni?";
            // 
            // label_ExitBye
            // 
            this.label_ExitBye.AutoSize = true;
            this.label_ExitBye.BackColor = System.Drawing.Color.White;
            this.label_ExitBye.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_ExitBye.Location = new System.Drawing.Point(103, 31);
            this.label_ExitBye.Name = "label_ExitBye";
            this.label_ExitBye.Size = new System.Drawing.Size(239, 49);
            this.label_ExitBye.TabIndex = 1;
            this.label_ExitBye.Text = "Viszont látásra!";
            this.label_ExitBye.Visible = false;
            // 
            // button_ExitYes
            // 
            this.button_ExitYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button_ExitYes.Location = new System.Drawing.Point(96, 74);
            this.button_ExitYes.Name = "button_ExitYes";
            this.button_ExitYes.Size = new System.Drawing.Size(101, 33);
            this.button_ExitYes.TabIndex = 2;
            this.button_ExitYes.Text = "Igen";
            this.button_ExitYes.UseVisualStyleBackColor = false;
            this.button_ExitYes.Click += new System.EventHandler(this.button_ExitYes_Click);
            // 
            // button_ExitNo
            // 
            this.button_ExitNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button_ExitNo.Location = new System.Drawing.Point(213, 74);
            this.button_ExitNo.Name = "button_ExitNo";
            this.button_ExitNo.Size = new System.Drawing.Size(101, 33);
            this.button_ExitNo.TabIndex = 3;
            this.button_ExitNo.Text = "Nem";
            this.button_ExitNo.UseVisualStyleBackColor = false;
            this.button_ExitNo.Click += new System.EventHandler(this.button_ExitNo_Click);
            // 
            // FormExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AZ_Desktop.Properties.Resources.Login___out;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(446, 245);
            this.Controls.Add(this.button_ExitNo);
            this.Controls.Add(this.button_ExitYes);
            this.Controls.Add(this.label_ExitBye);
            this.Controls.Add(this.label_ExitQuestion);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExit";
            this.Text = "A-Z Menhely";
            this.Load += new System.EventHandler(this.FormExit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ExitQuestion;
        private System.Windows.Forms.Label label_ExitBye;
        private System.Windows.Forms.Button button_ExitYes;
        private System.Windows.Forms.Button button_ExitNo;
    }
}