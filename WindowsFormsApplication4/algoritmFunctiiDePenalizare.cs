using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class algoritmFunctiiDePenalizare
    {
        
        public List<double> ConsumulSpecificPmaxim = new List<double>();
        List<double> ConsumulSpecificPeconomic = new List<double>();
        List<double> ConsumulSpecificPminim = new List<double>();
        public List<double> PuterileToate = new List<double>();
        

        




        public algoritmFunctiiDePenalizare(List<double>consumMinim,List<double>consumEconomic,List<double>consumMaxim)
        {
            this.ConsumulSpecificPmaxim = consumMaxim;
            this.ConsumulSpecificPeconomic = consumEconomic;
            this.ConsumulSpecificPminim = consumMinim;
      
        }


        public void RepartitiePuteri(
            List<double> cresterileRelativeTotal,
            List<double> coeficientB,
            List<double> coeficientk,
            List<double> coeficientA, 
            List<double> Pminima,
            List<double> coeficientD,
            List<double> coeficientE,
            List<double> Pmaxima
            )
        {
            cresterileRelativeTotal.Sort();
            PuterileToate.Clear();

            for (int i = 0; i < cresterileRelativeTotal.Count; i++)
            {
                for (int j = 0; j < ConsumulSpecificPminim.Count; j++)//ConsumulSpecificPminim
                {
                    if (cresterileRelativeTotal[i] <= ConsumulSpecificPminim[j])//ConsumulSpecificPminim
                    {
                        var x = (cresterileRelativeTotal[i] - coeficientB[j] * coeficientk[j]) / //coeficientB=list2,coeficientk=list3,coeficientA=list4
                                (2 * coeficientA[j] * coeficientk[j]);
                        if (x < Pminima[j])//list5=Pminima
                        {
                            x = Pminima[j];
                        }
                        PuterileToate.Add(Math.Round(x, 2));
                    }
                    else if (cresterileRelativeTotal[i] > ConsumulSpecificPminim[j] && cresterileRelativeTotal[i] <= ConsumulSpecificPeconomic[j])
                    {
                        var x = (cresterileRelativeTotal[i] - coeficientB[j] * coeficientk[j]) /
                                (2 * coeficientA[j] * coeficientk[j]);
                        PuterileToate.Add(Math.Round(x, 2));

                    }
                    else if (cresterileRelativeTotal[i] > ConsumulSpecificPeconomic[j] && cresterileRelativeTotal[i] <= ConsumulSpecificPmaxim[j])//list6=ConsumulSpecificMaxim
                    {
                        var x = (cresterileRelativeTotal[i] - coeficientE[j] * coeficientk[j]) / //coeficientE=list7
                                (2 * coeficientD[j] * coeficientk[j]); //coeficientD = list6
                        PuterileToate.Add(Math.Round(x, 2));

                    }
                    else if (cresterileRelativeTotal[i] > ConsumulSpecificPmaxim[j])
                    {
                        var x = (cresterileRelativeTotal[i] - coeficientE[j] * coeficientk[j]) /
                                (2 * coeficientD[j] * coeficientk[j]);
                        if (x > Pmaxima[j]) //list8 = pmaxim
                        {
                            x = Pmaxima[j];
                        }
                        PuterileToate.Add(Math.Round(x, 2));

                    }

                }
            }
        }


    }
}
