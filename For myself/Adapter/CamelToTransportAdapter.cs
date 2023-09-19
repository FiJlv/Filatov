using Adapter.For_the_desert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class CamelToTransportAdapter : ITransport
    {
        private Camel camel;
        public CamelToTransportAdapter(Camel camel)
        {
            this.camel = camel;        
        }

        public void Drive()
        {
            camel.Move();
        }
    }
}
