using AutoMapper;
using HizliSec.Business.Abstract;
using HizliSec.Entities.Concrete;
using HizliSec.Entities.Concrete.Dtos.MessageDtos;

namespace HizliSec.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> MessageSenderAsync(MessageAddDto messageAddDto)
        {
            Message message = _mapper.Map<Message>(messageAddDto);
            await _unitOfWork.MessageDal.AddAsync(message);
            return await _unitOfWork.SaveAsync();
        }

    }
}
