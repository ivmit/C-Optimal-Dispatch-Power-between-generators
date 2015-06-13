using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }

        
 
        public List<double> PassValueCmin { get; set; }
        public List<double> PassValueCec { get; set; }
        public List<double> PassValueCmax { get; set; }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            DataTable table = new DataTable();
            table.Columns.Add("grup", typeof(int));
            for (var i = 1; i < PassValueCmin.Count + 1; i++)
            {
                
                table.Columns.Add("b" + i, typeof(double));

            }


            for (var i = 0; i < PassValueCmin.Count; i++)
            {
                table.Rows.Add((i+1), PassValueCmin[i], PassValueCec[i], PassValueCmax[i]);
            }

            dataGridView1.DataSource = table;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
