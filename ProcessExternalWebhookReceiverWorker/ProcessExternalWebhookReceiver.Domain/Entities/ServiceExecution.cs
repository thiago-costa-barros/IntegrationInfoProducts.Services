using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessExternalWebhookReceiver.Domain.Entities
{
    public class ServiceExecution
    {
        public int IntervalMs { get; set; }
        public int BatchSize { get; set; }
    }
}
