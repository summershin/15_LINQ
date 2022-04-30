using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            productPhotoTableAdapter1.Fill(awDataSet1.ProductPhoto);
            var q = from p in awDataSet1.ProductPhoto
                    orderby p.ModifiedDate
                    select p;
            dateTimePicker1.Value = q.ToList().First().ModifiedDate;
            dateTimePicker2.Value = q.ToList().Last().ModifiedDate;

            var q1 = from p in awDataSet1.ProductPhoto
                     orderby p.ModifiedDate
                     select p.ModifiedDate.Year;

           foreach(int i in q1.Distinct())
            {
                comboBox3.Items.Add(i);
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {

            var q = from p in awDataSet1.ProductPhoto
                    select p;
            dataGridView1.DataSource = q.ToList();
            pictureBox1.DataBindings.Clear();
            bindingSource1.Clear();
            bindingSource1.DataSource = dataGridView1.DataSource;
            pictureBox1.DataBindings.Add("Image", bindingSource1, "LargePhoto", true);

        }
        void GetData(DateTime P1,DateTime P2)
        {
            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate >= P1 && p.ModifiedDate <= P2
                    select p;
            dataGridView1.DataSource = q.ToList();
            lblMaster.Text = $"{P1.Date:d} 到{P2.Date:d} 期間，共有{q.Count()}筆";
            pictureBox1.DataBindings.Clear();
            bindingSource1.Clear();
            bindingSource1.DataSource = dataGridView1.DataSource;
            pictureBox1.DataBindings.Add("Image", bindingSource1, "LargePhoto",true);
        }
        void GetData(int num)
        {
            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate.Year == num 
                    select p;
            dataGridView1.DataSource = q.ToList();
            lblMaster.Text = $"{num} 年， 共有{q.Count()}筆";
            pictureBox1.DataBindings.Clear();
            bindingSource1.Clear();
            bindingSource1.DataSource = dataGridView1.DataSource;
            pictureBox1.DataBindings.Add("Image", bindingSource1, "LargePhoto",true);

        }
        void GetData(ComboBox c)
        {
            int a = c.SelectedIndex + 1;
            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate.Month <= a * 3 && p.ModifiedDate.Month >= a * 3 - 2
                    select p;
            dataGridView1.DataSource = q.ToList();
            lblMaster.Text = $"{comboBox2.Text}，共有{q.Count()}筆";
            pictureBox1.DataBindings.Clear();
            bindingSource1.Clear();
            bindingSource1.DataSource = dataGridView1.DataSource;
            pictureBox1.DataBindings.Add("Image", bindingSource1, "LargePhoto",true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetData(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(comboBox3.SelectedItem);
            GetData(year);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GetData(comboBox2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bindingSource1.Position = e.RowIndex;
        }
    }
}
