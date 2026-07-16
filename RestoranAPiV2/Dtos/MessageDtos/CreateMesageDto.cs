namespace RestoranAPiV2.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        
        public string NameSurename { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
