using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using AzureServiceClient.ServiceReference2;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = null;
            

            try
            {
                client = new Service1Client();

                //Object Addition
                DirectoryEntry entry1 = new DirectoryEntry();
                entry1.FirstName = "Arun";
                entry1.LastName = "Sundaram";
                entry1.PhoneNumber = "XXX-XXX-XXXX";
                entry1.Address = "148 3'rd avenue, richmond, va";
                client.AddDirectoryEntry(entry1);

                //Object Query
                var result = client.GetDirectoryEntry("Arun", "Sundaram");

                //Object Deletion
                client.RemoveDirectoryEntry("Arun", "Sundaram");

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception encounter: {0}",
                                   e.Message);
            }
            finally
            {
                if (null != client)
                {
                    client.Close();
                }
            }
        }
    }
}