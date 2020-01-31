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
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.coord_x = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.coord_y = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoom_out = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoom_in = new System.Windows.Forms.ToolStripStatusLabel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.size_NUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.settings_draw_gb = new System.Windows.Forms.GroupBox();
            this.make_soft_chb = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.num_NUD = new System.Windows.Forms.NumericUpDown();
            this.add_BTN = new System.Windows.Forms.Button();
            this.remove_BTN = new System.Windows.Forms.Button();
            this.template_GB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.curr_num_LBL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.display_bord_chb = new System.Windows.Forms.CheckBox();
            this.settings_sol_gb = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.display_end_chb = new System.Windows.Forms.CheckBox();
            this.display_dots_chb = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.display_cros_chb = new System.Windows.Forms.CheckBox();
            this.display_sharp_chb = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.display_skel_chb = new System.Windows.Forms.CheckBox();
            this.zoom_perc = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_NUD)).BeginInit();
            this.settings_draw_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_NUD)).BeginInit();
            this.template_GB.SuspendLayout();
            this.settings_sol_gb.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(833, 24);
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
            this.coord_y,
            this.zoom_out,
            this.zoom_perc,
            this.zoom_in});
            this.statusStrip1.Location = new System.Drawing.Point(0, 302);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(833, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label_TSM
            // 
            this.label_TSM.Name = "label_TSM";
            this.label_TSM.Size = new System.Drawing.Size(66, 19);
            this.label_TSM.Text = "Состояние";
            // 
            // pb
            // 
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 18);
            // 
            // value_TSM
            // 
            this.value_TSM.Name = "value_TSM";
            this.value_TSM.Size = new System.Drawing.Size(12, 19);
            this.value_TSM.Text = "-";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(14, 19);
            this.toolStripStatusLabel1.Text = "X";
            // 
            // coord_x
            // 
            this.coord_x.AutoSize = false;
            this.coord_x.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coord_x.Name = "coord_x";
            this.coord_x.Size = new System.Drawing.Size(40, 19);
            this.coord_x.Text = "0";
            this.coord_x.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(14, 19);
            this.toolStripStatusLabel3.Text = "Y";
            // 
            // coord_y
            // 
            this.coord_y.AutoSize = false;
            this.coord_y.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coord_y.Name = "coord_y";
            this.coord_y.Size = new System.Drawing.Size(40, 19);
            this.coord_y.Text = "0";
            this.coord_y.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // zoom_out
            // 
            this.zoom_out.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.zoom_out.Enabled = false;
            this.zoom_out.Name = "zoom_out";
            this.zoom_out.Size = new System.Drawing.Size(16, 19);
            this.zoom_out.Text = "-";
            this.zoom_out.Click += new System.EventHandler(this.zoom_out_Click);
            // 
            // zoom_in
            // 
            this.zoom_in.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.zoom_in.Enabled = false;
            this.zoom_in.Name = "zoom_in";
            this.zoom_in.Size = new System.Drawing.Size(19, 19);
            this.zoom_in.Text = "+";
            this.zoom_in.Click += new System.EventHandler(this.zoom_in_Click);
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
            this.size_NUD.Location = new System.Drawing.Point(169, 19);
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
            this.label1.Location = new System.Drawing.Point(85, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Размер кисти";
            // 
            // settings_draw_gb
            // 
            this.settings_draw_gb.Controls.Add(this.make_soft_chb);
            this.settings_draw_gb.Controls.Add(this.size_NUD);
            this.settings_draw_gb.Controls.Add(this.label4);
            this.settings_draw_gb.Controls.Add(this.label1);
            this.settings_draw_gb.Location = new System.Drawing.Point(286, 30);
            this.settings_draw_gb.Name = "settings_draw_gb";
            this.settings_draw_gb.Size = new System.Drawing.Size(236, 113);
            this.settings_draw_gb.TabIndex = 5;
            this.settings_draw_gb.TabStop = false;
            this.settings_draw_gb.Text = "Настройки";
            // 
            // make_soft_chb
            // 
            this.make_soft_chb.AutoSize = true;
            this.make_soft_chb.Checked = true;
            this.make_soft_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.make_soft_chb.Location = new System.Drawing.Point(169, 45);
            this.make_soft_chb.Name = "make_soft_chb";
            this.make_soft_chb.Size = new System.Drawing.Size(15, 14);
            this.make_soft_chb.TabIndex = 5;
            this.make_soft_chb.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Смягчить границы";
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
            this.label2.Location = new System.Drawing.Point(286, 148);
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
            this.curr_num_LBL.Location = new System.Drawing.Point(412, 148);
            this.curr_num_LBL.Name = "curr_num_LBL";
            this.curr_num_LBL.Size = new System.Drawing.Size(0, 18);
            this.curr_num_LBL.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отобразить границы";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // display_bord_chb
            // 
            this.display_bord_chb.AutoSize = true;
            this.display_bord_chb.Checked = true;
            this.display_bord_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_bord_chb.Location = new System.Drawing.Point(155, 30);
            this.display_bord_chb.Name = "display_bord_chb";
            this.display_bord_chb.Size = new System.Drawing.Size(15, 14);
            this.display_bord_chb.TabIndex = 5;
            this.display_bord_chb.UseVisualStyleBackColor = true;
            this.display_bord_chb.CheckedChanged += new System.EventHandler(this.display_bord_chb_CheckedChanged);
            // 
            // settings_sol_gb
            // 
            this.settings_sol_gb.Controls.Add(this.panel1);
            this.settings_sol_gb.Location = new System.Drawing.Point(532, 30);
            this.settings_sol_gb.Name = "settings_sol_gb";
            this.settings_sol_gb.Size = new System.Drawing.Size(236, 113);
            this.settings_sol_gb.TabIndex = 5;
            this.settings_sol_gb.TabStop = false;
            this.settings_sol_gb.Text = "Настройки";
            this.settings_sol_gb.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.display_end_chb);
            this.panel1.Controls.Add(this.display_dots_chb);
            this.panel1.Controls.Add(this.display_bord_chb);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.display_cros_chb);
            this.panel1.Controls.Add(this.display_sharp_chb);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.display_skel_chb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(6, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 94);
            this.panel1.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Обводить точки";
            this.label10.Click += new System.EventHandler(this.label3_Click);
            // 
            // display_end_chb
            // 
            this.display_end_chb.AutoSize = true;
            this.display_end_chb.Checked = true;
            this.display_end_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_end_chb.Location = new System.Drawing.Point(155, 110);
            this.display_end_chb.Name = "display_end_chb";
            this.display_end_chb.Size = new System.Drawing.Size(15, 14);
            this.display_end_chb.TabIndex = 5;
            this.display_end_chb.UseVisualStyleBackColor = true;
            this.display_end_chb.CheckedChanged += new System.EventHandler(this.display_bord_chb_CheckedChanged);
            // 
            // display_dots_chb
            // 
            this.display_dots_chb.AutoSize = true;
            this.display_dots_chb.Checked = true;
            this.display_dots_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_dots_chb.Location = new System.Drawing.Point(155, 10);
            this.display_dots_chb.Name = "display_dots_chb";
            this.display_dots_chb.Size = new System.Drawing.Size(15, 14);
            this.display_dots_chb.TabIndex = 5;
            this.display_dots_chb.UseVisualStyleBackColor = true;
            this.display_dots_chb.CheckedChanged += new System.EventHandler(this.display_bord_chb_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Отобразить концы";
            this.label9.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Отобразить сетку";
            this.label6.Click += new System.EventHandler(this.label3_Click);
            // 
            // display_cros_chb
            // 
            this.display_cros_chb.AutoSize = true;
            this.display_cros_chb.Checked = true;
            this.display_cros_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_cros_chb.Location = new System.Drawing.Point(155, 90);
            this.display_cros_chb.Name = "display_cros_chb";
            this.display_cros_chb.Size = new System.Drawing.Size(15, 14);
            this.display_cros_chb.TabIndex = 5;
            this.display_cros_chb.UseVisualStyleBackColor = true;
            this.display_cros_chb.CheckedChanged += new System.EventHandler(this.display_bord_chb_CheckedChanged);
            // 
            // display_sharp_chb
            // 
            this.display_sharp_chb.AutoSize = true;
            this.display_sharp_chb.Checked = true;
            this.display_sharp_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_sharp_chb.Location = new System.Drawing.Point(155, 50);
            this.display_sharp_chb.Name = "display_sharp_chb";
            this.display_sharp_chb.Size = new System.Drawing.Size(15, 14);
            this.display_sharp_chb.TabIndex = 5;
            this.display_sharp_chb.UseVisualStyleBackColor = true;
            this.display_sharp_chb.CheckedChanged += new System.EventHandler(this.display_bord_chb_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Отобразить пересечения";
            this.label8.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Отобразить скелет";
            this.label7.Click += new System.EventHandler(this.label3_Click);
            // 
            // display_skel_chb
            // 
            this.display_skel_chb.AutoSize = true;
            this.display_skel_chb.Checked = true;
            this.display_skel_chb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.display_skel_chb.Location = new System.Drawing.Point(155, 70);
            this.display_skel_chb.Name = "display_skel_chb";
            this.display_skel_chb.Size = new System.Drawing.Size(15, 14);
            this.display_skel_chb.TabIndex = 5;
            this.display_skel_chb.UseVisualStyleBackColor = true;
            this.display_skel_chb.CheckedChanged += new System.EventHandler(this.display_bord_chb_CheckedChanged);
            // 
            // zoom_perc
            // 
            this.zoom_perc.Name = "zoom_perc";
            this.zoom_perc.Size = new System.Drawing.Size(25, 19);
            this.zoom_perc.Text = "100";
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 326);
            this.Controls.Add(this.curr_num_LBL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.template_GB);
            this.Controls.Add(this.settings_sol_gb);
            this.Controls.Add(this.settings_draw_gb);
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
            this.Load += new System.EventHandler(this.main_form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_NUD)).EndInit();
            this.settings_draw_gb.ResumeLayout(false);
            this.settings_draw_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_NUD)).EndInit();
            this.template_GB.ResumeLayout(false);
            this.template_GB.PerformLayout();
            this.settings_sol_gb.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.GroupBox settings_draw_gb;
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
        private System.Windows.Forms.CheckBox display_bord_chb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox settings_sol_gb;
        private System.Windows.Forms.CheckBox display_sharp_chb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox display_end_chb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox display_cros_chb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox display_skel_chb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox display_dots_chb;
        private System.Windows.Forms.ToolStripStatusLabel zoom_out;
        private System.Windows.Forms.ToolStripStatusLabel zoom_in;
        private System.Windows.Forms.ToolStripStatusLabel zoom_perc;
    }
}

