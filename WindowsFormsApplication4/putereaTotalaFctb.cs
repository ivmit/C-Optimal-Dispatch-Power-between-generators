using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class putereaTotalaFctb
    {
        public List<double> putereaTotalaList = new List<double>();

        public void PutereaTotala(List<double> list1, List<double> list2)
        {
            
            for (int i = 0, j = 1, k = 2; i < list1.Count && j < list1.Count && k < list1.Count; i += list2.Count, j += list2.Count, k += list2.Count)
            {
                var x = list1[i] + list1[j] + list1[k];
                putereaTotalaList.Add(x);
            }
          
        }

        
    }
}
