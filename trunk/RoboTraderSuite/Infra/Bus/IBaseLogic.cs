using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public interface IBaseLogic
    {
        void Enqueue(IMessage message, bool duplicate=true);
    }
}
