using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.UI.Models
{
    public class EndpointConfig
    {
        public EndpointConfig(string endpoint)
        {
            this.Endpoint = endpoint;
        }
        public string Endpoint { get; set; }
    }
}
