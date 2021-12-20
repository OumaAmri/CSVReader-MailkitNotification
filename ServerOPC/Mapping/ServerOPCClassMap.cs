using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServerOPC.Mapping
{
    public class ServerOPCClassMap : ClassMap<Classes.ServerOPC>
    {
        public ServerOPCClassMap()
        {
            Map(m => m.LocationOfServer).Name("Location of server");
            Map(m => m.OPCServer).Name("OPC Server");
            Map(m => m.Status).Name("Status");
            Map(m => m.TestingTAG).Name("testing TAG");
            Map(m => m.Timestamp).Name("timestamp");
            Map(m => m.Value).Name("value");
            Map(m => m.OPCIP).Name("OPC IP");
            Map(m => m.Site).Name("Site");
            Map(m => m.ResponsibleForIncident).Name("Responsible for Incident");
            Map(m => m.Email).Name("Email");


        }
    }
}
