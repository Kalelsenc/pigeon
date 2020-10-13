namespace PigeonProject
{
    partial class Paint
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "Push";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.domainUpDown1.Items.Add("а");
            this.domainUpDown1.Items.Add("б");
            this.domainUpDown1.Items.Add("в");
            this.domainUpDown1.Items.Add("г");
            this.domainUpDown1.Items.Add("д");
            this.domainUpDown1.Items.Add("е");
            this.domainUpDown1.Items.Add("ё");
            this.domainUpDown1.Items.Add("ж");
            this.domainUpDown1.Items.Add("з");
            this.domainUpDown1.Items.Add("и");
            this.domainUpDown1.Items.Add("й");
            this.domainUpDown1.Items.Add("к");
            this.domainUpDown1.Items.Add("л");
            this.domainUpDown1.Items.Add("м");
            this.domainUpDown1.Items.Add("н");
            this.domainUpDown1.Items.Add("о");
            this.domainUpDown1.Items.Add("п");
            this.domainUpDown1.Items.Add("р");
            this.domainUpDown1.Items.Add("с");
            this.domainUpDown1.Items.Add("т");
            this.domainUpDown1.Items.Add("у");
            this.domainUpDown1.Items.Add("ф");
            this.domainUpDown1.Items.Add("х");
            this.domainUpDown1.Items.Add("ц");
            this.domainUpDown1.Items.Add("ч");
            this.domainUpDown1.Items.Add("ш");
            this.domainUpDown1.Items.Add("щ");
            this.domainUpDown1.Items.Add("ь");
            this.domainUpDown1.Items.Add("ы");
            this.domainUpDown1.Items.Add("ъ");
            this.domainUpDown1.Items.Add("э");
            this.domainUpDown1.Items.Add("ю");
            this.domainUpDown1.Items.Add("я");
            this.domainUpDown1.Location = new System.Drawing.Point(307, 125);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(99, 24);
            this.domainUpDown1.TabIndex = 3;
            this.domainUpDown1.Text = "domainUpDown1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(306, 155);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Режим датасета";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(306, 179);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Выбрать папку";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 303);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Paint";
            this.Text = "Paint";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
    }
}