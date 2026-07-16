namespace RestoranAPiV2.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string NameSurename { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
