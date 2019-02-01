using System;
using System.Collections.Generic;
using System.Text;

namespace DNATrack.Common.Messaging
{
    public class RabbitMQConfiguration
    {
        public string Endpoint { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
