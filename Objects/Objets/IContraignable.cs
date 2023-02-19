using Objects.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Moteurs
{
    public interface IContraignable
    {
        void ImposerContrainte(ZoneDeJeu zone);
    }
}
