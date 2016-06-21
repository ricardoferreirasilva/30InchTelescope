namespace MyFirstApp
{
    partial class Form1
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
            this.button_calculate = new System.Windows.Forms.Button();
            this.text_ra_h = new System.Windows.Forms.TextBox();
            this.text_ra_m = new System.Windows.Forms.TextBox();
            this.text_ra_s = new System.Windows.Forms.TextBox();
            this.label_raHours = new System.Windows.Forms.Label();
            this.label_raMinutes = new System.Windows.Forms.Label();
            this.label_raSeconds = new System.Windows.Forms.Label();
            this.label_ra = new System.Windows.Forms.Label();
            this.label_dec = new System.Windows.Forms.Label();
            this.button_init = new System.Windows.Forms.Button();
            this.label_init = new System.Windows.Forms.Label();
            this.button_sync = new System.Windows.Forms.Button();
            this.label_sync = new System.Windows.Forms.Label();
            this.label_calculate = new System.Windows.Forms.Label();
            this.richTextBox_result = new System.Windows.Forms.RichTextBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_dec_arcsecs = new System.Windows.Forms.TextBox();
            this.text_dec_arcmins = new System.Windows.Forms.TextBox();
            this.text_dec_degrees = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.connect_encoders = new System.Windows.Forms.Button();
            this.encoder1_title = new System.Windows.Forms.Label();
            this.encoder2_title = new System.Windows.Forms.Label();
            this.encoder3_title = new System.Windows.Forms.Label();
            this.encoder1_text = new System.Windows.Forms.TextBox();
            this.encoder2_text = new System.Windows.Forms.TextBox();
            this.encoder3_text = new System.Windows.Forms.TextBox();
            this.expected1_text = new System.Windows.Forms.TextBox();
            this.expected2_text = new System.Windows.Forms.TextBox();
            this.expected3_text = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comhold1 = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.sidereal_time = new System.Windows.Forms.Label();
            this.astro_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_calculate
            // 
            this.button_calculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_calculate.Location = new System.Drawing.Point(15, 182);
            this.button_calculate.Name = "button_calculate";
            this.button_calculate.Size = new System.Drawing.Size(75, 37);
            this.button_calculate.TabIndex = 0;
            this.button_calculate.Text = "Calculate";
            this.button_calculate.UseVisualStyleBackColor = true;
            this.button_calculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_ra_h
            // 
            this.text_ra_h.Location = new System.Drawing.Point(50, 113);
            this.text_ra_h.MaxLength = 2;
            this.text_ra_h.Name = "text_ra_h";
            this.text_ra_h.Size = new System.Drawing.Size(21, 20);
            this.text_ra_h.TabIndex = 2;
            // 
            // text_ra_m
            // 
            this.text_ra_m.Location = new System.Drawing.Point(96, 113);
            this.text_ra_m.MaxLength = 2;
            this.text_ra_m.Name = "text_ra_m";
            this.text_ra_m.Size = new System.Drawing.Size(21, 20);
            this.text_ra_m.TabIndex = 6;
            // 
            // text_ra_s
            // 
            this.text_ra_s.Location = new System.Drawing.Point(144, 113);
            this.text_ra_s.MaxLength = 2;
            this.text_ra_s.Name = "text_ra_s";
            this.text_ra_s.Size = new System.Drawing.Size(39, 20);
            this.text_ra_s.TabIndex = 7;
            // 
            // label_raHours
            // 
            this.label_raHours.AutoSize = true;
            this.label_raHours.Location = new System.Drawing.Point(77, 116);
            this.label_raHours.Name = "label_raHours";
            this.label_raHours.Size = new System.Drawing.Size(13, 13);
            this.label_raHours.TabIndex = 8;
            this.label_raHours.Text = "h";
            // 
            // label_raMinutes
            // 
            this.label_raMinutes.AutoSize = true;
            this.label_raMinutes.Location = new System.Drawing.Point(123, 116);
            this.label_raMinutes.Name = "label_raMinutes";
            this.label_raMinutes.Size = new System.Drawing.Size(15, 13);
            this.label_raMinutes.TabIndex = 9;
            this.label_raMinutes.Text = "m";
            // 
            // label_raSeconds
            // 
            this.label_raSeconds.AutoSize = true;
            this.label_raSeconds.Location = new System.Drawing.Point(189, 116);
            this.label_raSeconds.Name = "label_raSeconds";
            this.label_raSeconds.Size = new System.Drawing.Size(12, 13);
            this.label_raSeconds.TabIndex = 10;
            this.label_raSeconds.Text = "s";
            // 
            // label_ra
            // 
            this.label_ra.AutoSize = true;
            this.label_ra.Location = new System.Drawing.Point(12, 116);
            this.label_ra.Name = "label_ra";
            this.label_ra.Size = new System.Drawing.Size(25, 13);
            this.label_ra.TabIndex = 11;
            this.label_ra.Text = "RA:";
            // 
            // label_dec
            // 
            this.label_dec.AutoSize = true;
            this.label_dec.Location = new System.Drawing.Point(12, 142);
            this.label_dec.Name = "label_dec";
            this.label_dec.Size = new System.Drawing.Size(32, 13);
            this.label_dec.TabIndex = 12;
            this.label_dec.Text = "DEC:";
            // 
            // button_init
            // 
            this.button_init.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_init.Location = new System.Drawing.Point(12, 23);
            this.button_init.Name = "button_init";
            this.button_init.Size = new System.Drawing.Size(75, 44);
            this.button_init.TabIndex = 13;
            this.button_init.Text = "Celestial Pole";
            this.button_init.UseVisualStyleBackColor = true;
            this.button_init.Click += new System.EventHandler(this.button_init_Click);
            // 
            // label_init
            // 
            this.label_init.AutoSize = true;
            this.label_init.Location = new System.Drawing.Point(93, 23);
            this.label_init.Name = "label_init";
            this.label_init.Size = new System.Drawing.Size(168, 52);
            this.label_init.TabIndex = 14;
            this.label_init.Text = "Set the program coordinates\r\nto the default celestial coordinates\r\nof the Polar s" +
    "tar.\r\n\r\n";
            // 
            // button_sync
            // 
            this.button_sync.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_sync.Location = new System.Drawing.Point(299, 182);
            this.button_sync.Name = "button_sync";
            this.button_sync.Size = new System.Drawing.Size(75, 37);
            this.button_sync.TabIndex = 15;
            this.button_sync.Text = "Sync";
            this.button_sync.UseVisualStyleBackColor = true;
            this.button_sync.Click += new System.EventHandler(this.button_sync_Click);
            // 
            // label_sync
            // 
            this.label_sync.AutoSize = true;
            this.label_sync.Location = new System.Drawing.Point(390, 182);
            this.label_sync.Name = "label_sync";
            this.label_sync.Size = new System.Drawing.Size(153, 39);
            this.label_sync.TabIndex = 16;
            this.label_sync.Text = "Press Sync to tell the program\r\nyou have adjusted to the given\r\ndegrees.\r\n";
            // 
            // label_calculate
            // 
            this.label_calculate.AutoSize = true;
            this.label_calculate.Location = new System.Drawing.Point(103, 180);
            this.label_calculate.Name = "label_calculate";
            this.label_calculate.Size = new System.Drawing.Size(177, 39);
            this.label_calculate.TabIndex = 17;
            this.label_calculate.Text = "Introduce the equatorial coordinates\r\nof the celestial object you want\r\nto lock o" +
    "n. Press calculate.\r\n";
            // 
            // richTextBox_result
            // 
            this.richTextBox_result.Location = new System.Drawing.Point(12, 240);
            this.richTextBox_result.Name = "richTextBox_result";
            this.richTextBox_result.Size = new System.Drawing.Size(268, 96);
            this.richTextBox_result.TabIndex = 18;
            this.richTextBox_result.Text = "";
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(286, 313);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(50, 23);
            this.button_clear.TabIndex = 19;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "\'\'";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "\'";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "°";
            // 
            // text_dec_arcsecs
            // 
            this.text_dec_arcsecs.Location = new System.Drawing.Point(144, 139);
            this.text_dec_arcsecs.MaxLength = 5;
            this.text_dec_arcsecs.Name = "text_dec_arcsecs";
            this.text_dec_arcsecs.Size = new System.Drawing.Size(39, 20);
            this.text_dec_arcsecs.TabIndex = 22;
            // 
            // text_dec_arcmins
            // 
            this.text_dec_arcmins.Location = new System.Drawing.Point(96, 139);
            this.text_dec_arcmins.MaxLength = 2;
            this.text_dec_arcmins.Name = "text_dec_arcmins";
            this.text_dec_arcmins.Size = new System.Drawing.Size(21, 20);
            this.text_dec_arcmins.TabIndex = 21;
            // 
            // text_dec_degrees
            // 
            this.text_dec_degrees.Location = new System.Drawing.Point(50, 139);
            this.text_dec_degrees.MaxLength = 2;
            this.text_dec_degrees.Name = "text_dec_degrees";
            this.text_dec_degrees.Size = new System.Drawing.Size(21, 20);
            this.text_dec_degrees.TabIndex = 20;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitMenuButton
            // 
            this.exitMenuButton.Name = "exitMenuButton";
            this.exitMenuButton.Size = new System.Drawing.Size(37, 20);
            this.exitMenuButton.Text = "Exit";
            this.exitMenuButton.Click += new System.EventHandler(this.exitMenuButton_Click);
            // 
            // connect_encoders
            // 
            this.connect_encoders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connect_encoders.Location = new System.Drawing.Point(299, 49);
            this.connect_encoders.Name = "connect_encoders";
            this.connect_encoders.Size = new System.Drawing.Size(75, 76);
            this.connect_encoders.TabIndex = 27;
            this.connect_encoders.Text = "Connect Encoders";
            this.connect_encoders.UseVisualStyleBackColor = true;
            this.connect_encoders.Click += new System.EventHandler(this.connect_encoders_Click);
            // 
            // encoder1_title
            // 
            this.encoder1_title.AutoSize = true;
            this.encoder1_title.Location = new System.Drawing.Point(390, 43);
            this.encoder1_title.Name = "encoder1_title";
            this.encoder1_title.Size = new System.Drawing.Size(31, 13);
            this.encoder1_title.TabIndex = 28;
            this.encoder1_title.Text = "RA1:";
            // 
            // encoder2_title
            // 
            this.encoder2_title.AutoSize = true;
            this.encoder2_title.Location = new System.Drawing.Point(390, 74);
            this.encoder2_title.Name = "encoder2_title";
            this.encoder2_title.Size = new System.Drawing.Size(31, 13);
            this.encoder2_title.TabIndex = 29;
            this.encoder2_title.Text = "RA2:";
            // 
            // encoder3_title
            // 
            this.encoder3_title.AutoSize = true;
            this.encoder3_title.Location = new System.Drawing.Point(390, 108);
            this.encoder3_title.Name = "encoder3_title";
            this.encoder3_title.Size = new System.Drawing.Size(32, 13);
            this.encoder3_title.TabIndex = 30;
            this.encoder3_title.Text = "DEC:";
            // 
            // encoder1_text
            // 
            this.encoder1_text.Location = new System.Drawing.Point(455, 40);
            this.encoder1_text.MaxLength = 5;
            this.encoder1_text.Name = "encoder1_text";
            this.encoder1_text.ReadOnly = true;
            this.encoder1_text.Size = new System.Drawing.Size(88, 20);
            this.encoder1_text.TabIndex = 31;
            // 
            // encoder2_text
            // 
            this.encoder2_text.Location = new System.Drawing.Point(455, 71);
            this.encoder2_text.MaxLength = 5;
            this.encoder2_text.Name = "encoder2_text";
            this.encoder2_text.ReadOnly = true;
            this.encoder2_text.Size = new System.Drawing.Size(88, 20);
            this.encoder2_text.TabIndex = 32;
            // 
            // encoder3_text
            // 
            this.encoder3_text.Location = new System.Drawing.Point(455, 105);
            this.encoder3_text.MaxLength = 5;
            this.encoder3_text.Name = "encoder3_text";
            this.encoder3_text.ReadOnly = true;
            this.encoder3_text.Size = new System.Drawing.Size(88, 20);
            this.encoder3_text.TabIndex = 33;
            // 
            // expected1_text
            // 
            this.expected1_text.Location = new System.Drawing.Point(549, 40);
            this.expected1_text.MaxLength = 5;
            this.expected1_text.Name = "expected1_text";
            this.expected1_text.ReadOnly = true;
            this.expected1_text.Size = new System.Drawing.Size(88, 20);
            this.expected1_text.TabIndex = 34;
            // 
            // expected2_text
            // 
            this.expected2_text.Location = new System.Drawing.Point(549, 71);
            this.expected2_text.MaxLength = 5;
            this.expected2_text.Name = "expected2_text";
            this.expected2_text.ReadOnly = true;
            this.expected2_text.Size = new System.Drawing.Size(88, 20);
            this.expected2_text.TabIndex = 35;
            // 
            // expected3_text
            // 
            this.expected3_text.Location = new System.Drawing.Point(549, 105);
            this.expected3_text.MaxLength = 5;
            this.expected3_text.Name = "expected3_text";
            this.expected3_text.ReadOnly = true;
            this.expected3_text.Size = new System.Drawing.Size(88, 20);
            this.expected3_text.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(643, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(18, 20);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(643, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(18, 20);
            this.panel2.TabIndex = 38;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(643, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 20);
            this.panel3.TabIndex = 39;
            // 
            // comhold1
            // 
            this.comhold1.FormattingEnabled = true;
            this.comhold1.Location = new System.Drawing.Point(299, 27);
            this.comhold1.Name = "comhold1";
            this.comhold1.Size = new System.Drawing.Size(75, 21);
            this.comhold1.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Sidereal Time:";
            // 
            // sidereal_time
            // 
            this.sidereal_time.AutoSize = true;
            this.sidereal_time.Location = new System.Drawing.Point(170, 82);
            this.sidereal_time.Name = "sidereal_time";
            this.sidereal_time.Size = new System.Drawing.Size(31, 13);
            this.sidereal_time.TabIndex = 44;
            this.sidereal_time.Text = "0:0:0";
            // 
            // astro_button
            // 
            this.astro_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.astro_button.Location = new System.Drawing.Point(12, 78);
            this.astro_button.Name = "astro_button";
            this.astro_button.Size = new System.Drawing.Size(72, 20);
            this.astro_button.TabIndex = 45;
            this.astro_button.Text = "Astro Clock";
            this.astro_button.UseVisualStyleBackColor = true;
            this.astro_button.Click += new System.EventHandler(this.astro_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 385);
            this.Controls.Add(this.astro_button);
            this.Controls.Add(this.sidereal_time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comhold1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.expected3_text);
            this.Controls.Add(this.expected2_text);
            this.Controls.Add(this.expected1_text);
            this.Controls.Add(this.encoder3_text);
            this.Controls.Add(this.encoder2_text);
            this.Controls.Add(this.encoder1_text);
            this.Controls.Add(this.encoder3_title);
            this.Controls.Add(this.encoder2_title);
            this.Controls.Add(this.encoder1_title);
            this.Controls.Add(this.connect_encoders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_dec_arcsecs);
            this.Controls.Add(this.text_dec_arcmins);
            this.Controls.Add(this.text_dec_degrees);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.richTextBox_result);
            this.Controls.Add(this.label_calculate);
            this.Controls.Add(this.label_sync);
            this.Controls.Add(this.button_sync);
            this.Controls.Add(this.label_init);
            this.Controls.Add(this.button_init);
            this.Controls.Add(this.label_dec);
            this.Controls.Add(this.label_ra);
            this.Controls.Add(this.label_raSeconds);
            this.Controls.Add(this.label_raMinutes);
            this.Controls.Add(this.label_raHours);
            this.Controls.Add(this.text_ra_s);
            this.Controls.Add(this.text_ra_m);
            this.Controls.Add(this.text_ra_h);
            this.Controls.Add(this.button_calculate);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Celestial Coordinates";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_calculate;
        private System.Windows.Forms.TextBox text_ra_h;
        private System.Windows.Forms.TextBox text_ra_m;
        private System.Windows.Forms.TextBox text_ra_s;
        private System.Windows.Forms.Label label_raHours;
        private System.Windows.Forms.Label label_raMinutes;
        private System.Windows.Forms.Label label_raSeconds;
        private System.Windows.Forms.Label label_ra;
        private System.Windows.Forms.Label label_dec;
        private System.Windows.Forms.Button button_init;
        private System.Windows.Forms.Label label_init;
        private System.Windows.Forms.Button button_sync;
        private System.Windows.Forms.Label label_sync;
        private System.Windows.Forms.Label label_calculate;
        private System.Windows.Forms.RichTextBox richTextBox_result;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_dec_arcsecs;
        private System.Windows.Forms.TextBox text_dec_arcmins;
        private System.Windows.Forms.TextBox text_dec_degrees;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuButton;
        private System.Windows.Forms.Button connect_encoders;
        private System.Windows.Forms.Label encoder1_title;
        private System.Windows.Forms.Label encoder2_title;
        private System.Windows.Forms.Label encoder3_title;
        private System.Windows.Forms.TextBox encoder1_text;
        private System.Windows.Forms.TextBox encoder2_text;
        private System.Windows.Forms.TextBox encoder3_text;
        private System.Windows.Forms.TextBox expected1_text;
        private System.Windows.Forms.TextBox expected2_text;
        private System.Windows.Forms.TextBox expected3_text;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comhold1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sidereal_time;
        private System.Windows.Forms.Button astro_button;
    }
}

