namespace WebhookExc.DiscordAPI
{
    class Webhook
    {
        public Webhook(string webhookName, string webhookUrl)
        {
            this.webhookName = webhookName;
            this.webhookUrl = webhookUrl;
        }

        public WebhookHandler webhook = new WebhookHandler();

        public string webhookName = "WebhookSender";
        public string webhookUrl = "WebhookUrl";
        public string avatarUrl = "AvatarUrl";

        public WebhookName nameInformation = WebhookName.Custom;
        public Avatar avatarInformation = Avatar.Custom;

        public void Invoke(string message)
        {
            switch (avatarInformation)
            {
                case Avatar.Default:
                    switch (nameInformation)
                    {
                        case WebhookName.Default:
                            webhook.HandledPost(message, webhookUrl);
                            break;
                        case WebhookName.Custom:
                            webhook.HandledPost(message, webhookName, webhookUrl);
                            break;
                    }
                    break;
                case Avatar.None:
                    switch (nameInformation)
                    {
                        case WebhookName.Default:
                            webhook.HandledPost(message, webhookUrl, "https://cdn1.dotesports.com/wp-content/uploads/2018/08/11165120/47410681-4265-41a6-ab71-679b40e30d78.jpg", 1);
                            break;
                        case WebhookName.Custom:
                            webhook.HandledPost(message, webhookName, webhookUrl, "https://cdn1.dotesports.com/wp-content/uploads/2018/08/11165120/47410681-4265-41a6-ab71-679b40e30d78.jpg");
                            break;
                    }
                    break;
                case Avatar.Custom:
                    switch (nameInformation)
                    {
                        case WebhookName.Default:
                            webhook.HandledPost(message, webhookName, webhookUrl, avatarUrl);
                            break;
                        case WebhookName.Custom:
                            webhook.HandledPost(message, webhookName, webhookUrl, avatarUrl);
                            break;
                    }
                    break;
            }
        }
    }
}
