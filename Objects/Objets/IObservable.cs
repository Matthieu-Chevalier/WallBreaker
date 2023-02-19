using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public interface IObservable
    {
        void AjouterObservateur(IObserver observateur);
        void SupprimerObservateur(IObserver observateur);
        void AvertirObservateurs();
    }

}
