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
            productsTableAdapter1.Fill(nwDataSet1.Products);
            FillCombox();
            var q = nwDataSet1.Products;
            a = q.Rows.Count % 10 == 0 ? q.Rows.Count / 10 : q.Rows.Count / 10 + 1;
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

        int page = 0;
        bool flag = true;
        int a = 0;

        private void button13_Click(object sender, EventArgs e)
        {
            
            var q = nwDataSet1.Products;
            a = q.Rows.Count%10==0? q.Rows.Count/10:q.Rows.Count/10+1;
            if (page == a)
            {
                page = 0;
            }
            var p =  q.Skip(page * Convert.ToInt32(textBox1.Text));
            page = flag ? page + 1 : page + 2;
            
            dataGridView1.DataSource = p.Take(Convert.ToInt32(textBox1.Text)).ToList();
            

                    
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
        int p = 0, x = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            var q = from y in nwDataSet1.Orders
                    where y.OrderDate.Year == Convert.ToInt32(comboBox1.SelectedItem.ToString())
                    select y;
            
            bindingSource1.DataSource = q.ToList();
            dataGridView1.DataSource = bindingSource1;
            insertdatagridview2();
        }

        private void insertdatagridview2()
        {
            DataRow t = (DataRow)bindingSource1.Current;
            int a = (int)t[0];
            int i = 0;
            while (a != (int)(nwDataSet1.Orders.Rows[i][0]))
            {
                i++;
            }
            dataGridView2.DataSource = nwDataSet1.Orders[i].GetChildRows("FK_Order_Details_Orders");
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


        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            insertdatagridview2();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (page == 0)
            {
                page = a;
            }
            page = !flag ? page  - 2 : page - 1;
            var q = nwDataSet1.Products;
            var p = q.Skip(page * Convert.ToInt32(textBox1.Text));


            dataGridView1.DataSource = p.Take(Convert.ToInt32(textBox1.Text)).ToList();
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
