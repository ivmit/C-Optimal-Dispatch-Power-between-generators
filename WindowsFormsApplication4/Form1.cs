using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        readonly DataTable _dt = new DataTable();
        int counterPalier;//Counter pentru palier
        int nrGrup = 1; // variabila ce incrementeaza cate grupuri sunt
        int counterGrup; //Counter de clickuri necesar pentru a plasarea casutelor
        int axaXgrup = 93; //coordonata axei X pentru textbox
        string pathOfFile; //CAlea unde se afla fisierul de incarcat
        algoritmFunctiiDePenalizare fctPen = new algoritmFunctiiDePenalizare(ConsumulSpecificPminim, ConsumulSpecificPeconomic, ConsumulSpecificPmaxim);
        
        CalculareaConsumuluiRelativ ccr = new CalculareaConsumuluiRelativ(); //Calculeaza consumul specific
        public Form1()
        {
            InitializeComponent();
            grup1.ReadOnly = true; //Casuta cu grup 1 facuta redmeonly
            this.WindowState = FormWindowState.Maximized; //Maximizeaza formul
        }


        private void adaugaGrupBtn_Click(object sender, EventArgs e) //Cod pentru casute dinamice
        {
            counterGrup++;
            nrGrup++;
            //Pentru fiecare key value din lista adauga "n" casute unde n e dictat de elemntele listei

            foreach (var kvp in grupTextBox )
            {
               AddTextBoxGrup(kvp.Value, counterGrup, axaXgrup, kvp.Key, nrGrup);
            }
           
 
        }

  
        private void palierButton_Click(object sender, EventArgs e)
        {
            counterPalier++;

            if (counterPalier == 24)
            {
                palierButton.Enabled = false;
                MessageBox.Show("Palierul orar este de maxim 24 de ore!");
            }

            //Pentru fiecare key value din lista adauga "n" casute unde n e dictat de elemntele listei
            foreach (KeyValuePair<int, string> kvp in PalierTextBox)
            {
                AddTextBoxGrup(kvp.Value, counterPalier, axaXgrup, kvp.Key, counterPalier);
            }
        }





        private void testBtn_Click(object sender, EventArgs e) //Testam
        {
            

            
        }
      


        private void kButton_Click(object sender, EventArgs e) //Nefolosit inca
        {
            
        }

        private void adaugaGrupuri_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dateIesireToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consumulSpecificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Form2
            {
                PassValueCmin = ConsumulSpecificPminim,
                PassValueCec = ConsumulSpecificPeconomic,
                PassValueCmax = ConsumulSpecificPmaxim
            };

            form2.Show();

        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GolesteListele();

            var openFileDialog1 = new OpenFileDialog {Filter = "Excel Files 2003-2007 |*.xls"};
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOfFile = openFileDialog1.FileName;
            }
            if (pathOfFile != "")//BUG needs revisting , daca dau cancel programul crasheaza
            {
                var connPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathOfFile
                    /*modify here*/ + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                var conn = new OleDbConnection(connPath);
                var myDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn);
                myDataAdapter.Fill(_dt);

                foreach (var kvp in grupTextBox)
                {
                    XlsToTxtBox(_dt, kvp.Value);
                }

                foreach (var kvp in PalierTextBox)
                {
                    XlsToTxtBox(_dt, kvp.Value);
                }
            }

            

            stocheazaDate(nrGrupuri, identifier: "grup");
            stocheazaDate(coeficientA, identifier: "A");
            stocheazaDate(coeficientB, identifier: "B");
            stocheazaDate(coeficientC, identifier: "C");
            stocheazaDate(coeficientD, identifier: "D");
            stocheazaDate(coeficientE, identifier: "E");
            stocheazaDate(coeficientF, identifier: "F");
            stocheazaDate(coeficientk, identifier: "k");
            stocheazaDate(Pmaxima, identifier: "Pmax");
            stocheazaDate(Pminima, identifier: "Pmin");
            stocheazaDate(Peconomica, identifier: "Pec");
            stocheazaDate(PuterePalier, identifier: "PuterePalier");
            stocheazaDate(OraPalier, identifier: "oraPalier");

            

            ccr.CalculeazaConsumul(Pminima, ConsumulSpecificPminim, coeficientA, coeficientB, coeficientk);
            ccr.CalculeazaConsumul(Pmaxima, ConsumulSpecificPmaxim, coeficientD, coeficientE, coeficientk);
            ccr.CalculeazaConsumul(Peconomica, ConsumulSpecificPeconomic, coeficientD, coeficientE, coeficientk);


            cresterileRelativeTotal = ConsumulSpecificPmaxim.Concat(ConsumulSpecificPminim).Concat(ConsumulSpecificPeconomic).ToList();
            cresterileRelativeTotal.Sort();

            fctPen.RepartitiePuteri(
               cresterileRelativeTotal,
               coeficientB,
               coeficientk,
               coeficientA,
               Pminima,
               coeficientD,
               coeficientE,
               Pmaxima
               );
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


 
        



        private void XlsToTxtBox(DataTable param1, string param2)
        {
            var rows = param1.Rows.Count; //Count rows in DataTable
            for (var i = 0; i < rows; ++i)
            {
                var extractDataRow = param1.Rows[i][param2].ToString();//identifier
                for (var index = 0; index < Controls.Count; index++)
                {
                    var c = Controls[index];
                    if (!(c is TextBox)) continue;
                    if (c.Name != "" + param2 + "" + (i + 1)) continue;
                    c.Text = extractDataRow;
                }
            }
        }

        private void repartitiaPuterilorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
            
           

            var form3 = new Form3
            {
                GetListPuteriList = fctPen.PuterileToate,
                numarGrupuri = nrGrupuri,
                GetListCresteriRelativeList = cresterileRelativeTotal
            };

            form3.Show();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rezultateOptimizareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form4 = new Form4
            {
               GetListPutereaTotala = fctPen.PuterileToate,
               GetListPuterePalier = PuterePalier,
               GetListCresterileTotale = cresterileRelativeTotal,
               GetListnumarGrupuri = nrGrupuri,
               GetListConsumMinim = ConsumulSpecificPminim,
               GetListConsumEconomic = ConsumulSpecificPeconomic,
               GetListConsumMaxim = ConsumulSpecificPmaxim,
               GetcoeficientB = coeficientB,
               Getcoeficientk = coeficientk,
               GetcoeficientA = coeficientA,
               GetPminima = Pminima,
               GetcoeficientD = coeficientD,
               GetcoeficientE = coeficientE,
               GetPmaxima = Pmaxima
            };

            form4.Show();
        }






    }

    
}
