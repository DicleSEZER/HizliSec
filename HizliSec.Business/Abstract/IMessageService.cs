using HizliSec.Entities.Concrete.Dtos.MessageDtos;

namespace HizliSec.Business.Abstract
{
    public interface IMessageService
    {
        Task<int> MessageSenderAsync(MessageAddDto messageAddDto);

    }
}
