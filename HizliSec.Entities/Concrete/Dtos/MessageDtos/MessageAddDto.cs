using HizliSec.Core.Entities;


namespace HizliSec.Entities.Concrete.Dtos.MessageDtos
{
    public class MessageAddDto : IDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SendMessage { get; set; }
    }
}
}
