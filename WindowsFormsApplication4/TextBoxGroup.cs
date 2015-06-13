using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApplication4
{
    partial class Form1
    {

        public List<double> nrGrupuri = new List<double>(); // Initializarea listelor care o sa imi contina valorile pentru calcul
        public List<double> coeficientA = new List<double>();
        public List<double> coeficientB = new List<double>();
        public List<double> coeficientC = new List<double>();
        public List<double> coeficientD = new List<double>();
        public List<double> coeficientE = new List<double>();
        public List<double> coeficientF = new List<double>();
        public List<double> Pminima = new List<double>();
        public List<double> Peconomica = new List<double>();
        public List<double> Pmaxima = new List<double>();
        public List<double> coeficientk = new List<double>();
        public static List<double> ConsumulSpecificPmaxim = new List<double>();
        public static List<double> ConsumulSpecificPeconomic = new List<double>();
        public static List<double> ConsumulSpecificPminim = new List<double>();
        public List<double> PuterePalier = new List<double>();
        public List<double> OraPalier = new List<double>();
      
       
        public List<double> cresterileRelativeTotal = new List<double>();


        List<KeyValuePair<int, string>> grupTextBox = new List<KeyValuePair<int, string>>() { 
            new KeyValuePair<int, string>(36, "grup"),
            new KeyValuePair<int, string>(62, "A"),
            new KeyValuePair<int, string>(88, "B"),
            new KeyValuePair<int, string>(114, "C"),
            new KeyValuePair<int, string>(140, "D"),
            new KeyValuePair<int, string>(166, "E"),
            new KeyValuePair<int, string>(192, "F"),
            new KeyValuePair<int, string>(218, "Pmin"),
            new KeyValuePair<int, string>(244, "Pec"),
            new KeyValuePair<int, string>(270, "Pmax"),
            new KeyValuePair<int, string>(296, "k")     
        };

        List<KeyValuePair<int, string>> PalierTextBox = new List<KeyValuePair<int, string>>() { 
            new KeyValuePair<int, string>(381, "PuterePalier"),
            new KeyValuePair<int, string>(407, "oraPalier")
                 
        };
    
        
        public void AddTextBoxGrup(string name, int counter, int axisX, int axisY, int nrGrup) //Metoda pentru grup
        { // metoda pentru casute dinamice

            TextBox textBox = new TextBox();
            textBox.Name = name + (counter+1);
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.Location = new System.Drawing.Point(axisX + 105 * counter, axisY);
            this.Controls.Add(textBox);
            if (textBox.Name.Contains("grup"))// In caz ca e o casuta cu numele grup atunci sa o personalizeze
            {
                textBox.ReadOnly = true;
                textBox.Text = (counter+1).ToString();
            }
        }

        public void stocheazaDate(List<double> name, string identifier)
        {
            foreach (Control txtbox in Controls)
            {
                if (txtbox is TextBox && txtbox.Name.Contains(identifier) && txtbox.Text.Length != 0)//Eroareeeee
                {
                    name.Add(calc(txtbox));
                    
                }
            }

        }

        private double calc(Control c) //Metoda pentru calcularea fractiilor din textboxuri
        {
            DataTable temp = new DataTable();
            return Convert.ToDouble(temp.Compute(c.Text, string.Empty));

        }
        
    }
}
