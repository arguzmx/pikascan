namespace PikaScan.Modelo
{
    public class Session
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public string Avatar { get; set; }

        public string Token { get; set; }

        public bool Disconnected { get; set; }

    }
}
