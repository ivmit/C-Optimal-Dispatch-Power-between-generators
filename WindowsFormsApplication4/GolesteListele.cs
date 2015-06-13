using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    public partial class Form1
    {
        private void GolesteListele()
        {
            flushLists FlushList = new flushLists();//Instantiaza clasa care curata listele la o reinitializare de Date
            FlushList.GolesteLista(nrGrupuri); //In caz de recalculare a datelor se sterge lista anterioara
            FlushList.GolesteLista(coeficientA);
            FlushList.GolesteLista(coeficientB);
            FlushList.GolesteLista(coeficientC);
            FlushList.GolesteLista(coeficientD);
            FlushList.GolesteLista(coeficientE);
            FlushList.GolesteLista(coeficientF);
            FlushList.GolesteLista(coeficientk);
            FlushList.GolesteLista(Pmaxima);
            FlushList.GolesteLista(Peconomica);
            FlushList.GolesteLista(Pminima);
            FlushList.GolesteLista(ConsumulSpecificPeconomic);
            FlushList.GolesteLista(ConsumulSpecificPmaxim);
            FlushList.GolesteLista(ConsumulSpecificPminim);
            

        }
    }
}
