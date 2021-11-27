#region

//System Imports
using System;
using System.Threading.Tasks;

//Custom Imports
using WebhookExc.DiscordAPI;

#endregion

namespace WebhookExc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Webhook Url > ");
            string webhook = Console.ReadLine();

            Console.Write("Webhook Name > ");
            string webhookName = Console.ReadLine();

            Console.WriteLine("Creating webhook connection... (Please wait)");

            Webhook wb = new Webhook(webhookName, webhook);

            while (true)
            {
                Console.WriteLine();
                Console.Write("> ");
                string msg = Console.ReadLine();
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        wb.Invoke(msg);
                    }
                    catch
                    {
                        Console.WriteLine("You are being rate limited by discord!");
                    }
                });
            }
        }
    }
}
