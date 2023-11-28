using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es10
{
    class articolo
    {
        public string Codice { get; set; }  
        public string Descrizione { get; set; }
        public double PrezzoUnitario { get; set; } 
        public bool TesseraFedelta { get; set; }    

        public articolo(string codice, string descrizione, double prezzoUnitario)
        {
            Codice = codice;
            Descrizione = descrizione;
            PrezzoUnitario = prezzoUnitario;
        } 
        
        public virtual double Sconta()
        {
            if (TesseraFedelta) 
            {
                PrezzoUnitario = PrezzoUnitario- PrezzoUnitario*(5/100);
                
            }
            return PrezzoUnitario;
        }
    } 

    class ArticoloAlimentare : articolo
    {
        public int AnnoScadenza { get; set; }   
        public ArticoloAlimentare(string codice, string descrizione, double prezzoUnitario,int annoScadenza) : base(codice,descrizione,prezzoUnitario)
        {
            AnnoScadenza = annoScadenza;
        }

        public override double Sconta()
        {
            if (AnnoScadenza == DateTime.Now.Year && TesseraFedelta)
            {
                return PrezzoUnitario - base.Sconta() * (20 / 100);
            }
            if(AnnoScadenza== DateTime.Now.Year && TesseraFedelta)
            {
                return PrezzoUnitario - PrezzoUnitario * (20 / 100);
            }
            if (TesseraFedelta)
            {
                base.Sconta();
            }
            return PrezzoUnitario;
        }
    }

    class ArticoloAlimentareFresco : ArticoloAlimentare
    {
        public int GiorniDopoApertura { get; set; }
        public ArticoloAlimentareFresco(string codice, string descrizione, double prezzoUnitario, int annoScadenza,int giorniDopoApertura): base (codice, descrizione, prezzoUnitario,annoScadenza)
        {
            GiorniDopoApertura = giorniDopoApertura;
        }

        public override double Sconta()
        {
            double x = base.Sconta();
            double psconto = 10F;
            for(int i=1;i<6&&i<AnnoScadenza;i++) 
            {
                psconto -= 2F;
            }
            return x-x*psconto/100;
        }

    }

    class ArticoloNonAlimentare : articolo
    {
        public string Materiale { get; set; }
        public bool Riciclabile { get; set; }

        public ArticoloNonAlimentare(string codice, string descrizione, double prezzoUnitario,string materiale, bool riciclabile):base(codice, descrizione, prezzoUnitario)
        {
            Materiale= materiale;
            Riciclabile = riciclabile;
        }

        public override double Sconta()
        {
            if(TesseraFedelta&&Riciclabile) 
            {
                return PrezzoUnitario - base.Sconta() * 10 / 100;

            }
            if(Riciclabile&& TesseraFedelta == false)
            {
                PrezzoUnitario = PrezzoUnitario - PrezzoUnitario * 10 / 100;
            }
            if (TesseraFedelta)
            {
                base.Sconta();
            }
            return PrezzoUnitario;
        }

    } 
}
