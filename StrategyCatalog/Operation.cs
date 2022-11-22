using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.StrategyCatalog
{
    public abstract class Operation
    {

        protected CancellationToken cancellationToken;

        public Operation(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;
        }

        public abstract string getName();

        public abstract Task RunAsync();
    }
}
