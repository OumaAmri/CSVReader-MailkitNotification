using ServerOPC.Classes;

namespace ServerOPC
{
    class Program
    {
        static Reader reader = new Reader();
        static Message message = new Message();
        static void Main(string[] args)
        {
            //message.LogTitleOK();
            //message.LogTitleBag();
            //reader.ReadCsvFile();
            reader.ReadCsvOpenFile();

        }          
        }


}
