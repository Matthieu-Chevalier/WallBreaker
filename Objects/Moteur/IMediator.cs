using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Observer
{
    public interface IMediator
    {
        void Notify(object sender, string eventName, EventArgs eventArgs);
    }
}
