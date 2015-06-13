using System;
using System.Collections;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        internal List<double> GetListPuteriList { get; set; }
        internal List<double> numarGrupuri { get; set; }
        public List<double> GetListCresteriRelativeList { get; set; }

        putereaTotalaFctb Pt = new putereaTotalaFctb();
        

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();


            Pt.PutereaTotala(GetListPuteriList, numarGrupuri); //Calculeaza Puterea totala
            GetListCresteriRelativeList.Sort(); //Sorteaza lista cu Cresteri Reltive crescator


            dt.Columns.Add("Nr. Crt.", typeof(int));//adauga coloane la obiectul DataTable
            dt.Columns.Add("Cresterile Relative", typeof(double)); //adauga coloane la obiectul DataTable


            for (var i = 1; i < numarGrupuri.Count + 1; i++)
            {

                dt.Columns.Add("Puterea Grupului " + i, typeof(double)); //adauga coloane la obiectul DataTable

            }

            dt.Columns.Add("Puterea Totala", typeof(double)); //adauga coloane la obiectul DataTable

            for (int i = 0, j = 1, k = 2, l = 0, m = 0; i < GetListPuteriList.Count && j < GetListPuteriList.Count && k < GetListPuteriList.Count && l < Pt.putereaTotalaList.Count && m < GetListCresteriRelativeList.Count; i += numarGrupuri.Count, j += numarGrupuri.Count, k += numarGrupuri.Count, l++, m++)
            {

                dt.Rows.Add((m+1),GetListCresteriRelativeList[m], GetListPuteriList[i], GetListPuteriList[j], GetListPuteriList[k], Pt.putereaTotalaList[l]);  //Adauga date pe randuri
            }
            
            dataGridView1.DataSource = dt; //Adauga la View 
            
        }

   
    }
}
