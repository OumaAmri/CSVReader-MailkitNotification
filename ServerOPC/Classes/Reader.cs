using CsvHelper;
using NLog;
using ServerOPC.Mapping;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ServerOPC.Classes
{
    public class Reader
    {
        private static string location = LogManager.Configuration.Variables["fileLocation"].OriginalText;
        private static string subject = LogManager.Configuration.Variables["NOKEmailSubject"].OriginalText;
        Notification notification = new Notification();
        Message message = new Message();
        
        public void ReadCsvFile()
        {

            using (var streamReader = new StreamReader(location))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<ServerOPCClassMap>();
                    var records = csvReader.GetRecords<ServerOPC>().ToList();
                   

                    foreach (var record in records)
                    {
                        try
                        {
                            #region ******OK Status ****************
                            if (record.Status == "OK")
                                message.LogOKTag(record);
                            #endregion

                            #region ******NOK Status ****************
                            else if (record.Status == "NOK")
                            {
                                message.LogBadTag(record);                               
                                notification.SendMsg(record.Email, subject, Message.bodyNOKServer(record));

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

                }
            }
        }
    }
}
