using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace pictureFactoring
{
    public class solution
    {
        private Bitmap bmp; //массив точек - графика
        public bool[,] bin_map; //массив точек - бинарный
        public bool[,] first_bin_map; //массив точек - бинарный исходный

        public solution (Bitmap _bmp)
        {
            bmp = _bmp;
            bmp_to_bin_map();
            first_bin_map = bin_map;
            add_round_templates();
        }

        public List<Point> borders; //список граничных точек
        public List<Point> first_borders; //список граничных точек

        public class bord_iteration
        {
            public List<Point> iteration;
            public bord_iteration (List<Point> _iteration)
            {
                iteration = new List<Point>();
                iteration.AddRange(_iteration);
            }
        }

        //public List<Point> skel1 = new List<Point>();


        /// <summary>
        /// Шаг увеличения зоны упрощения структуры бинарной карты изображения (зоны скелетизации)
        /// </summary>
        /// <param name="r">радиус зоны</param>
        /// <returns>Было ли произведено упрощение (остались ли пиксели)</returns>
        public bool iteration (int r)
        {
            //bool deleted = false;
            var template = get_round_template(r);
            var deletion_area = new List<Point>();
            foreach (Point p in first_borders)
            {
                int w = bmp.Width - 1, h = bmp.Height - 1;
                for (int i = 0; i < 2 * r + 1; i++)
                {
                    for (int j = 0; j < 2 * r + 1; j++)
                    {
                        int x = i - r;
                        int y = j - r;
                        int X = p.X + x;
                        int Y = p.Y + y;
                        if (X > 1 && X < w && Y > 1 && Y < h)
                        {
                            if (bin_map[X, Y] && template[i, j])//&& !skel1.Contains(new Point(X,Y))
                            {
                                deletion_area.Add(new Point(X, Y));
                            }
                        }
                    }
                }
            }

            return erase(deletion_area);
        }

        /// <summary>
        /// Удаляет слой на границе толщиной r
        /// </summary>
        /// <param name="r">Толщина слоя</param>
        public void delete_borders (int r)
        {
            var template = get_round_template(r);
            foreach (Point p in first_borders)
            {
                int w = bmp.Width - 1, h = bmp.Height - 1;
                for (int i = 0; i < 2 * r + 1; i++)
                {
                    for (int j = 0; j < 2 * r + 1; j++)
                    {
                        int x = i - r;
                        int y = j - r;
                        int X = p.X + x;
                        int Y = p.Y + y;
                        if (X > 1 && X < w && Y > 1 && Y < h)
                        {
                            if (bin_map[X, Y] && template[i, j])//&& !skel1.Contains(new Point(X,Y))
                            {
                                bin_map[X, Y] = false;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает список точек, представляющий скелет (все оставшиеся точки от исходного изображения)
        /// </summary>
        /// <returns>Скелет изображения</returns>
        public List<Point> add_to_skel ()
        {
            var skel = new List<Point>();
            int w = bmp.Width - 1, h = bmp.Height - 1;
            for (int i = 1; i < w; i++)
            {
                for (int j = 1; j < h; j++)
                {
                    if(bin_map[i,j])
                    {
                        skel.Add(new Point(i,j));
                    }
                }
            }
            return skel;
        }
        
        /// <summary>
        /// Выделение особых точек с помощью проверки связности
        /// </summary>
        /// <param name="group">Скелет</param>
        public void tops_cros_update (List<Point> group)
        {
            tops = new List<Point>();
            cros = new List<Point>();

            foreach (Point p in group)
            {
                var neighbors = get_neighbor_values_arr(p.X, p.Y);
                int count_n = 0;
                foreach (var n in neighbors)
                {
                    if (n)
                    {
                        count_n++;
                    }
                }
                if (count_n == 1)
                {
                    tops.Add(p);
                }
                else if (count_n > 2)
                {
                    int count_d = 0;
                    var neighbors_ = get_line_nighbors(p);
                    for (int i = 1; i < 8; i++)
                    {
                        if (neighbors_[i] != neighbors_[i - 1])
                        {
                            count_d++;
                        }
                    }
                    if (count_d > 4)
                    {
                        cros.Add(p);
                    }
                    else
                    {
                        if (has_angle(neighbors) && count_n > 3)
                        {
                            cros.Add(p);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Возвращяет массив подряд идущих точек ("змейкой" вокруг начальной точки) для проверки связности
        /// </summary>
        /// <param name="p">Начальная точка</param>
        /// <returns></returns>
        public bool[] get_line_nighbors(Point p)
        {
            bool[] neighbors = new bool[8];
            var x = p.X;
            var y = p.Y;
            neighbors[0] = bin_map[x - 1, y - 1];
            neighbors[1] = bin_map[x, y - 1];
            neighbors[2] = bin_map[x + 1, y - 1];
            neighbors[3] = bin_map[x + 1, y];
            neighbors[4] = bin_map[x + 1, y + 1];
            neighbors[5] = bin_map[x, y + 1];
            neighbors[6] = bin_map[x - 1, y + 1];
            neighbors[7] = bin_map[x - 1, y];
            return neighbors;
        }

        /// <summary>
        /// Список добавленных точек в методе pixels_buitifier
        /// </summary>
        public List<Point> added_points;
        /// <summary>
        /// Список удалённых точек в методе pixels_buitifier
        /// </summary>
        public List<Point> removed_points;
        /// <summary>
        /// Удаляет "мусор" из коллекции пикселей (до первого изменения)
        /// </summary>
        /// <param name="group">Коллекция пикселей</param>
        /// <param name="change_bin_map">Отображать ли изменения в массиве bin_map</param>
        /// <returns>Были ли изменения</returns>
        public bool pixels_buitifier(List<Point> group, bool change_bin_map = true)
        {
            added_points = new List<Point>();
            removed_points = new List<Point>();
            bool removed = false;
            Point point_added = new Point(0,0);
            foreach (Point p in group)
            {
                var n = get_neighbor_values_arr(p.X, p.Y);
                int count_n = 0;
                foreach (var n_ in n)
                {
                    if (n_)
                    {
                        count_n++;
                    }
                }
                if (count_n == 1)
                {
                    var n0 = get_true_neighbors(p)[0]; //возможно, однопиксельный вырост, проверяем
                    if (count_true_neighbors(n0) > 2)
                    {
                        removed = true;
                        //System.Windows.Forms.MessageBox.Show(string.Format("Del X:{0}, Y:{1}",p.X, p.Y));
                    }
                }
                else if (count_n == 2)
                {
                    if (n[0] && n[2])
                    {
                        point_added = new Point(p.X - 1, p.Y);
                        removed = true;
                    }
                    else if (n[0] && n[5])
                    {
                        point_added = new Point(p.X, p.Y - 1);
                        removed = true;
                    }
                    else if (n[7] && n[5])
                    {
                        point_added = new Point(p.X + 1, p.Y);
                        removed = true;
                    }
                    else if (n[7] && n[2])
                    {
                        point_added = new Point(p.X, p.Y + 1);
                        removed = true;
                    }
                    else if ((n[1] && n[3]) ||
                           (n[4] && n[1]) ||
                           (n[4] && n[6]) ||
                           (n[3] && n[6]))
                    {
                        removed = true;
                    }
                    else if ((n[1] && n[0]) || 
                        (n[1] && n[2]) ||
                        (n[4] && n[2]) ||
                        (n[4] && n[7]) ||
                        (n[5] && n[6]) ||
                        (n[6] && n[7]) ||
                        (n[0] && n[3]) ||
                        (n[3] && n[5]) )
                    {
                        removed = true;
                    }
                }
                else if (count_n > 2 && count_n < 6)
                {
                    
                    if ((n[0] && n[1] && n[2] && !n[5] && !n[6] && !n[7]) ||
                        (n[0] && n[3] && n[5] && !n[2] && !n[4] && !n[7]) ||
                        (n[7] && n[6] && n[5] && !n[0] && !n[1] && !n[2]) ||
                        (n[7] && n[4] && n[2] && !n[5] && !n[3] && !n[0]))
                    {
                        removed = true;
                    }
                    else if (count_n == 3)
                    {
                        if ((n[0] && n[1] && n[3]) || 
                            (n[4] && n[1] && n[2]) || 
                            (n[4] && n[7] && n[6]) || 
                            (n[3] && n[5] && n[6]))
                        {
                            removed = true;
                        }
                        else if ((n[3] && n[1] && n[2]) ||
                            (n[3] && n[6] && n[7]) ||
                            (n[1] && n[3] && n[5]) ||
                            (n[1] && n[4] && n[7]) ||
                            (n[4] && n[1] && n[0]) ||
                            (n[4] && n[5] && n[6]) ||
                            (n[6] && n[3] && n[0]) ||
                            (n[6] && n[4] && n[2]))
                        {
                            removed = true;
                        }
                    }
                }
                if (removed)
                {
                    removed_points.Add(p);
                    if (change_bin_map)
                    {
                        bin_map[p.X, p.Y] = false;
                    }
                    if (point_added.X != 0 || point_added.Y != 0)
                    {
                        added_points.Add(point_added);
                        if (change_bin_map)
                        {
                            bin_map[point_added.X, point_added.Y] = true;
                        }
                    }
                    break;
                }
            }
            return removed;
        }

        /// <summary>
        /// Удаляет "мусор" из коллекции пикселей (весь)
        /// </summary>
        /// <param name="group">Коллекция пикселей</param>
        /// <param name="change_bin_map">Отображать ли изменения в массиве bin_map</param>
        public void full_buitifier_group (List<Point> group, bool change_bin_map = true)
        {
            while (pixels_buitifier(group, change_bin_map))
            {
                foreach (var p in removed_points)
                {
                    group.Remove(p);
                }
                foreach (var p in added_points)
                {
                    group.Add(p);
                }
            }
        }

        bool has_angle (bool[] n)
        {
            if ((n[3] && n[0] && n[1]) || (n[1] && n[2] && n[4]) || (n[4] && n[7] && n[6]) || (n[3] && n[5] && n[6]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Проверка 8-связности пикселя
        /// </summary>
        /// <param name="neighbors">массив соседей</param>
        /// <returns>true - связан, false - не связан</returns>
        bool pixel_connecting(bool[] neighbors)
        {
            int count = 0;
            for (int i = 1; i < 8; i++)
            {
                if (neighbors[i] != neighbors[i - 1])
                {
                    count++;
                }
            }
            if (count > 2)
            {
                return true; //связывает другие пиксели
            }
            else
            {
                return false; //не связывает, можно удалять
            }
        }

        Dictionary<int, bool[,]> round_templates = new Dictionary<int, bool[,]>();

        void add_round_templates ()
        {
            bool[,] temp_arr = {{ true }};
            round_templates.Add(0, temp_arr);
        }

        public bool[,] get_round_template (int radius)
        {
            if (!round_templates.ContainsKey(radius))
            {
                add_round_template(radius);
            }
            return round_templates[radius];
        }
        

        /// <summary>
        /// Добавляет шаблон радиуса r
        /// </summary>
        /// <param name="r">радиус</param>
        void add_round_template (int r)
        {
            int d = 2 * r + 1;
            int r2 = r * r;
            bool[,] temp_arr = new bool[d,d];
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    temp_arr[i, j] = (i - r) * (i - r) + (j - r) * (j - r) <= r2;
                }
            }
            round_templates.Add(r, temp_arr);
        }

        //public List<Point> get_skelet()
        //{
        //    return skelet;
        //}

        //private List<Point> skelet = new List<Point>();

        //public bool new_point = true;
        //public void make_skelet()
        //{
        //    new_point = false;
        //    foreach (var border in borders)
        //    {
        //        foreach (var point in border.get_points())
        //        {
        //            if (count_true_neighbors(point) < 3)
        //            {
        //                skelet.Add(point);
        //                new_point = true;
        //            }
        //            bin_map[point.X, point.Y] = false;
        //        }
        //    }
        //}

        //public bool deleted = true;
        //int er_count = 0;

        /// <summary>
        /// шаг скелетизации (проверка точек в граничном слое по шаблону)
        /// </summary>
        public bool erase(List<Point> _borders)
        {
            //er_count++;
            //MessageBox.Show("Border erasing "+ er_count);
            bool deleted = false;
            foreach (var point in _borders)
            {
                if (templ(point)) //точка подходит по шаблону
                {
                    bin_map[point.X, point.Y] = false;
                    deleted = true;
                }
            }
            return deleted;
        }


        public bool deleted_skel = true;
 
        public List<Point> tops;
        public List<Point> cros;
        //public List<Point> skeleton;

        //public void bord_analise()
        //{
        //    tops = new List<Point>();
        //    cros = new List<Point>();
        //    foreach (var point in skeleton)
        //    {
        //        var c = count_true_neighbors(point);
        //        if (c == 1)
        //        {
        //            tops.Add(point);
        //        }
        //        if (c > 2)
        //        {
        //            cros.Add(point);


        //        }
        //    }
        //    if (tops.Count > 0)
        //    {
        //        bool recursion = false;
        //        foreach (var top in tops)
        //        {
        //            local_tops = new List<Point>();
        //            local_tops.AddRange(tops);
        //            local_tops.Remove(top);
        //            curr_brunch = new List<Point>();
        //            curr_brunch.Add(top);
        //            curr_brunch_lenth = 0;
        //            branch_finded = false;
        //            find_neighbors(top);
        //            if (curr_brunch_lenth < 20)
        //            {
        //                foreach (var p in curr_brunch)
        //                {
        //                    skeleton.Remove(p);
        //                }
        //                recursion = true;
        //                break;
        //            }
        //        }
        //        if (recursion)
        //        {
        //            bord_analise();
        //        }
        //    }
        //}

        //List<Point> curr_brunch;
        //List<Point> local_tops;
        //int curr_brunch_lenth;
        //bool branch_finded = false;
        //private void find_neighbors (Point p)
        //{
        //    if (branch_finded)
        //    {
        //        return;
        //    }
        //    var neibs = get_true_neighbors(p);
        //    bool is_spesial_neighbor = false;
        //    bool is_in_branch = false;
        //    foreach (var n in neibs)
        //    {
        //        if (local_tops.Contains(n) || cros.Contains(n))
        //        {
        //            is_spesial_neighbor = true;
        //        }
        //        if (curr_brunch.Contains(n))
        //        {
        //            is_in_branch = true;
        //        }
        //        if (is_spesial_neighbor)
        //        {
        //            branch_finded = true;
        //            return;
        //        }
        //        if (!is_in_branch && !is_spesial_neighbor)
        //        {
        //            curr_brunch_lenth++;
        //            curr_brunch.Add(n);
        //            //MessageBox.Show(n.X + " "+ n.Y);
        //            find_neighbors(n);
        //        }
        //    }
        //}

        //точка попадает под шаблон
        private bool templ(Point point)
        {
            var n = get_neighbor_values(point);
            // шаблоны https://habr.com/post/116603/
            if
                (
                    (n[1] && n[4] && !n[3] && !n[5] && !n[6]) ||
                    (n[1] && n[3] && !n[4] && !n[7] && !n[6]) ||
                    (n[3] && n[6] && !n[1] && !n[2] && !n[4]) ||
                    (n[4] && n[6] && !n[0] && !n[1] && !n[3]) ||

                    (n[1] && n[4] && n[6] && !n[0] && !n[3] && !n[5]) ||
                    (n[3] && n[1] && n[4] && !n[5] && !n[6] && !n[7]) ||
                    (n[3] && n[4] && n[6] && !n[0] && !n[1] && !n[2]) ||
                    (n[1] && n[3] && n[6] && !n[2] && !n[4] && !n[7]) ||

                    (!n[0] && !n[1] && !n[2] && !n[3] && !n[4] && !n[5] && !n[6] && !n[7]) ||
                    (!n[0] && !n[1] &&  n[2] && !n[3] &&  n[4] && !n[5] && !n[6] &&  n[7]) ||
                    (!n[0] && !n[1] && !n[2] && !n[3] && !n[4] &&  n[5] &&  n[6] &&  n[7]) ||
                    ( n[0] && !n[1] && !n[2] &&  n[3] && !n[4] &&  n[5] && !n[6] && !n[7]) ||
                    ( n[0] &&  n[1] &&  n[2] && !n[3] && !n[4] && !n[5] && !n[6] && !n[7]) ||
                    (!n[0] && !n[1] &&  n[2] && !n[3] &&  n[4] && !n[5] && !n[6] && !n[7]) ||
                    (!n[0] && !n[1] && !n[2] && !n[3] &&  n[4] && !n[5] && !n[6] &&  n[7]) ||
                    (!n[0] && !n[1] && !n[2] && !n[3] && !n[4] &&  n[5] &&  n[6] && !n[7]) ||
                    (!n[0] && !n[1] && !n[2] && !n[3] && !n[4] && !n[5] &&  n[6] &&  n[7]) ||
                    ( n[0] && !n[1] && !n[2] &&  n[3] && !n[4] && !n[5] && !n[6] && !n[7]) ||
                    (!n[0] && !n[1] && !n[2] &&  n[3] && !n[4] &&  n[5] && !n[6] && !n[7]) ||
                    ( n[0] &&  n[1] && !n[2] && !n[3] && !n[4] && !n[5] && !n[6] && !n[7]) ||
                    (!n[0] &&  n[1] &&  n[2] && !n[3] && !n[4] && !n[5] && !n[6] && !n[7]) 
                )
            {
                return true;
            }
            return false;
        }
        
        private bool ts(Point point, List<int> nums)
        {
            var n = get_neighbor_values(point);
            if
                (
                    (n[1] && n[4] && !n[3] && !n[5] && !n[6]) ||
                    (n[1] && n[3] && !n[4] && !n[7] && !n[6]) ||
                    (n[3] && n[6] && !n[1] && !n[2] && !n[4]) ||
                    (n[4] && n[6] && !n[0] && !n[1] && !n[3]) ||
                    (n[1] && n[4] && n[6] && !n[0] && !n[3] && !n[5]) ||
                    (n[3] && n[1] && n[4] && !n[5] && !n[6] && !n[7]) ||
                    (n[3] && n[4] && n[6] && !n[0] && !n[1] && !n[2]) ||
                    (n[1] && n[3] && n[6] && !n[2] && !n[4] && !n[7])
                )
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Первый раз ищем границы или нет
        /// </summary>
        bool first = true;
        /// <summary>
        /// Записывает в borders текущие границы (с binmap)
        /// </summary>
        public void find_borders ()
        {
            borders = new List<Point>();
            int w = bmp.Width - 1, h = bmp.Height - 1;
            for (int i = 1; i < w; i++)
            {
                for (int j = 1; j < h; j++)
                {
                    if (bin_map[i,j])
                    {
                        if (count_true_streight_neighbors(new Point(i, j)) < 4)
                        {
                            borders.Add(new Point(i, j));
                        }
                    }
                   
                }
            }
            if (first)
            {
                first_borders = new List<Point>();
                first_borders.AddRange(borders);
                //full_buitifier_group(first_borders, false)
                first = false;
            }
        }




        private void bmp_to_bin_map ()
        {
            int w = bmp.Width - 1, h = bmp.Height - 1;
            bin_map = new bool[w + 1, h + 1];
            for (int i = 0; i <= w; i++)
            {
                for (int j = 0; j <= h; j++)
                {
                    if (i == 0 || j == 0 || i == w || j == h)
                    {
                        bin_map[i, j] = false;
                    }
                    else
                    {
                        bin_map[i, j] = bmp.GetPixel(i, j).B > 0;
                    }
                }
            }
        }

        [Serializable]
        public class template
        {
            public int num;
            public int[] data_arr = new int[18];
            public template() { }
            public template (int _num, int[]_data)
            {
                num = _num;
                data_arr = _data;
            }
        }

        public List<template> templates = new List<template>();

        public string filename = "templates.xml";
        public XmlSerializer formatter = new XmlSerializer(typeof(template[]));

        public void save_templates (List<template> temps)
        {
            if (temps.Count() > 0)
            {
                template[] _temps = temps.ToArray();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, _temps);
                }
            }
            else
            {
                File.Delete(filename);
            }
        }

        public void load_templates ()
        {
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    template[] _temps = (template[])formatter.Deserialize(fs);
                    templates = new List<template>();
                    foreach (template temp in _temps)
                    {
                        templates.Add(temp);
                    }
                }
            }
            else
            {
                templates = new List<template>();
            }
            
        }

        /// <summary>
        /// Возврщает массив с координатами решётки для группы точек
        /// </summary>
        /// <param name="skelet">Группы точек</param>
        /// <returns></returns>
        public int[] get_sharp (List<Point> skelet)
        {
            int x0 = -1;
            int x3 = -1;
            int y0 = -1;
            int y3 = -1;
            foreach (Point p in skelet)
            {
                if (x0 == -1 || p.X < x0)
                {
                    x0 = p.X;
                }
                if (x3 == -1 || p.X > x3)
                {
                    x3 = p.X;
                }
                if (y0 == -1 || p.Y < y0)
                {
                    y0 = p.Y;
                }
                if (y3 == -1 || p.Y > y3)
                {
                    y3 = p.Y;
                }
            }
            int x1 = x0 + (x3 - x0) / 3;
            int x2 = x3 - (x3 - x0) / 3;
            int y1 = y0 + (y3 - y0) / 3;
            int y2 = y3 - (y3 - y0) / 3;
            return new int[] { x0, x1, x2, x3, y0, y1, y2, y3 };
        }

        /// <summary>
        /// Возвращает координаты точки в решётке 3х3
        /// </summary>
        /// <param name="sharp">Решётка</param>
        /// <param name="p">Точка</param>
        /// <returns></returns>
        public int[] get_cell_coord (int[] sharp, Point p)
        {
            int x = p.X < sharp[1] ? 1 : (p.X > sharp[2] ? 3 : 2);
            int y = p.Y < sharp[5] ? 1 : (p.Y > sharp[6] ? 3 : 2);
            return new int[] { x, y };
        }
        /// <summary>
        /// Распеределение особых точек по решётке
        /// </summary>
        /// <param name="sharp">Решётка</param>
        /// <param name="_tops">Вершины</param>
        /// <param name="_cros">Перечения</param>
        /// <returns></returns>
        public int[] get_skel_array (int[] sharp, List<Point> _tops, List<Point> _cros)
        {
            int[] temp_arr = new int[18];
            for (int i = 0; i < temp_arr.Length; i++)
            {
                temp_arr[i] = 0;
            }
            foreach(var p in _tops)
            {
                var sharp_coord = get_cell_coord(sharp, p);
                int x = sharp_coord[0] - 1;
                int y = sharp_coord[1] - 1;
                int num = (x + 3 * y) * 2;
                temp_arr[num]++;
            }
            foreach (var p in _cros)
            {
                var sharp_coord = get_cell_coord(sharp, p);
                int x = sharp_coord[0] - 1;
                int y = sharp_coord[1] - 1;
                int num = (x + 3 * y) * 2 + 1;
                temp_arr[num]++;
            }
            return temp_arr;
        }

        /// <summary>
        /// Поиск шаблона среди сохранённых
        /// </summary>
        /// <param name="temp_arr">Массив шаблона</param>
        /// <param name="temps">Коллекция сохранённых шаблонов</param>
        /// <returns>Цифра, соответствующая шаблону, иначе -1</returns>
        public template find_template (int[] temp_arr, List<template> temps)
        {
            template res = null;
            foreach (var temp in temps)
            {
                if (temp.data_arr.SequenceEqual(temp_arr))
                {
                    res = temp;
                    break;
                }
            }
            return res;
        }

        /// <summary>
        /// Добавление нового шаблона в коллекцию
        /// </summary>
        /// <param name="num">Цифра, соответствующая шаблону</param>
        /// <param name="data_arr">Массив с соответствиями</param>
        public void add_template (int num, int[] data_arr)
        {
            templates.Add(new template(num, data_arr));
        }

        //List<Point> area_points = new List<Point>();
        //List<Point> connected_points = new List<Point>();
        //private void find_border_points (Point point)
        //{
        //    if (is_point_near_board(point))
        //    {
        //        if (!points.Contains(point))
        //        {
        //            points.Add(point);
        //            foreach (var p in get_all_neighbors(point))
        //            {
        //                if (bin_map[p.X,p.Y])
        //                {
        //                    find_border_points(p);
        //                }
        //            }
        //        }
        //    }
        //}

        //bool is_point_in_skelet (Point p, int radius)
        //{
        //    bool in_skelet = false;
        //    get_local_round_connected_points(p, radius);
        //    if(connected_points.Count > 0)
        //    {
        //        var niebors = get_true_neighbors(p);
        //        Point neibour = niebors[0];
        //        int count1 = 0;

        //    }
        //    else
        //    {
        //        in_skelet = true;
        //    }


        //    return in_skelet;
        //}
        
        /// <summary>
        /// связные точки в локальной области
        /// </summary>
        /// <param name="p">центр области (связанность с ним)</param>
        /// <param name="r">радиус области</param>
        //void get_local_round_connected_points (Point p, int r)
        //{
        //    var local_points = get_true_round_neighbors(p, r);
        //    connected_points.Clear();
        //    connection_serch(p, local_points);
        //}

        //List<Point> connected_points = new List<Point>();
        //List<Point> neibour_connected_points = new List<Point>();

        //void connection_serch (Point p, List<Point> area)
        //{
        //    var neighbors = true_neigbors_in_area(p, area);
        //    foreach(Point point in neighbors)
        //    {
        //        if (!connected_points.Contains(point))
        //        {
        //            connected_points.Add(point);
        //            connection_serch(point, area);
        //        }
        //    }
        //}

        //List<Point> true_neigbors_in_area (Point p, List<Point> area)
        //{
        //    List<Point> neighbors = new List<Point>();
        //    int[] X = { -1, 0, 1, -1, 1, -1, 0, 1 };
        //    int[] Y = { 1, 1, 1, 0, 0, -1, -1, -1 };
        //    for (int i = 0; i < X.Length; i++)
        //    {
        //        if (area.Contains(new Point (p.X + X[i], p.Y + Y[i])))
        //        {
        //            neighbors.Add(new Point(p.X + X[i], p.Y + Y[i]));
        //        }
        //    }
        //    return neighbors;
        //}




        private List<Point> get_true_neighbors (Point p)
        {
            List<Point> neighbors = new List<Point>();
            foreach (var n in get_all_neighbors(p))
            {
                if (bin_map[n.X,n.Y])
                {
                    neighbors.Add(n);
                }
            }
            return neighbors;
        }

        private List<Point> get_all_neighbors(Point p)
        {
            List<Point> neighbors = new List<Point>();
            neighbors.Add(new Point(p.X - 1, p.Y - 1));
            neighbors.Add(new Point(p.X - 1, p.Y));
            neighbors.Add(new Point(p.X - 1, p.Y + 1));
            neighbors.Add(new Point(p.X, p.Y - 1));
            neighbors.Add(new Point(p.X, p.Y + 1));
            neighbors.Add(new Point(p.X + 1, p.Y - 1));
            neighbors.Add(new Point(p.X + 1, p.Y));
            neighbors.Add(new Point(p.X + 1, p.Y + 1));
            return neighbors;
        }

        bool[] get_neighbor_values_arr(int x, int y)
        {
            bool[] res = 
                {
                    bin_map[x - 1, y - 1], bin_map[x - 1, y], bin_map[x - 1, y + 1],
                    bin_map[x,     y - 1], /*      x,     y*/ bin_map[x,     y + 1],
                    bin_map[x + 1, y - 1], bin_map[x + 1, y], bin_map[x + 1, y + 1]
                };
            return res;
        }

        private List<bool> get_neighbor_values (Point p)
        {
            List<bool> neighbors = new List<bool>();
            neighbors.Add(bin_map[p.X - 1, p.Y - 1]);
            neighbors.Add(bin_map[p.X - 1, p.Y]);
            neighbors.Add(bin_map[p.X - 1, p.Y + 1]);
            neighbors.Add(bin_map[p.X, p.Y - 1]);
            neighbors.Add(bin_map[p.X, p.Y + 1]);
            neighbors.Add(bin_map[p.X + 1, p.Y - 1]);
            neighbors.Add(bin_map[p.X + 1, p.Y]);
            neighbors.Add(bin_map[p.X + 1, p.Y + 1]);
            
            return neighbors;
        }

        private bool is_point_near_board (Point point)
        {
            return get_neighbor_values(point).Contains(false);
        }

        private List<bool> get_diag_neighbor_values(Point p)
        {
            List<bool> neighbors = new List<bool>();
            neighbors.Add(bin_map[p.X - 1, p.Y - 1]);
            neighbors.Add(bin_map[p.X - 1, p.Y + 1]);
            neighbors.Add(bin_map[p.X + 1, p.Y - 1]);
            neighbors.Add(bin_map[p.X + 1, p.Y + 1]);

            return neighbors;
        }

        private List<bool> get_streight_neighbor_values(Point p)
        {
            List<bool> neighbors = new List<bool>();
            neighbors.Add(bin_map[p.X - 1, p.Y]);
            neighbors.Add(bin_map[p.X, p.Y - 1]);
            neighbors.Add(bin_map[p.X, p.Y + 1]);
            neighbors.Add(bin_map[p.X + 1, p.Y]);

            return neighbors;
        }

        private int count_true_diag_neighbors(Point point)
        {
            int count = 0;
            foreach (var point_val in get_diag_neighbor_values(point))
            {
                if (point_val)
                {
                    count++;
                }
            }
            return count;
        }

        private int count_true_streight_neighbors(Point point)
        {
            int count = 0;
            foreach (var point_val in get_streight_neighbor_values(point))
            {
                if (point_val)
                {
                    count++;
                }
            }
            return count;
        }

        private int count_true_round_neighbors(Point p, int r)
        {
            int count = 0;
            var template = get_round_template(r);
            int w = bmp.Width - 1, h = bmp.Height - 1;
            for (int i = 0; i < 2 * r + 1; i++)
            {
                for (int j = 0; j < 2 * r + 1; j++)
                {
                    int x = i - r;
                    int y = j - r;
                    int X = p.X + x;
                    int Y = p.Y + y;
                    if (X > 1 && X < w && Y > 1 && Y < h)
                    {
                        if (bin_map[X, Y] && template[i, j])
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        private List<Point> get_true_round_neighbors(Point p, int r)
        {
            List<Point> neigbors = new List<Point>();
            var template = get_round_template(r);
            int w = bmp.Width - 1, h = bmp.Height - 1;
            for (int i = 0; i < 2 * r + 1; i++)
            {
                for (int j = 0; j < 2 * r + 1; j++)
                {
                    int x = i - r;
                    int y = j - r;
                    int X = p.X + x;
                    int Y = p.Y + y;
                    if (X > 1 && X < w && Y > 1 && Y < h)
                    {
                        if (bin_map[X, Y] && template[i, j])
                        {
                            neigbors.Add(new Point(X, Y));
                        }
                    }
                }
            }
            return neigbors;
        }

        private int count_true_neighbors (Point point)
        {
            int count = 0;
            foreach (var point_val in get_neighbor_values(point))
            {
                if (point_val)
                {
                    count++;
                }
            }
            return count;
        }

        //public void 
    }
}
