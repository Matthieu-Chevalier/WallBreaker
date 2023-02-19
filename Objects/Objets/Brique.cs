using Objects.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public class Brique 
    {
        private int resistance;
        public const int LARGEUR = 50;
        public const int HAUTEUR = 50;
        private Mouvement Mouvement;
        

        public Brique(int resistance, Mouvement mvt)
        {
            this.resistance = resistance;
            Mouvement = mvt;
        }
        public void Affaiblir()
        {
            resistance -= 1;
            AvertirMouvement();
        }
     

        public void AvertirMouvement()
        {
            if(resistance == 0)
            {
            Mouvement.SupprimerBrique(this);
            }
        }
    }
}
