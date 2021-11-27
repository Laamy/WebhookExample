using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebhookExc.DiscordAPI;

namespace WebhookExc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter webhook url");
            Console.Write("> ");
            string webhook = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Please enter webhook name");
            Console.Write("> ");
            string webhookName = Console.ReadLine();

            Console.WriteLine("Creating webhook connection...");

            Webhook wb = new Webhook(webhookName, webhook);

            wb.AvatarSettings(Avatar.Custom, WebhookName.Custom);

            Console.WriteLine();

            while (true)
            {
                Console.WriteLine();
                Console.Write("> ");
                string msg = Console.ReadLine();
                try
                {
                    wb.Invoke(msg);
                }
                catch
                {
                    Console.WriteLine("You are being rate limited!");
                }
            }
        }
    }
}
