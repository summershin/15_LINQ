using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyHomeWork
{
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();


        }
        NorthwindEntities dbcontext = new NorthwindEntities();
        IEnumerable<System.IO.FileInfo> flinq;
        IEnumerable<Product> pro;
        IEnumerable<Order> ord;
        int flag = 0;

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            //dataGridView2.DataSource = files.ToList();
            flag = 0;

            var q = from f in files
                    orderby f.Length
                    group f by GroupLength(f.Length) into g
                    select new { GroupName =  g.Key, Count = g.Count(), Group = g};

            dataGridView1.DataSource = q.ToList();

             flinq = files.Where(f => GroupLength(f.Length) == dataGridView1.CurrentRow.Cells[0].Value.ToString()).OrderByDescending(f => f.Length);

            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode();
            foreach(var group in q)
            {
                tn = treeView1.Nodes.Add(group.GroupName.ToString());
                foreach(var item in group.Group)
                {
                    tn.Nodes.Add(item.ToString());
                }
            }
        }

        private string GroupLength( long n )
        {
            if (n < 10000)
            {
                return "small";
            }
            else if (n < 50000)
            {
                return "medium";
            }
            else
            {
                return "Large";
            }
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            flag = 0;
            var q = files.OrderBy(f=>f.CreationTime.Year).GroupBy(n => n.CreationTime.Year).Select(g => new { GroupName = g.Key, Count = g.Count(), Group = g });

            dataGridView1.DataSource =q.ToList();

            flinq = files.Where(f => f.CreationTime.Year == (int)(dataGridView1.CurrentRow.Cells[0].Value)).OrderByDescending(f => f.CreationTime);

            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode();
            foreach (var group in q)
            {
                tn = treeView1.Nodes.Add(group.GroupName.ToString());
                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.ToString());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            TreeNode tn = new TreeNode();
            foreach(int num in nums)
            {
                if (treeView1.Nodes[GroupNum(num)] == null)
                {
                    tn = treeView1.Nodes.Add(GroupNum(num), GroupNum(num));
                }
                tn.Nodes.Add(num.ToString());
            }

        }

        private string GroupNum(int num)
        {
            if (num < 5)
            {
                return "small";
            }
            else if (num < 10)
            {
                return "medium";
            }
            else
            {
                return "large";
            }
        }
        
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (flag == 0)
            {
                dataGridView2.DataSource = flinq.ToList();
            }   
            else if(flag == 1)
            {
                dataGridView2.DataSource = pro.ToList();
            }
            else
            {
                dataGridView2.DataSource = ord.ToList();
            }

        }


        private void button8_Click(object sender, EventArgs e)
        {

            var q = from p in dbcontext.Products.AsEnumerable()
                    orderby p.UnitPrice
                    group p by GroupPrice(p.UnitPrice) into g
                    select new { GroupName = g.Key,Count = g.Count(),Group = g};

            flag = 1;
            pro = dbcontext.Products.AsEnumerable().Where(p => GroupPrice(p.UnitPrice) == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                .OrderBy(p => p.UnitPrice);
               
            dataGridView1.DataSource = q.ToList();
            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode();
            foreach (var group in q)
            {
                tn = treeView1.Nodes.Add(group.GroupName.ToString());
                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.ToString());
                }
            }

        }

        private string GroupPrice(decimal? unitPrice)
        {
            if (unitPrice == null)
            {
                return "Nothing";
            }
            else if (unitPrice < 30)
            {
                return "Low Price";
            }
            else if (unitPrice < 60)
            {
                return "Medium Price";
            }
            else
            {
                return "High Price";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

            var q = from o in dbcontext.Orders.AsEnumerable()
                    orderby o.OrderDate.Value.Year
                    group o by o.OrderDate.Value.Year into g
                    select new { GroupName = g.Key, Count = g.Count(),Group = g };

            flag = 2;
            dataGridView1.DataSource = q.ToList();

            ord = dbcontext.Orders.AsEnumerable().Where(p => p.OrderDate.Value.Year == (int)dataGridView1.CurrentRow.Cells[0].Value)
                .OrderBy(p => p.OrderDate.Value.Year);

            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode();
            foreach (var group in q)
            {
                tn = treeView1.Nodes.Add(group.GroupName.ToString());
                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.ToString());
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            var q = from o in dbcontext.Orders.AsEnumerable()
                    orderby o.OrderDate.Value.Year
                    group o by  o.OrderDate.Value.ToString("Y")  into g
                    select new { GroupName = g.Key,Count= g.Count(),Group = g};

            flag = 2;

            dataGridView1.DataSource = q.ToList();

            ord = dbcontext.Orders.AsEnumerable().Where(p => p.OrderDate.Value.ToString("Y") == dataGridView1.CurrentRow.Cells[0].Value.ToString());

            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode();
            foreach (var group in q)
            {
                tn = treeView1.Nodes.Add(group.GroupName.ToString());
                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = dbcontext.Order_Details.Sum(o => (int)(o.Quantity * o.UnitPrice) * (1 - o.Discount));

            //var q1 = from o in dbcontext.Order_Details
            //         select new { total = (int)(o.UnitPrice * o.Quantity) * (1 - o.Discount) };

            //MessageBox.Show($"總銷售額: {q1.Sum(n => n.total):c2}");
            MessageBox.Show($"總銷售額: {q:c2}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = (from o in dbcontext.Order_Details.AsEnumerable()
                    group o by o.Order.EmployeeID into g
                    select new { ID = g.Key, total = g.Sum(o => (int)(o.UnitPrice * o.Quantity) * (1 - o.Discount))})
                    .OrderByDescending(o=>o.total).Take(5);

            dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = dbcontext.Products.OrderByDescending(n => n.UnitPrice).Select(n=>new { n.ProductName,n.Category.CategoryName,n.UnitPrice.Value }).Take(5);

            dataGridView1.DataSource = q.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var q = dbcontext.Products;
            bool a = q.Where(n => n.UnitPrice > 300).Any();
            string s = a ? "有單價300元以上的產品" : "沒有單價300元以上的產品";
            MessageBox.Show(s);
            dataGridView1.DataSource = q.OrderByDescending(n => n.UnitPrice).Select(n => new { n.ProductName, n.UnitPrice }).ToList();


        }
    }
}
