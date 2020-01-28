namespace pictureFactoring
{
    partial class main_form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.run_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.clear_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label_TSM = new System.Windows.Forms.ToolStripStatusLabel();
            this.pb = new System.Windows.Forms.ToolStripProgressBar();
            this.value_TSM = new System.Windows.Forms.ToolStripStatusLabel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.size_NUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.make_soft_chb = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.coord_x = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.coord_y = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.num_NUD = new System.Windows.Forms.NumericUpDown();
            this.add_BTN = new System.Windows.Forms.Button();
            this.remove_BTN = new System.Windows.Forms.Button();
            this.template_GB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.curr_num_LBL = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_NUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_NUD)).BeginInit();
            this.template_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.run_TSMI,
            this.clear_TSMI,
            this.exit_TSMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // run_TSMI
            // 
            this.run_TSMI.Name = "run_TSMI";
            this.run_TSMI.Size = new System.Drawing.Size(81, 20);
            this.run_TSMI.Text = "Выполнить";
            this.run_TSMI.Click += new System.EventHandler(this.run_TSMI_Click);
            // 
            // clear_TSMI
            // 
            this.clear_TSMI.Name = "clear_TSMI";
            this.clear_TSMI.Size = new System.Drawing.Size(71, 20);
            this.clear_TSMI.Text = "Очистить";
            this.clear_TSMI.Click += new System.EventHandler(this.clear_TSMI_Click);
            // 
            // exit_TSMI
            // 
            this.exit_TSMI.Name = "exit_TSMI";
            this.exit_TSMI.Size = new System.Drawing.Size(53, 20);
            this.exit_TSMI.Text = "Выход";
            this.exit_TSMI.Click += new System.EventHandler(this.exit_TSMI_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_TSM,
            this.pb,
            this.value_TSM,
            this.toolStripStatusLabel1,
            this.coord_x,
            this.toolStripStatusLabel3,
            this.coord_y});
            this.statusStrip1.Location = new System.Drawing.Point(0, 304);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(534, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label_TSM
            // 
            this.label_TSM.Name = "label_TSM";
            this.label_TSM.Size = new System.Drawing.Size(66, 17);
            this.label_TSM.Text = "Состояние";
            // 
            // pb
            // 
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 16);
            // 
            // value_TSM
            // 
            this.value_TSM.Name = "value_TSM";
            this.value_TSM.Size = new System.Drawing.Size(12, 17);
            this.value_TSM.Text = "-";
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.Black;
            this.picture.Location = new System.Drawing.Point(0, 24);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(280, 280);
            this.picture.TabIndex = 2;
            this.picture.TabStop = false;
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseLeave += new System.EventHandler(this.picture_MouseLeave);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_MouseUp);
            // 
            // size_NUD
            // 
            this.size_NUD.Location = new System.Drawing.Point(126, 19);
            this.size_NUD.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.size_NUD.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.size_NUD.Name = "size_NUD";
            this.size_NUD.Size = new System.Drawing.Size(42, 20);
            this.size_NUD.TabIndex = 3;
            this.size_NUD.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Размер кисти";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.make_soft_chb);
            this.groupBox1.Controls.Add(this.size_NUD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(286, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 83);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // make_soft_chb
            // 
            this.make_soft_chb.AutoSize = true;
            this.make_soft_chb.Checked = true;
            this.make_soft_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.make_soft_chb.Location = new System.Drawing.Point(126, 45);
            this.make_soft_chb.Name = "make_soft_chb";
            this.make_soft_chb.Size = new System.Drawing.Size(15, 14);
            this.make_soft_chb.TabIndex = 5;
            this.make_soft_chb.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Смягчить границы";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabel1.Text = "X";
            // 
            // coord_x
            // 
            this.coord_x.AutoSize = false;
            this.coord_x.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coord_x.Name = "coord_x";
            this.coord_x.Size = new System.Drawing.Size(40, 17);
            this.coord_x.Text = "0";
            this.coord_x.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabel3.Text = "Y";
            // 
            // coord_y
            // 
            this.coord_y.AutoSize = false;
            this.coord_y.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coord_y.Name = "coord_y";
            this.coord_y.Size = new System.Drawing.Size(40, 17);
            this.coord_y.Text = "0";
            this.coord_y.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(15, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Шаблон для цифры";
            // 
            // num_NUD
            // 
            this.num_NUD.Enabled = false;
            this.num_NUD.Location = new System.Drawing.Point(125, 19);
            this.num_NUD.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.num_NUD.Name = "num_NUD";
            this.num_NUD.Size = new System.Drawing.Size(42, 20);
            this.num_NUD.TabIndex = 3;
            // 
            // add_BTN
            // 
            this.add_BTN.Location = new System.Drawing.Point(18, 45);
            this.add_BTN.Name = "add_BTN";
            this.add_BTN.Size = new System.Drawing.Size(149, 23);
            this.add_BTN.TabIndex = 6;
            this.add_BTN.Text = "Добавить";
            this.add_BTN.UseVisualStyleBackColor = true;
            this.add_BTN.Click += new System.EventHandler(this.add_BTN_Click);
            // 
            // remove_BTN
            // 
            this.remove_BTN.Location = new System.Drawing.Point(18, 74);
            this.remove_BTN.Name = "remove_BTN";
            this.remove_BTN.Size = new System.Drawing.Size(149, 23);
            this.remove_BTN.TabIndex = 6;
            this.remove_BTN.Text = "Удалить";
            this.remove_BTN.UseVisualStyleBackColor = true;
            this.remove_BTN.Click += new System.EventHandler(this.remove_BTN_Click);
            // 
            // template_GB
            // 
            this.template_GB.Controls.Add(this.num_NUD);
            this.template_GB.Controls.Add(this.remove_BTN);
            this.template_GB.Controls.Add(this.label5);
            this.template_GB.Controls.Add(this.add_BTN);
            this.template_GB.Enabled = false;
            this.template_GB.Location = new System.Drawing.Point(287, 177);
            this.template_GB.Name = "template_GB";
            this.template_GB.Size = new System.Drawing.Size(235, 115);
            this.template_GB.TabIndex = 7;
            this.template_GB.TabStop = false;
            this.template_GB.Text = "Шаблон";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(286, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Текущая цифра:";
            // 
            // curr_num_LBL
            // 
            this.curr_num_LBL.AutoSize = true;
            this.curr_num_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.curr_num_LBL.ForeColor = System.Drawing.Color.Red;
            this.curr_num_LBL.Location = new System.Drawing.Point(409, 132);
            this.curr_num_LBL.Name = "curr_num_LBL";
            this.curr_num_LBL.Size = new System.Drawing.Size(0, 18);
            this.curr_num_LBL.TabIndex = 8;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 326);
            this.Controls.Add(this.curr_num_LBL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.template_GB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main_form";
            this.ShowIcon = false;
            this.Text = "Скелетизация";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_NUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_NUD)).EndInit();
            this.template_GB.ResumeLayout(false);
            this.template_GB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem run_TSMI;
        private System.Windows.Forms.ToolStripMenuItem clear_TSMI;
        private System.Windows.Forms.ToolStripMenuItem exit_TSMI;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel label_TSM;
        private System.Windows.Forms.ToolStripProgressBar pb;
        private System.Windows.Forms.ToolStripStatusLabel value_TSM;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.NumericUpDown size_NUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox make_soft_chb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel coord_x;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel coord_y;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num_NUD;
        private System.Windows.Forms.Button add_BTN;
        private System.Windows.Forms.Button remove_BTN;
        private System.Windows.Forms.GroupBox template_GB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label curr_num_LBL;
    }
}

