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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public List<double> GetListPutereaTotala { get; set; }
        public List<double> GetListPuterePalier { get; set; }
        public List<double> GetListCresterileTotale { get; set; }
        public List<double> GetListnumarGrupuri { get; set; }
        public List<double> GetListConsumMinim { get; set; }
        public List<double> GetListConsumEconomic { get; set; }
        public List<double> GetListConsumMaxim { get; set; }
        public List<double> GetcoeficientB { get; set; }
        public List<double> Getcoeficientk { get; set; }
        public List<double> GetcoeficientA { get; set; }
        public List<double> GetPminima { get; set; }
        public List<double> GetcoeficientD { get; set; }
        public List<double> GetcoeficientE { get; set; }
        public List<double> GetPmaxima { get; set; }

        putereaTotalaFctb pt = new putereaTotalaFctb();
        RepartitiaPentruPutereaCerutacs repartitiePC = new RepartitiaPentruPutereaCerutacs();
        

        private void Form4_Load(object sender, EventArgs e)
        {
            pt.PutereaTotala(GetListPutereaTotala, GetListnumarGrupuri);
            repartitiePC.CresterileRelativeInFunctieDePutereaCeruta(GetListCresterileTotale, pt.putereaTotalaList, GetListPuterePalier);
            algoritmFunctiiDePenalizare alfctp = new algoritmFunctiiDePenalizare(GetListConsumMinim, GetListConsumEconomic, GetListConsumMaxim);
            
            alfctp.RepartitiePuteri(
                repartitiePC.CresterileTotalePePalier,
                GetcoeficientB,
                Getcoeficientk,
                GetcoeficientA,
                GetPminima,
                GetcoeficientD,
                GetcoeficientE,
                GetPmaxima
                );


            DataTable dt = new DataTable();
   
            dt.Columns.Add("Test 1", typeof(double)); //adauga coloane la obiectul DataTable
            dt.Columns.Add("TEst 2", typeof(double));
            dt.Columns.Add("Test 3", typeof(double));
            dt.Columns.Add("Test 4", typeof(double));
            

            for (int i = 0, j = 1, k = 2, l=0; i < alfctp.PuterileToate.Count && j < alfctp.PuterileToate.Count && k < alfctp.PuterileToate.Count && l < repartitiePC.CresterileTotalePePalier.Count; i += GetListnumarGrupuri.Count , j += GetListnumarGrupuri.Count, k += GetListnumarGrupuri.Count,l++)
            {
                dt.Rows.Add(repartitiePC.CresterileTotalePePalier[l],alfctp.PuterileToate[i], alfctp.PuterileToate[j], alfctp.PuterileToate[k]);
            }


            dataGridView1.DataSource = dt; //Adauga la View 
        }
    }
}
