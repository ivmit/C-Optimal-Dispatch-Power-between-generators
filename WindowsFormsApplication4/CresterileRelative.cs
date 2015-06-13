using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    
    
    class CalculareaConsumuluiRelativ
    {
        public void CalculeazaConsumul(List<double>name1,List<double>name2,List<double>name3, List<double>name4, List<double>name5) {
            for (int i = 0; i < name1.Count; i++)
            {
                var x = name5[i]*(name1[i]*2*name3[i] + name4[i]);
                name2.Add(Math.Round(x, 4));
            }            

        }
    }
}
