using NLog;

namespace ServerOPC.Classes
{
    public class Message
    {
        private static Logger BadLogger = LogManager.GetLogger("LoggerRuleBadTag");
        private static Logger OKLogger = LogManager.GetLogger("LoggerRuleOKTag"); 
        private static Logger Logger = LogManager.GetLogger("LoggerRule");

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

    }
}
