using HizliSec.Core.DataAccess.EntityFrameworkCore;
using HizliSec.DataAccess.Abstract;
using HizliSec.DataAccess.Concrete.EntityFrameworkCore.Context;
using HizliSec.Entities.Concrete;

namespace HizliSec.DataAccess.Concrete.EntityFrameworkCore
{
    public class MessageDal : RepositoryBase<Message>, IMessageDal
    {
        public MessageDal(HizliSecContext context) : base(context)
        {

        }
    }
}
