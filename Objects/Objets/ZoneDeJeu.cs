using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public class ZoneDeJeu
    {

        public ZoneDeJeu(int murHaut, int murBas, int murGauche, int murDroit)
        {
            MurHaut = murHaut;
            MurBas = murBas;
            MurGauche = murGauche;
            MurDroit = murDroit;
        }

        public int MurHaut { get;  }
        public int MurBas { get;  }
        public int MurGauche { get;  }
        public int MurDroit { get;  }

    }
}
