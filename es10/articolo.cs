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
        public decimal PrezzoUnitario { get; set; } 
        public bool TesseraFedelta { get; set; }    

        public articolo(string codice, string descrizione, decimal prezzoUnitario)
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
        public ArticoloAlimentare(string codice, string descrizione, decimal prezzoUnitario,int annoScadenza) : base(codice,descrizione,prezzoUnitario)
        {
            AnnoScadenza = annoScadenza;
        }

        public override void Sconta()
        {
            base.Sconta();  
        }
    }

    class ArticoloAlimentareFresco : ArticoloAlimentare
    {
        public int GiorniDopoApertura { get; set; }
        public ArticoloAlimentareFresco(string codice, string descrizione, decimal prezzoUnitario, int annoScadenza,int GiorniDopoApertura): base (codice, descrizione, prezzoUnitario)
        {

        }
    }
}
