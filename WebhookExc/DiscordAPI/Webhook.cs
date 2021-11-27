namespace WebhookExc.DiscordAPI
{
    class Webhook
    {
        public Webhook(string name, string url)
        {
            SetName(name);
            SetUrl(url);
        }

        private WebhookHandler webhook = new WebhookHandler();

        private string name = "WebhookSender";
        private WebhookName nameInformation = WebhookName.Default;

        private string url = "WebhookUrl";

        private string avatarUrl = "AvatarUrl";
        private Avatar avatarInformation = Avatar.Default;

        public void AvatarSettings(Avatar avatarInformation = Avatar.Default, WebhookName nameInformation = WebhookName.Default)
        {
            this.avatarInformation = avatarInformation;
            this.nameInformation = nameInformation;
        }
        public void SetName(string name) => this.name = name;
        public void SetUrl(string url) => this.url = url;
        public void AvatarUrl(string avatarUrl) => this.avatarUrl = avatarUrl;

        public void Invoke(string message)
        {
            switch (avatarInformation)
            {
                case Avatar.Default:
                    switch (nameInformation)
                    {
                        case WebhookName.Default:
                            webhook.HandledPost(message, url);
                            break;
                        case WebhookName.Custom:
                            webhook.HandledPost(message, name, url);
                            break;
                    }
                    break;
                case Avatar.None:
                    switch (nameInformation)
                    {
                        case WebhookName.Default:
                            webhook.HandledPost(message, url, "https://cdn1.dotesports.com/wp-content/uploads/2018/08/11165120/47410681-4265-41a6-ab71-679b40e30d78.jpg", 1);
                            break;
                        case WebhookName.Custom:
                            webhook.HandledPost(message, name, url, "https://cdn1.dotesports.com/wp-content/uploads/2018/08/11165120/47410681-4265-41a6-ab71-679b40e30d78.jpg");
                            break;
                    }
                    break;
                case Avatar.Custom:
                    switch (nameInformation)
                    {
                        case WebhookName.Default:
                            webhook.HandledPost(message, name, url, avatarUrl);
                            break;
                        case WebhookName.Custom:
                            webhook.HandledPost(message, name, url, avatarUrl);
                            break;
                    }
                    break;
            }
        }
    }
}
