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
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            dataGridView2.DataSource = files.ToList();

            IEnumerable<IGrouping<string, System.IO.FileInfo>> q = from f in files
                                                                   orderby f.Length
                                                                   group f by GroupLength(f.Length);
                                                                   

            //foreach (var ele in q)
            //{
            //    dataGridView2.DataSource = ele.ToList();
            //}

            //into g
            //        select new
            //        {
            //            Name = g.

            //};

            dataGridView1.DataSource = q.ToList();


            string s = "medium";
            var q1 = q.Where(n => s == n.Key);
            foreach (var i in q1)
            {
                dataGridView2.DataSource = i.ToList();
            }


            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode();
            foreach(var group in q)
            {
                tn = treeView1.Nodes.Add(group.Key.ToString());
                foreach(var item in group)
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

            var q = files.OrderBy(n=>n.CreationTime.Year).GroupBy(n => n.CreationTime.Year);
            dataGridView1.DataSource = q.ToList();

            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode();
            foreach(var group in q)
            {
                tn = treeView1.Nodes.Add(group.Key.ToString()); 
                foreach(var item in group)
                {
                    tn.Nodes.Add(item.ToString());
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            
        }
    }
}
