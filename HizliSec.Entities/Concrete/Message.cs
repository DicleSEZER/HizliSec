using HizliSec.Core.Entities;


namespace HizliSec.Entities.Concrete
{
    public class Message : IEntity
    {
        public Message()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SendMessage { get; set; }
        public AppUser Sender { get; set; }
        public AppUser Receiver { get; set; }

        public DateTime CreateDate { get; }
    }
}
