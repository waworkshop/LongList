namespace LongList
{
    public class Message
    {
        public MessageType MessageType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSent { get; set; }
        public bool IsReceived { get { return !IsSent; } }
        public string DisplayTime { get; set; }
    }
}