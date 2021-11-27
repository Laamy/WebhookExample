using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebhookExc.DiscordAPI
{
    class Webhook
    {
        private WebhookHandler webhook = new WebhookHandler();
        private string name = "WebhookSender";
        private string url = "WebhookUrl";

        public Webhook(string name, string url)
        {
            SetName(name);
            SetUrl(url);
        }

        public void SetName(string name) => this.name = name;
        public void SetUrl(string url) => this.url = url;
        public void Invoke(string message) => webhook.HandledPost(message, name, url);
    }
}
