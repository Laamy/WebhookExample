#region

//System Imports
using System.Net;
using System.Collections.Specialized;

#endregion

namespace WebhookExc.DiscordAPI
{
    class WebhookHandler
    {
        public byte[] InvokeWebhook(string uri, NameValueCollection pairs)
        {
            using (WebClient webClient = new WebClient()) // creating new webclients so you can send faster (Nuker support ig)
                return webClient.UploadValues(uri, pairs);
        }

        public void HandledPost(string message, string name, string webhook)
        {
            InvokeWebhook(webhook, new NameValueCollection()
            {
                { "username", name },
                { "content", message }
            });
        }

        public void HandledPost(string message, string name, string webhook, string avatarUrl)
        {
            InvokeWebhook(webhook, new NameValueCollection()
            {
                { "avatar", avatarUrl },
                { "username", name },
                { "content", message }
            });
        }

        public void HandledPost(string message, string webhook)
        {
            InvokeWebhook(webhook, new NameValueCollection()
            {
                { "content", message }
            });
        }

        public void HandledPost(string message, string webhook, string avatarUrl, int i)
        {
            InvokeWebhook(webhook, new NameValueCollection()
            {
                { "avatar", avatarUrl },
                { "content", message }
            });
        }
    }
}
