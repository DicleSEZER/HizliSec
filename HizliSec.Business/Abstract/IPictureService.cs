

using HizliSec.Entities.Concrete.Dtos.CategoryDtos;
using HizliSec.Entities.Concrete.Dtos.PictureDtos;

namespace HizliSec.Business.Abstract
{
    public interface IPictureService
    {
        Task<List<PictureDto>> GetAllAsync();
        Task<int> DeleteAsync(int id);
        Task<int> AddAsync(PictureAddDto pictureAddDto);
        Task<int> UpdateAsync(PictureDto pictureDto);
    }
}
