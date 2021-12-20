using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerOPC.Classes
{
    public class ServerOPC
    {
        //[Name("Location of server")]
        public string LocationOfServer { get; set; }

        public string OPCServer { get; set; }

        public string Status { get; set; }

        public string TestingTAG { get; set; }

        public DateTime Timestamp { get; set; }

        public string Value { get; set; }

        public string OPCIP { get; set; }

        public string Site { get; set; }
        public string ResponsibleForIncident { get; set; }
        public string Email { get; set; }
    }
}
