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

        public Brique(int resistance)
        {
            this.resistance = resistance;
        }
        public void DecreaseResistance()
        {
            resistance -= 1;
            Notify();
        }
        private void Notify()
        {
            if (resistance == 0)
            {
                //Prévenir de la suppression
            }
           
        }


      
    }
}
