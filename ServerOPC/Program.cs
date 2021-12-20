using ServerOPC.Classes;

namespace ServerOPC
{
    class Program
    {
        static Reader reader = new Reader();
        static void Main(string[] args)
        {

            reader.ReadCsvFile();
        }

            #region ****OLD CODE*******
            //    #region ************Variables******************
            //    private static Logger OKLogger = LogManager.GetLogger("LoggerRuleOKTag");
            //    private static Logger BadLogger = LogManager.GetLogger("LoggerRuleBadTag");
            //    private static Logger TitleLogger = LogManager.GetLogger("LoggerRuleTitleTag");
            //    private static string from = LogManager.Configuration.Variables["from"].OriginalText; 
            //    private static string password = LogManager.Configuration.Variables["pwd"].OriginalText;
            //    private static string encryptedPwd = Password.DecryptString(password);
            //    private static string location = LogManager.Configuration.Variables["fileLocation"].OriginalText;

            //    #endregion ************Variables******************
            //    static void Main(string[] args)
            //    {
            //        #region ************* Log************************

            //        TitleLogger.Info("Joignable server");

            //        BadLogger.Info("__________________________________________________________________");
            //        BadLogger.Info("**************** Injoignable server ***********************");



            //        #endregion

            //        using (var streamReader = new StreamReader(location))
            //        {
            //            using(var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            //            {


            //                csvReader.Context.RegisterClassMap<ServerOPCClassMap>(); 
            //                var records = csvReader.GetRecords<Classes.ServerOPC>().ToList();

            //                foreach(var record in records)
            //                {
            //                    try
            //                    {
            //                        #region ******OK Status ****************
            //                        if (record.Status == "OK")
            //                            OKLogger.Info("Server :" + record.OPCIP + " Site :" + record.Site);
            //                        #endregion

            //                        #region ******NOK Status ****************
            //                        else if (record.Status == "NOK")
            //                        {
            //                            BadLogger.Info("\n" +
            //"Location      :   " + record.LocationOfServer + "\n" +
            //"OPC Server  :   " + record.OPCServer + "\n" +
            //"Testing TAG :   " + record.TestingTAG + "\n" +
            //"Timestamp  :   " + record.Timestamp + "\n" +
            //"Value           :   " + record.Value + "\n" +
            //"Adresse IP   :   " + record.OPCIP + "\n" +
            //"Site              :   " + record.Site + "\n\n" +
            //"_________________________________________________________________________________________________________");

            //                            #region **************Notification*******************************

            //                            MimeMessage msg = new MimeMessage();
            //                            msg.From.Add(new MailboxAddress("Automation System", "noreplytealts@gmail.com"));
            //                            msg.To.Add(MailboxAddress.Parse(record.Email));
            //                            msg.Subject = "New NOK Server";
            //                            msg.Body = new TextPart("plain")
            //                            {
            //                                Text = @"Hello " + record.ResponsibleForIncident + ",\n\n" +
            //"A New NOK Server has been detected. Please find attached the information of this server : \n\n" +

            //"Location      :   " + record.LocationOfServer + "\n" +
            //"OPC Server  :   " + record.OPCServer + "\n" +
            //"Testing TAG :   " + record.TestingTAG + "\n" +
            //"Timestamp  :   " + record.Timestamp + "\n" +
            //"Value           :   " + record.Value + "\n" +
            //"Adresse IP   :   " + record.OPCIP + "\n" +
            //"Site              :   " + record.Site + "\n\n" +


            //"Could you, please, fix this problem?\n\n" +
            //"Best Regards,\n" +
            //"Automation System"
            //                            };

            //                            SmtpClient client = new SmtpClient();
            //                            try
            //                            {
            //                                client.Connect("smtp.gmail.com", 465, true);
            //                                client.Authenticate(from, encryptedPwd);
            //                                client.Send(msg);
            //                                Console.WriteLine("Email sent!");
            //                                client.Disconnect(true);
            //                            }
            //                            catch (Exception ex)
            //                            {
            //                                Console.WriteLine(ex.Message);
            //                            }
            //                            //finally
            //                            //{
            //                            //    client.Disconnect(true);
            //                            //    client.Dispose();
            //                            //}
            //                            //Console.ReadLine();

            //                            #endregion

            //                        }
            //                        #endregion

            //                        else
            //                        {
            //                            OKLogger.Info("Unknown status" + record.OPCIP + " Site :" + record.Site);
            //                            OKLogger.Info("Unknown status" + record.OPCIP + " Site :" + record.Site);
            //                        }

            //                    }
            //                    catch(Exception ex)
            //                    {
            //                        Console.WriteLine(ex);
            //                    }


            //                }

            //            }
            //        }
            //    }
            #endregion
        }


}
