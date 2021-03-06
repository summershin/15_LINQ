using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace LinqLabs
{
    public partial class Frm考試 : Form
    {
        public Frm考試()
        {
            InitializeComponent();

            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };
        }

        NorthwindEntities nwdata = new NorthwindEntities();
        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get;  set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get;  set; }
            public string Gender { get; set; }
        }
        int count = 0;

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學員國文英文科目成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	

            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |				
            // 數學不及格 ... 是誰 
            #endregion
            label3.Text = "共" + students_scores.Count() + " 位學員\n";

            count++;
            if (count == 1)
            {
                this.chart3.DataSource = null;
                this.chart3.Series.Clear();

                var q = students_scores.Take(3);
                chart3.DataSource = q.ToList();
                chart3.Series.Add("國文");
                chart3.Series[0].XValueMember = "Name";
                chart3.Series[0].YValueMembers = "Chi";

                chart3.Series.Add("英文");
                chart3.Series[1].XValueMember = "Name";
                chart3.Series[1].YValueMembers = "Eng";

                chart3.Series.Add("數學");
                chart3.Series[2].XValueMember = "Name";
                chart3.Series[2].YValueMembers = "Math";
                label3.Text = "前面三個 的學員所有科目成績";
                

            }
            else if (count == 2)
            {
                this.chart3.DataSource = null;
                this.chart3.Series.Clear();

                var q = students_scores.Skip(4).Take(2); 
                chart3.DataSource = q.ToList();
                chart3.Series.Add("國文");
                chart3.Series[0].XValueMember = "Name";
                chart3.Series[0].YValueMembers = "Chi";

                chart3.Series.Add("英文");
                chart3.Series[1].XValueMember = "Name";
                chart3.Series[1].YValueMembers = "Eng";

                chart3.Series.Add("數學");
                chart3.Series[2].XValueMember = "Name";
                chart3.Series[2].YValueMembers = "Math";

                label3.Text = "後面兩個 的學員所有科目成績	";
            }
            else if (count==3)
            {
                this.chart3.DataSource = null;
                this.chart3.Series.Clear();

                var q1 = students_scores.Where(n => n.Name == "aaa" || n.Name == "bbb" || n.Name == "ccc").Select(n => new { n.Name, n.Chi, n.Eng });
                chart3.DataSource = q1.ToList();
                chart3.Series.Add("國文");
                chart3.Series[0].XValueMember = "Name";
                chart3.Series[0].YValueMembers = "Chi";

                chart3.Series.Add("英文");
                chart3.Series[1].XValueMember = "Name";
                chart3.Series[1].YValueMembers = "Eng";
                label3.Text = " 'aaa','bbb','ccc' 的學員國文英文科目成績	";

            }
            else if(count == 4)
            {
                this.chart3.DataSource = null;
                this.chart3.Series.Clear();

                var q = students_scores.Where(n => n.Name == "bbb");
                chart3.DataSource = q.ToList();
                chart3.Series.Add("國文");
                chart3.Series[0].XValueMember = "Name";
                chart3.Series[0].YValueMembers = "Chi";

                chart3.Series.Add("英文");
                chart3.Series[1].XValueMember = "Name";
                chart3.Series[1].YValueMembers = "Eng";

                chart3.Series.Add("數學");
                chart3.Series[2].XValueMember = "Name";
                chart3.Series[2].YValueMembers = "Math";
                label3.Text = "學員 bbb 的所有科目成績";

            }
            else if (count == 5)
            {
                this.chart3.DataSource = null;
                this.chart3.Series.Clear();

                var q = students_scores.Where(n => n.Name != "bbb");
                chart3.DataSource = q.ToList();
                chart3.Series.Add("國文");
                chart3.Series[0].XValueMember = "Name";
                chart3.Series[0].YValueMembers = "Chi";

                chart3.Series.Add("英文");
                chart3.Series[1].XValueMember = "Name";
                chart3.Series[1].YValueMembers = "Eng";

                chart3.Series.Add("數學");
                chart3.Series[2].XValueMember = "Name";
                chart3.Series[2].YValueMembers = "Math";

                label3.Text = "除了學員 bbb 以外的所有科目成績";
            }
            else if (count == 6)
            {
                this.chart3.DataSource = null;
                this.chart3.Series.Clear();

                var q2 = students_scores.Where(n => n.Name == "aaa" || n.Name == "bbb" || n.Name == "ccc").Select(n => new { n.Name, n.Chi, n.Math });
                chart3.DataSource = q2.ToList();
                chart3.Series.Add("國文");
                chart3.Series[0].XValueMember = "Name";
                chart3.Series[0].YValueMembers = "Chi";

                chart3.Series.Add("數學");
                chart3.Series[1].XValueMember = "Name";
                chart3.Series[1].YValueMembers = "Math";
                label3.Text = "'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績 ";

            }
            else if (count == 7)
            {
                this.chart3.DataSource = null;
                this.chart3.Series.Clear();

                var q3 = students_scores.Where(n => n.Math < 60).Select(n => new { n.Name,n.Math }); 
                chart3.DataSource = q3.ToList();
                chart3.Series.Add("數學");
                chart3.Series[0].XValueMember = "Name";
                chart3.Series[0].YValueMembers = "Math";
                label3.Text = "數學不及格的學生";
                count = 0;
            }

            

             

        }

        private void button37_Click(object sender, EventArgs e)
        {
            //個人 sum, min, max, avg

            var q = students_scores.Select(n => new { Name = n.Name, Sum = n.Chi + n.Eng + n.Math, Min = Min(n), 
                Max = Max(n), Avg = $"{(n.Chi + n.Eng + n.Math) / 3.0}",chi = n.Chi,eng = n.Eng,math = n.Math});
            
            this.chart3.DataSource = null;
            this.chart3.Series.Clear();

            chart3.DataSource = q.ToList();
            chart3.Series.Add("Sum");
            chart3.Series[0].XValueMember = "Name";
            chart3.Series[0].YValueMembers = "Sum";

            chart3.Series.Add("Min");
            chart3.Series[1].XValueMember = "Name";
            chart3.Series[1].YValueMembers = "Min";

            chart3.Series.Add("Max");
            chart3.Series[2].XValueMember = "Name";
            chart3.Series[2].YValueMembers = "Max";

            chart3.Series.Add("Avg");
            chart3.Series[3].XValueMember = "Name";
            chart3.Series[3].YValueMembers = "Avg";

            //各科 sum, min, max, avg
            

            
        }

        private object Max(Student n)
        {
            List<int> score = new List<int> { n.Chi, n.Eng, n.Math };
            int result = score.Max();

            return result;
        }

        private int Min(Student n)
        {
            List<int> score = new List<int> { n.Chi, n.Eng, n.Math };
            int result = score.Min();
            
            return result;
        }

        List<int> scores = new List<int>();
        class Scores
        {
            public string Name;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            // split=> 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 

            Random ran = new Random();
            for(int i = 0; i < 100; i++)
            {
                scores.Add(new int());
                scores[i] =ran.Next(0, 100);
            }
            var q = scores.GroupBy(n => GroupScore(n)).Select(n => new { num = n,Group = n.Key, Count = n.Count() });
            dataGridView1.DataSource = q.ToList();

            dataGridView2.DataSource = q.Where(n => n.Group == dataGridView1.CurrentRow.Cells[0].ToString()).Select(n=> new{n.num}).ToList();


            // print 每一群是哪幾個 ? (每一群 sort by 分數 descending)
        }

        private string GroupScore(int num)
        {
            if (num < 60)
            {
                return "不及格";
            }
            else if (num < 70)
            {
                return "待加強";
            }
            else if (num < 90)
            {
                return "佳";
            }
            else
            {
                return "優良";
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            // 統計 :　所有隨機分數出現的次數/比率; sort ascending or descending
            // 63     7.00%
            // 100    6.00%
            // 78     6.00%
            // 89     5.00%
            // 83     5.00%
            // 61     4.00%
            // 64     4.00%
            // 91     4.00%
            // 79     4.00%
            // 84     3.00%
            // 62     3.00%
            // 73     3.00%
            // 74     3.00%
            // 75     3.00%
        }

        private void button34_Click(object sender, EventArgs e)
        {
            // 年度最高銷售金額 年度最低銷售金額
            // 那一年總銷售最好 ? 那一年總銷售最不好 ?  
            // 那一個月總銷售最好 ? 那一個月總銷售最不好 ?

            // 每年 總銷售分析 圖
            // 每月 總銷售分析 圖

            var q = from o in nwdata.Order_Details.AsEnumerable()
                    group o by  o.Order.OrderDate.Value.Year into g
                    select new
                    {
                        year = g.Key,
                        yearhigh = g.Max(n => n.UnitPrice),
                        yearlow = g.Min(n=>n.UnitPrice),
                        Totalyearprice = g.Where(n=>n.Order.OrderDate.Value.Year==g.Key).Sum(n=>(int)(n.UnitPrice*n.Quantity)*(1-n.Discount))
                    };

            chart1.DataSource = q.ToList();
            chart1.Series[0].Name = "每年總銷售金額";
            chart1.Series[0].XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            chart1.Series[0].XValueMember = "year";
            chart1.Series[0].YValueMembers = "TotalyearPrice";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart1.Series.Add("YearHigh");
            chart1.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart1.Series[1].XValueMember = "year";
            chart1.Series[1].YValueMembers = "yearhigh";
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


            chart1.Series.Add("YearLow");
            chart1.Series[2].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chart1.Series[2].XValueMember = "year";
            chart1.Series[2].YValueMembers = "yearlow";
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            label1.Text = $"{q.OrderBy(n=>n.Totalyearprice).Select(n=>n.year).Last()}年總銷售最好\n" +
                "銷售金額: " + $"{q.OrderBy(n => n.Totalyearprice).Select(n => n.Totalyearprice).Last():c2}" + "元\n" +
                $"{q.OrderBy(n => n.Totalyearprice).Select(n => n.year).First()}年總銷售最不好\n" +
                "銷售金額: " + $"{q.OrderBy(n => n.Totalyearprice).Select(n => n.Totalyearprice).First():c2}元\n";
                

            var q1 = from o in nwdata.Order_Details.AsEnumerable()
                    group o by o.Order.OrderDate.Value.Month into g
                    select new
                    {
                        month = g.Key,
                        Totalprice = g.Sum(n => (int)(n.UnitPrice * n.Quantity) * (1 - n.Discount))
                    };

            label2.Text = $"{q1.OrderBy(n => n.Totalprice).Select(n => n.month).Last()}月總銷售最好\n" +
               "年度最高銷售金額: " + $"{q1.OrderBy(n => n.Totalprice).Select(n => n.Totalprice).Last():c2}" + "元\n" +
               $"{q1.OrderBy(n => n.Totalprice).Select(n => n.month).First()}月總銷售最不好\n" +
               "年度最低銷售金額: " + $"{q1.OrderBy(n => n.Totalprice).Select(n => n.Totalprice).First():c2}元\n";

            chart2.DataSource = q1.ToList();
            chart2.Series[0].Name = "每月總銷售金額";
            chart2.Series[0].XValueMember = "month";
            chart2.Series[0].YValueMembers = "TotalPrice";
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


        }

        private void button6_Click(object sender, EventArgs e)
        {

            //var q = from o in nwdata.Order_Details.AsEnumerable()
            //        group o by o.Order.OrderDate.Value.Year into g
            //        select new
            //        {
            //            year = g.Key,
            //            Totalprice = g.Sum(n => (int)(n.UnitPrice * n.Quantity) * (1 - n.Discount))
            //        };
            
        }

     

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView2.DataSource = s.Select(n=>new { n });
        }
    }
}
