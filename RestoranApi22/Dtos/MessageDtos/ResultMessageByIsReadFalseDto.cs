namespace RestoranApi22.WebUI.Dtos.MessageDtos
{
    public class ResultMessageByIsReadFalseDto
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
