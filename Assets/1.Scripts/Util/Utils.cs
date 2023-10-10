namespace Com.Hide.Utils
{
    public struct RoomCustomPropertiesName
    {
        public static readonly string Password = "Password";
    }

    public struct RoomProperty
    {
        public static readonly int MinimumPlayerCount = 2;
        public static readonly int MaximumPlayerCount = 8;
    }

    public struct Message
    {
        public string Title { get; private set; }
        public string Msg { get; private set; }

        public Message(string title, string msg)
        {
            Title = title;
            Msg = msg;
        }
    }
}