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
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            ordersTableAdapter1.Fill(nwDataSet1.Orders);
            order_DetailsTableAdapter1.Fill(nwDataSet1.Order_Details);
            FillCombox();
        }

        private void FillCombox()
        {
            var q = from c in nwDataSet1.Orders
                    orderby c.OrderDate.Year
                    select c.OrderDate.Year;
            foreach (int a in q.Distinct())
            {
                comboBox1.Items.Add(a);
            }

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //this.nwDataSet1.Products.Take(10);//Top 10 Skip(10)

            //Distinct()
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files =  dir.GetFiles();
            var q = from f in files
                    where f.Extension == ".log"
                    select f;
            this.dataGridView1.DataSource = q.ToList();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = nwDataSet1.Orders;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = from y in nwDataSet1.Orders
                    where y.OrderDate.Year == Convert.ToInt32(comboBox1.SelectedItem.ToString())
                    select y;

            dataGridView1.DataSource = q.ToList();
            bindingSource1.DataSource = nwDataSet1.Orders[0].GetChildRows("FK_Order_Details_Orders");
            dataGridView2.DataSource = bindingSource1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    where f.CreationTime.Year == 2021
                    select f;
            this.dataGridView1.DataSource = q.ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    where f.Length>100000
                    select f;
            this.dataGridView1.DataSource = q.ToList();
        }

        
    }
}
