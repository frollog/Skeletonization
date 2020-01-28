using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pictureFactoring
{
    public partial class main_form : Form
    {
        bool painting = false;
        Bitmap bmp = null;
        SolidBrush br = new SolidBrush(Color.White);

        public main_form()
        {
            InitializeComponent();
            bmp = new Bitmap(Image.FromFile("black.bmp"), picture.Width, picture.Height);
            picture.Image = bmp;
            paint(0, 0, true);
        }

        int min_r = 12;

        public void paint(int x = 0, int y = 0, bool clear = false)
        {
            Graphics g = Graphics.FromImage(picture.Image);
            if (clear)
            {
                g.Clear(Color.Black);
            }
            else
            {
                int r = (int)size_NUD.Value;
                if (draw_mode && painting)
                {
                    g.FillEllipse(br, x - r, y - r, 2*r, 2*r);
                    if (r < min_r)
                    {
                        min_r = r;
                    }
                }
            }
            g.Dispose();
            picture.Invalidate();
        }



        private void run_TSMI_Click(object sender, EventArgs e)
        {
            skeletization.solve(this);
        }


        public static class skeletization
        {
            static solution sol;
            static Graphics g;
            static List<Point> skel_first;
            static List<Point> skel_mod;
            static int[] sharp;
            static int[] skel_array;
            static solution.template curr_template;

            public static void solve(main_form form)
            {
                form.template_GB.Enabled = false;
                form.draw_mode = false;
                form.run_TSMI.Enabled = false;
                form.picture.Refresh();
                sol = new solution(form.bmp);
                sol.load_templates();
                g = Graphics.FromImage(form.picture.Image);

                sol.find_borders(); //ищем границы

                int r = 0; //начальный радиус

                if (form.make_soft_chb.Checked)
                {
                    sol.delete_borders(1);
                    r = 2;
                }


                //int r_ = (int)r_NUD.Value;
                //int lim = (int)lim_NUD.Value;
                //bool kkk = true;
                while (sol.iteration(r)) //пока есть точки, которые можно удалить
                {
                    form.paint(0, 0, true); //очищаем экран
                    form.draw_group(g, sol.first_borders, Color.Blue); //рисуем внешнюю границу
                    for (int i = 0; i < form.bmp.Width; i++) //рисуем оставшиеся точки 
                    {
                        for (int j = 0; j < form.bmp.Height; j++)
                        {
                            if (sol.bin_map[i, j])
                            {
                                g.FillRectangle(Brushes.White, i, j, 1, 1);
                            }
                        }
                    }
                    form.picture.Refresh(); //обновляем изображение
                    r++; //увеличиваем толщину слоя проверки
                         //if (kkk)
                         //{
                         //    kkk = false;
                         //    MessageBox.Show(r.ToString());
                         //}
                }

                skel_first = sol.add_to_skel(); //добавляем все оставшиеся точки в скелет
                                                    //sol.tops_cros_update(skel_first);

                form.paint(0, 0, true); //очищаем экран

                skel_mod = new List<Point>(); //модифицированный скелет
                skel_mod.AddRange(skel_first);

                //удаляем "мусорные" пиксели
                while (sol.pixels_buitifier(skel_mod))
                {
                    foreach (var p in sol.removed_points)
                    {
                        skel_mod.Remove(p);
                    }
                    foreach (var p in sol.added_points)
                    {
                        skel_mod.Add(p);
                    }
                    //draw_group(g, sol.removed_points, Color.Magenta);
                    //draw_group(g, sol.added_points, Color.AntiqueWhite);
                }
                sol.tops_cros_update(skel_mod); //поиск вершин и пересечений

                form.draw_points(g, sol.cros, Color.Green); //пересечения - обвод
                form.draw_points(g, sol.tops, Color.Yellow); //вершины - обвод

                form.draw_group(g, skel_mod, Color.Gray); //скелет
                form.draw_group(g, sol.cros, Color.Red); //точки пересечения
                form.draw_group(g, sol.tops, Color.Pink); //точки вершин

                form.draw_group(g, sol.first_borders, Color.Blue); //первичная граница

                sharp = sol.get_sharp(skel_mod);
                form.draw_sharp(g, sharp, Color.MediumPurple); //отрисовываем решётку

                skel_array = sol.get_skel_array(sharp, sol.tops, sol.cros); //массив-идентификатор особых точек
                find_templ(form);
            }

            public static void find_templ (main_form form)
            {
                curr_template = sol.find_template(skel_array, sol.templates); //найденный шаблон
                form.template_GB.Enabled = true;
                if (curr_template != null)
                {
                    form.curr_num_LBL.Text = curr_template.num.ToString();
                    form.num_NUD.Value = curr_template.num;
                    form.add_BTN.Enabled = false;
                    form.remove_BTN.Enabled = true;
                    form.num_NUD.Enabled = false;
                }
                else
                {
                    form.curr_num_LBL.Text = "не определена";
                    form.add_BTN.Enabled = true;
                    form.remove_BTN.Enabled = false;
                    form.num_NUD.Enabled = true;
                }
            }

            public static void add_templ (main_form form)
            {
                if (skel_array != null && sol != null)
                {
                    sol.add_template((int)form.num_NUD.Value, skel_array);
                    sol.save_templates(sol.templates);
                    sol.load_templates();
                    find_templ(form);
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }

            public static void remove_templ (main_form form)
            {
                if (curr_template != null && sol != null)
                {
                    sol.templates.Remove(curr_template);
                    sol.save_templates(sol.templates);
                    sol.load_templates();
                    find_templ(form);
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }


        bool draw_mode = true;

        private void clear_TSMI_Click(object sender, EventArgs e)
        {
            paint(0, 0, true);
            draw_mode = true;
            run_TSMI.Enabled = true;
            template_GB.Enabled = false;
            curr_num_LBL.Text = "";
            num_NUD.Value = 0;
        }

        private void exit_TSMI_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            painting = true;
            paint(e.X, e.Y);
        }

        private void picture_MouseLeave(object sender, EventArgs e)
        {
            painting = false;
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            paint(e.X, e.Y);
            coord_x.Text = e.X.ToString();
            coord_y.Text = e.Y.ToString();
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;
        }
        /// <summary>
        /// Отрисовывает группу точек в виде отдельных пикселей
        /// </summary>
        /// <param name="g">Объект графики для вывода</param>
        /// <param name="group">Коллекция пикселей</param>
        /// <param name="color">Цвет</param>
        private void draw_group (Graphics g, List<Point> group, Color color)
        {
            foreach (var p in group)
            {
                g.FillRectangle(new SolidBrush(color), p.X, p.Y, 1, 1);
            }
        }

        /// <summary>
        /// Отрисовывает квадратную рамку вокруг каждого из пикселей
        /// </summary>
        /// <param name="g">Объект графики для вывода</param>
        /// <param name="points">Коллекция пикселей</param>
        /// <param name="color">Цвет</param>
        private void draw_points(Graphics g, List<Point> points, Color color)
        {
            foreach (var p in points)
            {
                g.DrawRectangle(new Pen(color), p.X - 3, p.Y - 3, 6, 6);
            }
        }

        /// <summary>
        /// Отрисвывает решётку из массива с координатами
        /// </summary>
        /// <param name="g">Объект графики для вывода</param>
        /// <param name="sharp">Массив с координатами</param>
        /// <param name="color">Цвет</param>
        private void draw_sharp (Graphics g, int[]sharp, Color color)
        {
            int ord = sharp.Length / 2;
            for (int i = 0; i < ord; i++)
            {
                g.DrawLine(new Pen(color), sharp[0], sharp[ord + i], sharp[ord - 1], sharp[ord + i]); //вертикальные
                g.DrawLine(new Pen(color), sharp[i], sharp[ord], sharp[i], sharp[sharp.Length - 1]); //горизонатльные
            }
        }

        private void add_BTN_Click(object sender, EventArgs e)
        {
            skeletization.add_templ(this);
        }

        private void remove_BTN_Click(object sender, EventArgs e)
        {
            skeletization.remove_templ(this);
        }
    }
}
