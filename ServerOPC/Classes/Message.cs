using NLog;
using System.Collections.Generic;

namespace ServerOPC.Classes
{
    public class Message
    {
        private static Logger BadLogger = LogManager.GetLogger("LoggerRuleBadTag");
        private static Logger OKLogger = LogManager.GetLogger("LoggerRuleOKTag"); 
        private static Logger Logger = LogManager.GetLogger("LoggerRule");
        private static Logger TitleOK = LogManager.GetLogger("RuleTitleOKTag");
        private static Logger TitleBad = LogManager.GetLogger("RuleTitleBadTag");


        public static string bodyNOKServer(ServerOPC server)
        {
            string msg = @"Hello " + server.ResponsibleForIncident + ",\n\n" +
    "A New NOK Server has been detected. Please find attached the information of this server : \n\n" +

    "Location      :   " + server.LocationOfServer + "\n" +
    "OPC Server  :   " + server.OPCServer + "\n" +
    "Testing TAG :   " + server.TestingTAG + "\n" +
    "Timestamp  :   " + server.Timestamp + "\n" +
    "Value           :   " + server.Value + "\n" +
    "Adresse IP   :   " + server.OPCIP + "\n" +
    "Site              :   " + server.Site + "\n\n" +


    "Could you, please, fix this problem?\n\n" +
    "Best Regards,\n" +
    "Automation System";

            return msg;
        }

        public void LogBadTag(ServerOPC server)
        {
            BadLogger.Info("\n" +
    "Location      :   " + server.LocationOfServer + "\n" +
    "OPC Server  :   " + server.OPCServer + "\n" +
    "Testing TAG :   " + server.TestingTAG + "\n" +
    "Timestamp  :   " + server.Timestamp + "\n" +
    "Value           :   " + server.Value + "\n" +
    "Adresse IP   :   " + server.OPCIP + "\n" +
    "Site              :   " + server.Site + "\n\n" +
    "_________________________________________________________________________________________________________");
            
        }

        public void LogOKTag(ServerOPC server)
        {
            OKLogger.Info("Server :" + server.OPCIP + " Site :" + server.Site);
        }

        public void LogUnknownTag(ServerOPC server)
        {
            Logger.Info("Unknown status" + server.OPCIP + " Site :" + server.Site);

        }
        public void LogTitleOK()
        {
            TitleOK.Info("Joignable server");
        }

        public void LogTitleBag()
        {
            TitleBad.Info("Injoignable server");
        }

        public static string MessageNOKWithPingNOK(List<ServerOPC> serveurs)
        {
            string message="";
            string msg1 = "Hello,\n\n" +
"Please find the list of unreachable servers :\n\n";
            foreach (ServerOPC server in serveurs)
            {
                message = message+
               
    "Location      :   " + server.LocationOfServer + "\n" +
    "OPC Server  :   " + server.OPCServer + "\n" +
    "Testing TAG :   " + server.TestingTAG + "\n" +
    "Timestamp  :   " + server.Timestamp + "\n" +
    "Value           :   " + server.Value + "\n" +
    "Adresse IP   :   " + server.OPCIP + "\n" +
    "Site              :   " + server.Site + "\n\n" +
    "---------------------------------------------------------------------------\n\n";
            }
          string msg3 =  "Could you, please, fix this problem?\n\n" +
"Best Regards,\n" +
"Automation System";


            return msg1+message+msg3;
        }


    }
}
