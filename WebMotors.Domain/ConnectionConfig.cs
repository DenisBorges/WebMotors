using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Domain
{
    public class ConnectionConfig
    {
        public ConnectionConfig(string endpoint)
        {
            this.Endpoint = endpoint;
        }
        public string Endpoint { get; set; }
    }
}
