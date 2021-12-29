using CsvHelper;
using NLog;
using ServerOPC.Mapping;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

namespace ServerOPC.Classes
{
    public class Reader
    {
        private static string location = LogManager.Configuration.Variables["fileLocation"].OriginalText;
        private static string subject = LogManager.Configuration.Variables["NOKEmailSubject"].OriginalText;
        private static string MidelwareEmail = LogManager.Configuration.Variables["MidelwareEmail"].OriginalText;
        Notification notification = new Notification();
        Message message = new Message();

      
        public void ReadCsvOpenFile()
        {
            try
            {
                var fs = new FileStream(location, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var sr = new StreamReader(fs, false);
                var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                using (csv)
                {
                    csv.Context.RegisterClassMap<ServerOPCClassMap>();
                    var records = csv.GetRecords<ServerOPC>().ToList();
                
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exection" + ex);
                Console.ReadLine();

            }


        }
       

        public void ReadCsvFile()
        {
            List<ServerOPC> NOKWithPingOK = new List<ServerOPC>();
            List<ServerOPC> NOKWithPingNOK = new List<ServerOPC>();
            List<string> site = new List<string>();         

            using (var streamReader = new StreamReader(location))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture,true))
                {
                    csvReader.Context.RegisterClassMap<ServerOPCClassMap>();
                    var records = csvReader.GetRecords<ServerOPC>().ToList();                  
                    if (records.Count == 0)
                    {

                    }
                    
                    foreach (var record in records)
                    {
                        try
                        {
                            #region OK Status
                            if (record.Status == "OK")
                                message.LogOKTag(record);
                            #endregion

                            #region NOK Status
                            else if (record.Status == "NOK")
                            {
                                Ping ping = new Ping();
                                PingReply pingReply = ping.Send(record.OPCIP);

                                if (pingReply.Status == IPStatus.Success)
                                {
                                    NOKWithPingOK.Add(record);
                                }
                                else
                                {
                                    NOKWithPingNOK.Add(record);
                                }
                                //message.LogBadTag(record);                               
                                //notification.SendMsg(record.Email, subject, Message.bodyNOKServer(record));

                            }
                            #endregion

                            else
                            {
                                message.LogUnknownTag(record);
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }

                    foreach(var server in NOKWithPingNOK)
                    {
                        site.Add(server.Site);
                    }                
                   List<string> siteDistinct= site.Distinct().ToList();
                   foreach(string element in siteDistinct)
                    {
                        var responsable = NOKWithPingNOK.ToList().Where(s => s.Site == element).FirstOrDefault().Email;
                        //Ajouter une adress ou responsable est null
                        List<ServerOPC> list = NOKWithPingNOK.Where(s => s.Site == element).ToList();
                        notification.SendMsgNOKWithPingNOK(responsable, "NOK Servers for site : " + element, Message.MessageNOKWithPingNOK(list));
                    }
                   
                   
                }
            }
        }
    }
}
