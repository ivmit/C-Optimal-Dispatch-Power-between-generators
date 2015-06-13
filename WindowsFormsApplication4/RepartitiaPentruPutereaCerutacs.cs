using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class RepartitiaPentruPutereaCerutacs
    {
        public List<double> CresterileTotalePePalier = new List<double>(); 

        public void CresterileRelativeInFunctieDePutereaCeruta(List<double> list1, List<double> list2, List<double> list3)
        {
            for (int i = 0, k = 1; i < list1.Count; i++, k++) //list1=CresterileToate
            {
                for (int j = 0; j < list3.Count; j++)
                {
                    if (list3[j] >= list2[i] && list3[j] <= list2[k]) //list2=puterea Totala, list3 =putere palier
                    {
                        var x = (((list3[j] - list2[i]) / (list2[k] - list2[i])) *
                                (list1[k] - list1[i])) + list1[i];
                        CresterileTotalePePalier.Add(x);
                    }
                }
            }
        }
    }
}
